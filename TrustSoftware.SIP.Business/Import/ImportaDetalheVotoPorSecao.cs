using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Business.Parametros;
using System.IO;
using SilvanoFontes.AL.Utility.Enums;
using SilvanoFontes.AL.Utility;
using SilvanoFontes.AL.Entities.Relatorios;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Business.Import
{
    public class ImportaDetalheVotoPorSecao : DetalheVotoPorSecaoNeg
    {
        private int _AnoArquivo { get; set; }
        private string _UFArquivo { get; set; }
        private int _IdUsuario { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="idUsuario">Id do usuario loga do no sistema</param>
        public ImportaDetalheVotoPorSecao(int idUsuario)
        {
            _IdUsuario = idUsuario;
        }

        public void Import(int idArquivo)
        {
            Arquivo arquivo = new ArquivoNeg().getById(idArquivo);

            CarregaAnoUFArquivo(arquivo.NomeArquivo);

            AnoLayout anoLayout;
            if (_AnoArquivo >= 2012)
                anoLayout = AnoLayout.Apos2012;
            else
                anoLayout = AnoLayout.Ate2008;

            ///Verificar se o arquivo já foi importado e excluir da base antes que seja importado novamente.
            DeletaImportacaoAnterior();

            if (arquivo != null)
            {

                string line = "";

                using (StreamReader objArquivo = new StreamReader(arquivo.NomeArquivo, Encoding.UTF7))
                {
                    string[] rowArr = null;
                    Int32 TotalRegistros = 0;

                    LogImportacao logImportacao = new LogImportacao();
                    logImportacao.Arquivo = arquivo.Id;
                    logImportacao.Data = DateTime.Now;
                    logImportacao.Usuario = _IdUsuario;

                    DetalheVotoPorSecao detalhe;

                    List<Estado> estados = new List<Estado>();
                    estados = new EstadoNeg().listAll();

                    while ((line = objArquivo.ReadLine()) != null)
                    {
                        line = line.Replace("\"", "");

                        rowArr = line.Split(';');

                        detalhe = new DetalheVotoPorSecao();

                        detalhe.Ano = int.Parse(rowArr[2].Trim());

                        detalhe.Turno = int.Parse(rowArr[3].Trim());

                        detalhe.UF = estados.Where(x => x.UF == rowArr[5].ToUpper().Trim()).First().Id;

                        int idUE;
                        if (int.TryParse(rowArr[6].Trim().ToUpper(), out idUE))
                        { detalhe.UE = idUE; }
                        else
                        {
                            if (estados.Where(x => x.UF == rowArr[6].Trim().ToUpper()).Count() > 0)
                                detalhe.UE = estados.Where(x => x.UF == rowArr[6].Trim().ToUpper()).First().Id;
                            else
                                detalhe.UE = 0;
                        }

                        detalhe.Municipio = int.Parse(rowArr[7].ToUpper().Trim());

                        detalhe.Zona = int.Parse(rowArr[9].Trim());

                        detalhe.Secao = int.Parse(rowArr[10].Trim());

                        detalhe.Cargo = int.Parse(rowArr[11].Trim());

                        detalhe.QuantAptos = Int32.Parse(rowArr[13].Trim());

                        detalhe.QuantComparecimento = Int32.Parse(rowArr[14].Trim());

                        detalhe.QuantAbstencoes = Int32.Parse(rowArr[15].Trim());

                        detalhe.QuantVotosNominais = Int32.Parse(rowArr[16].Trim());

                        detalhe.QuantVotosBrancos = Int32.Parse(rowArr[17].Trim());

                        detalhe.QuantVotosNulos = Int32.Parse(rowArr[18].Trim());

                        detalhe.QuantVotosLegenda = Int32.Parse(rowArr[19].Trim());

                        detalhe.QuantVotosAnuladosApuradosSeparados = Int32.Parse(rowArr[20].Trim());

                        if (anoLayout == AnoLayout.Apos2014)
                            detalhe.QuantVotosTransito = Int32.Parse(rowArr[21].Trim());
                        else
                            detalhe.QuantVotosTransito = 0;

                        try
                        {
                            base.Save(detalhe);
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
        }

        public void DeletaImportacaoAnterior()
        {
            
            Estado estado = new Estado();
            estado = new EstadoNeg().getByUF(_UFArquivo);
            base.DeleteByAnoUF(_AnoArquivo, (estado != null) ? estado.Id : 0);
            
        }

        private void CarregaAnoUFArquivo(string arquivo)
        {
            int tamanhoTotal = "detalhe_votacao_secao_2012_RJ.txt".Length;
            string prefixo = "detalhe_votacao_secao_";
            int tamanhoAno = 4;
            int tamanhoUF = 2;

            string nomeArquivo = arquivo.Substring(arquivo.Length - tamanhoTotal, tamanhoTotal);


            _AnoArquivo = int.Parse(nomeArquivo.Substring(prefixo.Length, tamanhoAno));
            _UFArquivo = nomeArquivo.Substring(prefixo.Length + tamanhoAno + 1, tamanhoUF);

        }
    }
}
