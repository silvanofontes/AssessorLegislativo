﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;
using SilvanoFontes.AL.Entities.Parametros;
using System.IO;
using SilvanoFontes.AL.Business.Parametros;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Business.Import
{
    public class ImportaBensCandidato : GenericBusiness<BensCandidato>
    {

        private int _AnoArquivo { get; set; }
        private string _UFArquivo { get; set; }
        private int _IdUsuario { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="idUsuario">Id do usuario loga do no sistema</param>
        public ImportaBensCandidato(int idUsuario)
        {
            _IdUsuario = idUsuario;
        }

        public void Import(int idArquivo)
        {
            Arquivo arquivo = new ArquivoNeg().getById(idArquivo);

            CarregaAnoUFArquivo(arquivo.NomeArquivo);

            ///Verificar se o arquivo já foi importado e excluir da base antes que seja importado novamente.
            DeletaImportacaoAnterior();

            if (arquivo != null)
            {

                string row = "";

                using (StreamReader objArquivo = new StreamReader(arquivo.NomeArquivo, Encoding.UTF7))
                {
                    string[] rowArr = null;
                    Int32 TotalRegistros = 0;
                    AnoLayout anoLayout;
                    int flagAno;

                    LogImportacao logImportacao = new LogImportacao();
                    logImportacao.Arquivo = arquivo.Id;
                    logImportacao.Data = DateTime.Now;
                    logImportacao.Usuario = _IdUsuario;

                    BensCandidato bem = new BensCandidato();
                    
                    while ((row = objArquivo.ReadLine()) != null)
                    {
                        row = row.Replace("\"", "");

                        rowArr = row.Split(';');

                        if (int.Parse(rowArr[2]) >= 2012)
                        {
                            flagAno = 0;
                            anoLayout = AnoLayout.Apos2012;
                        }
                        else
                        {
                            flagAno = 1;
                            anoLayout = AnoLayout.Ate2008;
                        }

                        bem = new BensCandidato();

                        bem.Ano = int.Parse(rowArr[2]);

                        bem.UF = rowArr[4];

                        bem.IdCandidato = Int64.Parse(rowArr[5]);

                        bem.TipoBem = new TipoBemNeg().VerificaSalva(
                            new TipoBem()
                                {
                                    Id = int.Parse(rowArr[6]),
                                    Descricao = rowArr[7]
                                }
                            );

                        bem.Detalhe = rowArr[8].ToUpper().Trim();

                        bem.Valor = double.Parse(rowArr[9].Trim().Replace(".",","));

                        bem.DataAtualizacao = DateTime.Parse(rowArr[10] + " " + rowArr[11]);

                        try
                        {
                            base.Save(bem);
                            TotalRegistros++;
                        }
                        catch (Exception ex)
                        {
                            logImportacao.AddErro(ex.Message);
                        }

                    }

                    logImportacao.CalculaTempo();
                    logImportacao.TotalRegistros = TotalRegistros;

                    using (LogImportacaoNeg negLogImportacao = new LogImportacaoNeg())
                    {
                        negLogImportacao.Save(logImportacao);
                    }

                    logImportacao = null;

                }
            }

            arquivo = null;
        }

        public void DeletaImportacaoAnterior()
        {
            base.AddCriteria(x => x.Ano, Criteria.Eq, _AnoArquivo);
            base.AddCriteria(x => x.UF, Criteria.Eq, _UFArquivo);

            base.DeleteByFilter();
        }

        private void CarregaAnoUFArquivo(string arquivo)
        {
            //CONSULTA_CAND_<ANO ELEIÇÃO>_<SIGLA UF>
            int tamanhoTotal = "bem_candidato_2012_RJ.txt".Length;
            string prefixo = "bem_candidato_";
            int tamanhoAno = 4;
            int tamanhoUF = 2;

            string nomeArquivo = arquivo.Substring(arquivo.Length - tamanhoTotal, tamanhoTotal);


            _AnoArquivo = int.Parse(nomeArquivo.Substring(prefixo.Length, tamanhoAno));
            _UFArquivo = nomeArquivo.Substring(prefixo.Length + tamanhoAno + 1, tamanhoUF);

        }

    }
}
