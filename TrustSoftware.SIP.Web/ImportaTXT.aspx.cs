using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Business;
using SilvanoFontes.AL.Business.Import;
using System.Configuration;
using SilvanoFontes.AL.Utility.Enums;
using Ext.Net;
using SilvanoFontes.AL.Business.Parametros;
using System.Web.Script.Serialization;

namespace SilvanoFontes.AL.Web
{
    public class Retorno
    {
        //abc
        public virtual int sEcho { get; set; }
        public virtual int iTotalRecords { get; set; }
        public virtual int iTotalDisplayRecords { get; set; }
        public virtual object[] aaData { get; set; }
    }
    public class PersonDetails
    {
        public int ID;
        public string FirstName;
        public string MiddleName;
        public int Age;
        public string Gender;
    }



    public partial class ImportaTXTPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Retorno ret = new Retorno();
            List<PersonDetails> list = new List<PersonDetails>();
            list.Add(new PersonDetails() { Age = 10, FirstName = "Silvano", Gender = "Lana", ID = 1, MiddleName = "Fontes" });
            list.Add(new PersonDetails() { Age = 10, FirstName = "Bruno", Gender = "Lana", ID = 2, MiddleName = "Gabriel" });
            list.Add(new PersonDetails() { Age = 10, FirstName = "João", Gender = "Lana", ID = 3, MiddleName = "Pedro" });
            list.Add(new PersonDetails() { Age = 10, FirstName = "Lana", Gender = "Silvano", ID = 4, MiddleName = "Fontes" });

            //ret.draw = 1;
            //ret.recordsFiltered = 4;
            //ret.recordsTotal = 4;
            ret.aaData = list.ToArray();

