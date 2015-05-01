<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MBL-ImageEditor.aspx.cs"
    Inherits="SilvanoFontes.AL.Web.MBL_ImageEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="Label3" Text="Cidade: " ToolTip="Ex: São Paulo"></asp:Label>
        <asp:TextBox ID="txtCidade" runat="server" Text=""></asp:TextBox>        
        <br />
        <asp:Label runat="server" ID="Label2" Text="Local do evento: "></asp:Label>
        <asp:TextBox ID="txtLocal" runat="server" Text="" ToolTip="Ex: Av. Paulista/Masp"></asp:TextBox>
        <br />
        <asp:Label runat="server" ID="Label1" Text="Horário do evento: "></asp:Label>
        <asp:TextBox ID="txtHorario" runat="server" Text="" ToolTip="Ex: às 14h"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="AdicionarTexto" Text="Gerar Banner" />
        <br />
        <br />
        <asp:Image ID="imagem" runat="server" ImageUrl="image/Banner.png" /><br />
        <asp:Label runat="server" ID="ImageInfo" ></asp:Label>
    </div>
    </form>
</body>
</html>
