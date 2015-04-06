<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportaTXTPage.aspx.cs"
    Inherits="SilvanoFontes.AL.Web.ImportaTXTPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <br />
    <ext:Button ID="btnImportaArquivos" runat="server" Scale="Large" IconAlign="Right"
        Text="Carga tabela Arquivos" ToolTip="Importar tabela arquivo" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="ImportaTabelaArquivos" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando arquivos..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    <br />
    <ext:Button ID="btnImportaEstados" runat="server" Scale="Large" IconAlign="Right"
        Text="Carga Estados" ToolTip="Importar estados" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="ImportaEstados" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando estados..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    <br />
    <ext:Button ID="btnImportarMunicipio" runat="server" Scale="Large" IconAlign="Right"
        Text="Importar MUNICIPIOS" ToolTip="Importar TXT" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="ImportaMunicipio" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando Municipio..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    <br />
    <br />
    <ext:Button ID="btnImportaCandidatura" runat="server" Scale="Large" IconAlign="Right"
        Text="Importar CANDIDATURA" ToolTip="Importar TXT" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="ImportaCandidatura" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando Candidaturas..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    <br />
    <ext:Button ID="btnImportaBensCandidato" runat="server" Scale="Large" IconAlign="Right" Text="Importar Bens do Candidato"
        ToolTip="Importar TXT" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="ImportaBensCandidato" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando Declaração de bens..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    <br />
    <ext:Button ID="btnImportaPerfil" runat="server" Scale="Large" IconAlign="Right" Text="Importar perfil do eleitorado"
        ToolTip="Importar Perfil do Eleitorado" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="ImportaPerfilDoEleitorado" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando Perfil do Eleitorado..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    <br />
    <ext:Button ID="btnZona" runat="server" Scale="Large" IconAlign="Right" Text="Importar Zonas Eleitorais"
        ToolTip="Importar Zonas Eleitorais" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="ImportaZona" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando Perfil do Eleitorado..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    <br />
    <ext:Button ID="btnImportacaoVotoCandiatoPorSecao" runat="server" Scale="Large" IconAlign="Right" Text="Votoacao Candiato Por Secao"
        ToolTip="Importar Zonas Eleitorais" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="ImportacaoVotoCandiatoPorSecao" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando Perfil do Eleitorado..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    
    <br />
    <ext:Button ID="btnImportaDetalheVotoPorSecao" runat="server" Scale="Large" IconAlign="Right" Text="Detalhe Votação por Seção"
        ToolTip="Importar Detalhe por seção" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="ImportaDetalheVotoPorSecao" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando Detalhe por Seção..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    <br />
    
    <ext:Button ID="btnDownloadHTMLSecao" runat="server" Scale="Large" IconAlign="Right" Text="Importa HTML Secao"
        ToolTip="Importa HTML Secao" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="DownloadHTMLSecao" Timeout="100000">
                <EventMask ShowMask="true" Msg="Importando HTML Seção..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    
    <br />
    <h1>
        ATENÇÃO</h1>
    <br />
    <ext:Button ID="btnAtualizaBanco" runat="server" Scale="Large" IconAlign="Right"
        Text="Atualizar Banco" ToolTip="Importar TXT" Icon="Reload">
        <DirectEvents>
            <Click OnEvent="AtualizarBanco" Timeout="100000">
                <EventMask ShowMask="true" Msg="Atualizando..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    <ext:Button ID="btnDownload" runat="server" Scale="Large" IconAlign="Right"
        Text="baixar arquivo" ToolTip="Importar TXT" Icon="DiskDownload">
        <DirectEvents>
            <Click OnEvent="BaixaArquivo" Timeout="100000">
                <EventMask ShowMask="true" Msg="Fzendo download..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    
    </form>
</body>
</html>
