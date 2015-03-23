<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teste.aspx.cs" Inherits="TrustSoftware.SIP.Web.Teste" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="~/Controles/UCPessoa.ascx" TagName="FormPessoa" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no" />

</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Region="North" Margins="2 2 2 2" ButtonAlign="Left"
                BodyBorder="false">
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server" Flat="true">
                        <Items>
                            <ext:Label runat="server" ID="lblCabecalho">
                            </ext:Label>
                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                            <ext:Button ID="btnLimpar" runat="server" IconAlign="Right" Text="Limpar" ToolTip="Limpar campos"
                                Icon="Erase">
                                <Listeners>
                                    <Click Handler="Ext.net.DirectMethods.LimparCampos();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btn_Incuir" Icon="Report" IconAlign="Right" runat="server" ToolTip="Listagem de usuários"
                                Text="Listagem">
                                <Listeners>
                                    <Click Handler="Voltar()" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btn_Salvar" runat="server" IconAlign="Right" Text="Salvar" ToolTip="Salvar usuário"
                                Icon="Disk">
                                <Listeners>
                                    <Click Handler="if (#{FormPanel1}.getForm().isValid()) {Ext.net.DirectMethods.btnSalvar_Click();}else{Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: 'Campos em vermelho são obrigatórios!', buttons:Ext.Msg.OK});}" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
            </ext:Panel>
            <ext:FormPanel ID="FormPanel1" runat="server" Title="Cadastro de Usuario" Region="Center" AutoScroll="true" Border="false">
                <Content>
                    <uc1:FormPessoa ID="EntidadePessoa" runat="server" />
                </Content>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
