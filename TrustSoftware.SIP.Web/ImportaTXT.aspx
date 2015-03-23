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
    <ext:Button ID="btn_Salvar" runat="server" Scale="Large" IconAlign="Right" Text="Importar"
        ToolTip="Importar TXT" Icon="Disk">
        <DirectEvents>
            <Click OnEvent="Importar">
                <EventMask ShowMask="true" Msg="Importando..." MinDelay="500" Target="Page" />
            </Click>
        </DirectEvents>
    </ext:Button>
    </form>
</body>
</html>
