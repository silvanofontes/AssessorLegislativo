using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Business.Parametros;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Entities.Parametros;


namespace SilvanoFontes.AL.Business.Import
{
    public class ImportaMunicipio : MunicipioNeg
    {

        public ImportaMunicipio()
        { }

        public void Import(int idArquivo)
        {

            Arquivo arquivo = new ArquivoNeg().getById(idArquivo);

            if (arquivo != null)
            {

                using (StreamReader objArquivo = new StreamReader(arquivo.NomeArquivo, Encoding.UTF7))
                {
                    string[] rowArr = null;
                    string row = "";
                    Int32 TotalRegistros = 0;
                    Municipio municipio;

                    LogImportacao logImportacao = new LogImportacao();
                    logImportacao.Arquivo = arquivo.Id;
                    logImportacao.Data = DateTime.Now;
                    logImportacao.Usuario = 0; ///TODO: Informar o Usuario Logado

                    while ((row = objArquivo.ReadLine()) != null)
                    {
                        rowArr = row.Split(';');

                        if (rowArr[1].ToUpper().Trim() != "UF")
                        {
                            municipio = new Municipio();

                            municipio.Id = int.Parse(rowArr[0]);
                            municipio.Descricao = rowArr[2].ToString().ToUpper().Trim();
                            try
                            {
                                municipio.UF = new EstadoNeg().getByUF(rowArr[1].ToString().ToUpper().Trim());

                                base.VerificaSalva(municipio);

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
                    municipio = null;

                }
            }
        }


    }
}
