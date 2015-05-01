using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility.Enums;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Business.Parametros;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business.Import
{
    public class ImportaCandidatura : CandidaturaNeg
    {
        private Usuario _Usuario { get; set; }

        private int _AnoArquivo { get; set; }
        private string _UFArquivo { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="idUsuario">Id do usuario loga do no sistema</param>
        public ImportaCandidatura(Usuario usuario) : base(usuario)
        {
            _Usuario = usuario;
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

                    Candidatura candidatura;

                    LogImportacao logImportacao = new LogImportacao();
                    logImportacao.Arquivo = arquivo.Id;
                    logImportacao.Data = DateTime.Now;
                    logImportacao.Usuario = _Usuario.Id;


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

                        candidatura = new Candidatura();
                        candidatura.Ano = int.Parse(rowArr[2]);
                        candidatura.Turno = int.Parse(rowArr[3]);
                        candidatura.UF = new EstadoNeg().getByUF(rowArr[5]);


                        candidatura.Cargo =
                            new CargoNeg().VerificaSalva(
                                new Cargo()
                                {
                                    Id = int.Parse(rowArr[8]),
                                    Descricao = rowArr[9]
                                }
                            );

                        //============================================
                        // CANDIDATO

                        Candidato candidato = new Candidato();
                        CandidatoNeg negCandidato = new CandidatoNeg(_Usuario);



                        candidato = negCandidato.CarregaDadosCandidato(rowArr);

                        candidatura.Candidato = candidato;


                        //if (anoLayout == AnoLayout.Ate2012)

                        //============================================
                        candidatura.SituacaoCandidatura =
                            new SituacaoCandidaturaNeg().VerificaSalva(
                                new SituacaoCandidatura()
                                {
                                    Id = int.Parse(rowArr[15 - flagAno]),
                                    Descricao = rowArr[16 - flagAno]
                                }
                            );

                        candidatura.Partido =
                            new PartidoNeg().VerificaSalva(
                                new Partido()
                                {
                                    Numero = int.Parse(rowArr[17 - flagAno]),
                                    Sigla = rowArr[18 - flagAno].ToUpper().Trim(),
                                    Nome = rowArr[19 - flagAno].ToUpper().Trim()
                                }
                            );
                        candidatura.CodigoLegenda = Int64.Parse(rowArr[20 - flagAno]);
                        candidatura.SiglaLegenda = rowArr[21 - flagAno].ToUpper().Trim();
                        candidatura.ComposicaoLegenda = rowArr[22 - flagAno].ToUpper().Trim();
                        candidatura.NomeLegenda = rowArr[23 - flagAno].ToUpper().Trim();

                        if (anoLayout == AnoLayout.Apos2012)
                            flagAno += 2;

                        candidatura.DespesaMaximaCampanha = double.Parse(rowArr[42 - flagAno].Replace(".", ","));
                        candidatura.ResultadoCampanha =
                            new ResultadoCampanhaNeg().VerificaSalva(
                                new ResultadoCampanha()
                                {
                                    Id = int.Parse(rowArr[43 - flagAno]),
                                    Resultado = rowArr[44 - flagAno].ToUpper().Trim()
                                }
                            );

                        try
                        {
                            base.Save(candidatura);
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
                    candidatura = null;
                }

            }
        }

        public void DeletaImportacaoAnterior()
        {
            base.AddCriteria(x => x.Ano, Criteria.Eq, _AnoArquivo);
            base.AddCriteria(Criteria.Eq, new Parametro() { Text = "UF_id", Value = new EstadoNeg().getByUF(_UFArquivo).Id });

            base.DeleteByFilter();
        }

        private void CarregaAnoUFArquivo(string arquivo)
        {
            //CONSULTA_CAND_<ANO ELEIÇÃO>_<SIGLA UF>
            int tamanhoTotal = "consulta_cand_2012_RJ.txt".Length;
            string prefixo = "consulta_cand_";
            int tamanhoAno = 4;
            int tamanhoUF = 2;

            string nomeArquivo = arquivo.Substring(arquivo.Length - tamanhoTotal, tamanhoTotal);


            _AnoArquivo = int.Parse(nomeArquivo.Substring(prefixo.Length, tamanhoAno));
            _UFArquivo = nomeArquivo.Substring(prefixo.Length + tamanhoAno + 1, tamanhoUF);

        }

    }
}
