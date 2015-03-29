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

namespace SilvanoFontes.AL.Web
{
    public partial class ImportaTXTPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ImportaCandidatura(object sender, DirectEventArgs e)
        {
            ImportaCandidatura impCandidatura = new ImportaCandidatura(0);
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
            impBens.Import(2);
        }

        public void ImportaTabelaArquivos(object sender, DirectEventArgs e)
        {
            ArquivoNeg negArquivo = new ArquivoNeg();

            negArquivo.Save(new Arquivo() { Nome = "Municipios TSE", Descricao = "Lista de municípios com os códogos do TSE", NomeArquivo = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\lista_municipios_TSE.txt", Fonte = "http://www.tse.jus.br/arquivos/tse-lista-de-municipios-do-cadastro-da-justica-eleitoral/at_download/file" });
            negArquivo.Save(new Arquivo() { Nome = "Consulta Candidatura", Descricao = "Candidatura dos candidatos", NomeArquivo = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\consulta_cand_2012_RJ.txt", Fonte = "http://agencia.tse.jus.br/estatistica/sead/odsele/consulta_cand/consulta_cand_2012.zip" });

            negArquivo.Dispose();
            negArquivo = null;

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

            negEstado.Dispose();
            negEstado = null;
        }

        public void AtualizarBanco(object sender, DirectEventArgs e)
        {
            new ImportaMunicipio().DBMaintenance(DBAction.Update);
        }

    }
}