using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Business.Parametros;
using System.IO;
using SilvanoFontes.AL.Utility.Enums;
using SilvanoFontes.AL.Utility;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Entities.Relatorios;


namespace SilvanoFontes.AL.Business.Import
{
    public class ImportacaoVotoCandiatoPorSecao : VotoCandiatoPorSecaoNeg
    {
        private int _AnoArquivo { get; set; }
        private string _UFArquivo { get; set; }
        private int _IdUsuario { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="idUsuario">Id do usuario logado no sistema</param>
        public ImportacaoVotoCandiatoPorSecao(int idUsuario)
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

                    LogImportacao logImportacao = new LogImportacao();
                    logImportacao.Arquivo = arquivo.Id;
                    logImportacao.Data = DateTime.Now;
                    logImportacao.Usuario = _IdUsuario;

                    VotoCandiatoPorSecao objVoto;

                    List<Estado> estados = new List<Estado>();
                    estados = new EstadoNeg().listAll();

                    while ((row = objArquivo.ReadLine()) != null)
                    {
                        row = row.Replace("\"", "");

                        rowArr = row.Split(';');

                        objVoto = new VotoCandiatoPorSecao();

                        objVoto.Ano = int.Parse(rowArr[2].Trim());
                        objVoto.Turno = int.Parse(rowArr[3].Trim());


                        objVoto.UF = estados.Where(x => x.UF == rowArr[5].Trim().ToUpper()).First().Id;

                        int idUE;
                        if (int.TryParse(rowArr[6].Trim().ToUpper(), out idUE))
                            { objVoto.UE = idUE; }
                        else
                        {

                            if (estados.Where(x => x.UF == rowArr[6].Trim().ToUpper()).Count() > 0)
                                objVoto.UE = estados.Where(x => x.UF == rowArr[6].Trim().ToUpper()).First().Id;
                            else
                                objVoto.UE = 0;
                        }
                        
                        

                        objVoto.Municipio = int.Parse(rowArr[7].Trim());

                        objVoto.Zona = int.Parse(rowArr[9].Trim());

                        objVoto.Secao = int.Parse(rowArr[10].Trim());

                        objVoto.Cargo = int.Parse(rowArr[11].Trim());

                        objVoto.NumeroCandidato = Int32.Parse(rowArr[13].Trim());

                        objVoto.QuantidadeVotos = Int32.Parse(rowArr[14].Trim());

                        try
                        {
                            base.Save(objVoto);
                            TotalRegistros++;
                        }
                        catch (Exception ex)
                        {
                            logImportacao.AddErro(ex.Message);
                        }

                    }

                    objVoto = null;

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
            int tamanhoTotal = "votacao_secao_2012_RJ.txt".Length;
            string prefixo = "votacao_secao_";
            int tamanhoAno = 4;
            int tamanhoUF = 2;

            string nomeArquivo = arquivo.Substring(arquivo.Length - tamanhoTotal, tamanhoTotal);


            _AnoArquivo = int.Parse(nomeArquivo.Substring(prefixo.Length, tamanhoAno));
            _UFArquivo = nomeArquivo.Substring(prefixo.Length + tamanhoAno + 1, tamanhoUF);

        }

    }
}
