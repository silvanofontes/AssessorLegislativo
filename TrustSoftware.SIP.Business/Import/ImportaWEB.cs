using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Business.Parametros;
using System.Data;
using HtmlAgilityPack;
using System.Net;
using System.Data.OleDb;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Business.Import
{
    public class ImportaEnderecoSecaoRJ : SecaoNeg
    {
        private int _IdUsuario { get; set; }
        private int _UF { get; set; }

        public ImportaEnderecoSecaoRJ(int idUsuario)
        {
            _IdUsuario = idUsuario;
            _UF = 33; //Já que a importação é padrão para o Rio
        }

        public void DownloadListaSecoesHTML(int idArquivo)
        {

            Arquivo arquivo = new ArquivoNeg().getById(idArquivo);

            if (Download(arquivo.Fonte, arquivo.NomeArquivo))
            {
                using (StreamReader objArquivo = new StreamReader(arquivo.NomeArquivo, Encoding.UTF7))
                {
                    
                    Int32 TotalRegistros = 0;

                    LogImportacao logImportacao = new LogImportacao();
                    logImportacao.Arquivo = arquivo.Id;
                    logImportacao.Data = DateTime.Now;
                    logImportacao.Usuario = _IdUsuario;

                    base.DeletaImportAnterior(_UF);

                    HtmlDocument doc = new HtmlDocument();

                    string municipio, link;
                    using (WebClient client = new WebClient())
                    {
                        string html = client.DownloadString(arquivo.Fonte);
                        doc.LoadHtml(html);
                    }

                    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
                    {
                        if (table.Id == "sublinhado")
                        {
                            foreach (HtmlNode row in table.SelectNodes("tr"))
                            {
                                if (row.SelectNodes("th|td") != null)
                                {
                                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                                    {
                                        foreach (HtmlNode href in cell.SelectNodes("a"))
                                        {
                                            foreach (HtmlNode _link in cell.Descendants("a").Where(x => x.Attributes.Contains("href")))
                                            {
                                                municipio = _link.InnerText.ToUpper().Trim();
                                                link = _link.Attributes["href"].Value;

                                                Download("http://www.tre-rj.jus.br/site/eleicoes/2012/local_votacao/" + link, @"E:\Silvano\Sites - Particulares\AssessorLegislativo\Arquivos\Download\lista_secao_municipio_" + municipio + ".xls");

                                                ImportaSecaoXLS(@"E:\Silvano\Sites - Particulares\AssessorLegislativo\Arquivos\Download\lista_secao_municipio_" + municipio + ".xls", _UF);

                                                TotalRegistros++;

                                            }
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            throw new Exception("O Layout do arquivo de importação das seções do RJ mudou");
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

        public void ImportaSecaoXLS(string arquivo, int uf)
        {
            DataSet ds = new DataSet();
            OleDbConnection conexao = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + arquivo + ";Extended Properties=Excel 8.0;");
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Plan1$]", conexao);
            da.Fill(ds);
            DataTable excel = ds.Tables[0];

            Secao secao;
            

            foreach (DataRow row in excel.Rows) // Loop over the rows.
            {
                secao = new Secao();

                secao.Zona =  int.Parse(row[0].ToString());
                secao.UF = uf;
                secao.Municipio = Int32.Parse(row[1].ToString());
                //temp += row["Nome Munic"].ToString();
                secao.Bairro = row[3].ToString();
                secao.Endereco = row[4].ToString();

                secao.CEP = row[5].ToString();
                secao.NumLocal = int.Parse(row[6].ToString());
                secao.NomeLocal = row[7].ToString();
                
                if (secao.Municipio != 58890) //Rio das Flores
                    secao.IdSecao = int.Parse(row["Secao"].ToString());

                if (secao.Municipio != 58890) //Rio das Flores
                    secao.QuantVotosAptosSecao = int.Parse(row[9].ToString());
                else
                    secao.QuantVotosAptosSecao = int.Parse(row[8].ToString());


                if (secao.Municipio != 58890) //Rio das Flores
                    secao.QuantVotosAptosLocalVotacao = int.Parse(row[10].ToString());
                else
                    secao.QuantVotosAptosLocalVotacao = int.Parse(row[9].ToString());

                try
                {
                    base.Save(secao);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.ToString());
                }
                

                //save
            }

            ds.Dispose();
            ds = null;

            conexao.Dispose();
            conexao = null;

            da.Dispose();
            da = null;

            excel.Dispose();
            excel = null;

            secao = null;
        }

        /// <summary>
        /// Download do arquivo da internet
        /// </summary>
        /// <param name="url">URL do arquivo a ser baixado</param>
        /// <param name="nomeFisico">Nome que terá o arquivo após o download.</param>
        /// <returns>Boleando</returns>
        public bool Download(string url, string nomeFisico)
        {

            // Efetuando o download 
            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = new System.Text.ASCIIEncoding();
            client.DownloadFile(url, nomeFisico);
            client.Dispose();
            client = null;

            return true;
        }
    }
}