            string _JSON = new JavaScriptSerializer().Serialize(ret);

        }

        public void ImportaCandidatura(object sender, DirectEventArgs e)
        {
            ImportaCandidatura impCandidatura = new ImportaCandidatura(new Usuario());
            impCandidatura.Import(2);
        }

        public void ImportaMunicipio(object sender, DirectEventArgs e)
        {
            ImportaMunicipio imp = new ImportaMunicipio();

            try
            {
                imp.Import(1);
            }
            catch (Exception ex)
            {
                X.AddScript("alert('ERRO: " + ex.InnerException + "')");
                throw;
            }
            finally
            {
                imp.Dispose();
                imp = null;
                X.AddScript("alert('Ok')");
            }


        }

        public void ImportaBensCandidato(object sender, DirectEventArgs e)
        {
            ImportaBensCandidato impBens = new ImportaBensCandidato(0);
            impBens.Import(3);

            impBens.Dispose();
            impBens = null;
        }


        public void ImportaPerfilDoEleitorado(object sender, DirectEventArgs e)
        {
            ImportaPerfilDoEleitorado impPerfil = new ImportaPerfilDoEleitorado(0);
            impPerfil.Import(4);

            impPerfil.Dispose();
            impPerfil = null;
        }

        public void ImportaZona(object sender, DirectEventArgs e)
        {
            ImportaZona importa = new ImportaZona(0);
            importa.Import(5);

            importa.Dispose();
            importa = null;
        }

        public void ImportacaoVotoCandiatoPorSecao(object sender, DirectEventArgs e)
        {
            ImportacaoVotoCandiatoPorSecao importa = new ImportacaoVotoCandiatoPorSecao(0);
            importa.Import(6);

            importa.Dispose();
            importa = null;
        }

        public void ImportaDetalheVotoPorSecao(object sender, DirectEventArgs e)
        {
            ImportaDetalheVotoPorSecao importa = new ImportaDetalheVotoPorSecao(0);
            importa.Import(7);

            importa.Dispose();
            importa = null;
        }
        

        public void ImportaTabelaArquivos(object sender, DirectEventArgs e)
        {
            ArquivoNeg negArquivo = new ArquivoNeg();

            negArquivo.VerificaSalva(new Arquivo() { Nome = "Municipios TSE", Descricao = "Lista de municípios com os códogos do TSE", NomeArquivo = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\lista_municipios_justica_eleitoral.txt", Fonte = "http://www.tse.jus.br/arquivos/tse-lista-de-municipios-do-cadastro-da-justica-eleitoral/at_download/file" });
            negArquivo.VerificaSalva(new Arquivo() { Nome = "Consulta Candidatura", Descricao = "Candidatura dos candidatos", NomeArquivo = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\consulta_cand_2012_RJ.txt", Fonte = "http://agencia.tse.jus.br/estatistica/sead/odsele/consulta_cand/consulta_cand_2012.zip" });
            negArquivo.VerificaSalva(new Arquivo() { Nome = "Bens do Candidato", Descricao = "Declaração de bens do candidato", NomeArquivo = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\bem_candidato_2012_RJ.txt", Fonte = "http://agencia.tse.jus.br/estatistica/sead/odsele/bem_candidato/bem_candidato_2012.zip" });
            negArquivo.VerificaSalva(new Arquivo() { Nome = "Perfil do Eleitorado", Descricao = "Perfil do eleirorado", NomeArquivo = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\perfil_eleitorado_2012.txt", Fonte = "http://agencia.tse.jus.br/estatistica/sead/odsele/perfil_eleitorado/perfil_eleitorado_2012.zip" });
            negArquivo.VerificaSalva(new Arquivo() { Nome = "Zonas Eleitorais RJ", Descricao = "Zonas eleitorais do estado do Rio de Janeiro", NomeArquivo = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\zonas_RJ.txt", Fonte = "http://inter04.tse.jus.br/ords/dwtse/f?p=600:19:2472642731028246:FLOW_EXCEL_OUTPUT_R9269611968683063_pt-br" });
            negArquivo.VerificaSalva(new Arquivo() { Nome = "Voto Candidato por Secao", Descricao = "Votação do candidato por seção eleitoral", NomeArquivo = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\votacao_secao_2012_RJ.txt", Fonte = "http://agencia.tse.jus.br/estatistica/sead/eleicoes/eleicoes2012/votosecao/vsec_1t_RJ.zip" });
            negArquivo.VerificaSalva(new Arquivo() { Nome = "Detalhe Voto por Secao", Descricao = "Detalhe da votação por seção eleitoral", NomeArquivo = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\detalhe_votacao_secao_2012_RJ.txt", Fonte = "http://agencia.tse.jus.br/estatistica/sead/odsele/detalhe_votacao_secao/detalhe_votacao_secao_2012.zip" });
            
            negArquivo.VerificaSalva(new Arquivo() { Nome = "HTML Endereco Secao RJ", Descricao = "HTML Endereco Secao RJ", NomeArquivo = @"E:\Silvano\Sites - Particulares\AssessorLegislativo\Arquivos\Download\lista_secao_municipio_RJ.html", Fonte = "http://www.tre-rj.jus.br/site/eleicoes/2012/local_votacao/lista_locais_votacao.jsp?keepThis=true&" });

            ///TODO: Ainda não importado
            negArquivo.VerificaSalva(new Arquivo() { Nome = "CSV Endereco Secao SP", Descricao = "CSV Endereco Secao SP", NomeArquivo = @"E:\Silvano\Sites - Particulares\AssessorLegislativo\Arquivos\Download\lista_secao_municipio_SP.csv", Fonte = "http://apps.tre-sp.jus.br/Proxy/proxy/eleitoradosp/ViewLocalVotacao/listarTodosPorZE.do" });

            negArquivo.Dispose();
            negArquivo = null;

        }

        public void DownloadHTMLSecao(object sender, DirectEventArgs e)
        {
            ImportaEnderecoSecaoRJ importa = new ImportaEnderecoSecaoRJ(0);

            importa.DownloadListaSecoesHTML(8);
            importa = null;
        }

        public void ImportaEstados(object sender, DirectEventArgs e)
        {
            EstadoNeg negEstado = new EstadoNeg();

            negEstado.Save(new Estado() { Id = 11, UF = "RO", Nome = "RONDÔNIA" });
            negEstado.Save(new Estado() { Id = 12, UF = "AC", Nome = "ACRE" });
            negEstado.Save(new Estado() { Id = 13, UF = "AM", Nome = "AMAZONAS" });
            negEstado.Save(new Estado() { Id = 14, UF = "RR", Nome = "RORAIMA" });
            negEstado.Save(new Estado() { Id = 15, UF = "PA", Nome = "PARÁ" });
            negEstado.Save(new Estado() { Id = 16, UF = "AP", Nome = "AMAPÁ" });
            negEstado.Save(new Estado() { Id = 17, UF = "TO", Nome = "TOCANTINS" });
            negEstado.Save(new Estado() { Id = 21, UF = "MA", Nome = "MARANHÃO" });
            negEstado.Save(new Estado() { Id = 22, UF = "PI", Nome = "PIAUÍ" });
            negEstado.Save(new Estado() { Id = 23, UF = "CE", Nome = "CEARÁ" });
            negEstado.Save(new Estado() { Id = 24, UF = "RN", Nome = "RIO GRANDE DO NORTE" });
            negEstado.Save(new Estado() { Id = 25, UF = "PB", Nome = "PARAÍBA" });
            negEstado.Save(new Estado() { Id = 26, UF = "PE", Nome = "PERNAMBUCO" });
            negEstado.Save(new Estado() { Id = 27, UF = "AL", Nome = "ALAGOAS" });
            negEstado.Save(new Estado() { Id = 28, UF = "SE", Nome = "SERGIPE" });
            negEstado.Save(new Estado() { Id = 29, UF = "BA", Nome = "BAHIA" });
            negEstado.Save(new Estado() { Id = 31, UF = "MG", Nome = "MINAS GERAIS" });
            negEstado.Save(new Estado() { Id = 32, UF = "ES", Nome = "ESPÍRITO SANTO" });
            negEstado.Save(new Estado() { Id = 33, UF = "RJ", Nome = "RIO DE JANEIRO" });
            negEstado.Save(new Estado() { Id = 35, UF = "SP", Nome = "SÃO PAULO" });
            negEstado.Save(new Estado() { Id = 41, UF = "PR", Nome = "PARANÁ" });
            negEstado.Save(new Estado() { Id = 42, UF = "SC", Nome = "SANTA CATARINA" });
            negEstado.Save(new Estado() { Id = 43, UF = "RS", Nome = "RIO GRANDE DO SUL" });
            negEstado.Save(new Estado() { Id = 50, UF = "MS", Nome = "MATO GROSSO DO SUL" });
            negEstado.Save(new Estado() { Id = 51, UF = "MT", Nome = "MATO GROSSO" });
            negEstado.Save(new Estado() { Id = 52, UF = "GO", Nome = "GOIÁS" });
            negEstado.Save(new Estado() { Id = 53, UF = "DF", Nome = "DISTRITO FEDERAL" });
            negEstado.Save(new Estado() { Id = 98, UF = "VT", Nome = "VOTO EM TRÂNSITO" });
            negEstado.Save(new Estado() { Id = 99, UF = "ZZ", Nome = "DISTRITO FEDERAL" });
            negEstado.Save(new Estado() { Id = 100, UF = "BR", Nome = "BRASIL" });
            negEstado.Dispose();
            negEstado = null;
        }

        public void AtualizarBanco(object sender, DirectEventArgs e)
        {
            new ImportaMunicipio().DBMaintenance(DBAction.Update);
        }

        public void BaixaArquivo(object sender, DirectEventArgs e)
        {


            // Obtendo URL do arquivo a ser baixado e caminho de destino // do mesmo 
            string urlArquivo;
            //urlArquivo = "http://agencia.tse.jus.br/estatistica/sead/odsele/perfil_eleitorado/perfil_eleitorado_2012.zip";
            urlArquivo = "http://inter04.tse.jus.br/ords/dwtse/f?p=600:19:2472642731028246:FLOW_EXCEL_OUTPUT_R9269611968683063_pt-br";
            string caminhoArquivo = @"E:\Silvano\Sites - Particulares\AssessorLegislativo\Arquivos\Download\zona_RJ.csv";
            // Outras instruções de código... 

            // Efetuando o download 
            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = new System.Text.ASCIIEncoding();
            client.DownloadFile(urlArquivo, caminhoArquivo);

        }

    }
}