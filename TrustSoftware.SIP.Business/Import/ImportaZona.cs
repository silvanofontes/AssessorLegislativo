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

namespace SilvanoFontes.AL.Business.Import
{
    public class ImportaZona : ZonaNeg
    {
        private int _AnoArquivo { get; set; }
        private string _UFArquivo { get; set; }
        private int _IdUsuario { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="idUsuario">Id do usuario loga do no sistema</param>
        public ImportaZona(int idUsuario)
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

                    Zona zona = new Zona();

                    while ((row = objArquivo.ReadLine()) != null)
                    {
                        row = row.Replace("\"", "");

                        rowArr = row.Split(';');

                        if (rowArr[0].Trim() != "Nr Zona")
                        {
                            zona = new Zona();

                            zona.NumeroZona = int.Parse(rowArr[0]);

                            zona.CodigoProcessualResCNJ = rowArr[1].ToUpper().Trim();

                            zona.Endereco = rowArr[2].ToUpper().Trim();

                            zona.CEP = rowArr[3].Trim();

                            zona.Bairro = rowArr[4].ToUpper().Trim();

                            zona.NomeMunicipio = rowArr[5].ToUpper().Trim();

                            Municipio municipio;

                            zona.Municipio = ((municipio = new MunicipioNeg().getByNomeUF(zona.NomeMunicipio, rowArr[6].Trim())) == null) ? 0 : municipio.Id;

                            Estado estado;
                            zona.UF = ((estado = new EstadoNeg().getByUF(rowArr[6].Trim())) == null) ? 0 : estado.Id;

                            try
                            {
                                base.Save(zona);
                                TotalRegistros++;
                            }
                            catch (Exception ex)
                            {
                                logImportacao.AddErro(ex.Message);
                            }
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
            base.AddCriteria(x => x.UF, Criteria.Eq, _UFArquivo);
            base.DeleteByFilter();
        }

        private void CarregaAnoUFArquivo(string arquivo)
        {
            int tamanhoTotal = "zonas_RJ.txt".Length;
            string prefixo = "zonas_";
            int tamanhoUF = 2;

            string nomeArquivo = arquivo.Substring(arquivo.Length - tamanhoTotal, tamanhoTotal);

            _UFArquivo = nomeArquivo.Substring(prefixo.Length, tamanhoUF);

            //Pego o código da UF
            _UFArquivo = new EstadoNeg().getByUF(_UFArquivo).Id.ToString();

        }
    }
}
