<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPessoa.ascx.cs" Inherits="TrustSoftware.SIP.Web.Controles.UCPessoa" %>
<%@ Register Assembly="Ext.Net.UX" Namespace="Ext.Net.UX" TagPrefix="ux" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<ext:FormLayout ID="FormLayout1" runat="server">
    <Anchors>
        <ext:Anchor>
            <ext:FormPanel ID="FormPanel1" runat="server" Layout="FormLayout" AutoScroll="true"
                AnchorHorizontal="98.5%" Padding="5">
                <Items>
                    <ext:TextField ID="IdPessoa" runat="server" Text="0" />
                    <ext:TextField ID="txtNome" runat="server" FieldLabel="Nome" AnchorHorizontal="100%"
                        TabIndex="1" />
                    <ext:CompositeField ID="CompositeField1" runat="server" CausesValidation="false">
                        <Items>
                            <ext:Radio ID="Radio2" runat="server" BoxLabel="Feminino" Name="sexo" Checked="true" />
                            <ext:Radio ID="Radio1" runat="server" BoxLabel="Masculino" Name="sexo" />
                        </Items>
                    </ext:CompositeField>
                    <ext:TextArea ID="txtEndereco" runat="server" AnchorHorizontal="100%" TabIndex="1"
                        FieldLabel="Endereço" />
                    <ext:TextField ID="txtRG" runat="server" FieldLabel="Doc">
                        <DirectEvents>
                            <Change OnEvent="VerificaPessoa" />
                        </DirectEvents>
                        <Plugins>
                            <ux:InputTextMask ID="InputTextMask1" Mask="99.999.999-9" />
                        </Plugins>
                    </ext:TextField>
                    <ext:CompositeField ID="CompositeField2" runat="server" CausesValidation="false">
                        <Items>
                            <ext:Radio ID="Radio3" runat="server" BoxLabel="Casado(a)" Name="EstadoCivil" Checked="true" />
                            <ext:Radio ID="Radio4" runat="server" BoxLabel="Solteiro(a)" Name="EstadoCivil" />
                        </Items>
                    </ext:CompositeField>
                    <ext:TextField ID="txtEmail" runat="server" FieldLabel="E-Mail" AnchorHorizontal="60%"
                        Regex="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
                        RegexText="E-mail incorreto,favor colocar no padrão xxx@xxx.xxx" />
                    <ext:CompositeField ID="CompositeField3" runat="server" CausesValidation="false">
                        <Items>
                            <ext:TextField ID="txtTelefone" runat="server" FieldLabel="Telefone" Width="130" AnchorHorizontal="50%">
                                <Plugins>
                                    <ux:InputTextMask Mask="(999)9999-9999" ID="ctl221" />
                                </Plugins>
                            </ext:TextField>
                            <ext:TextField ID="txtCelular" runat="server" FieldLabel="Celular" Width="130" AnchorHorizontal="50%">
                                <Plugins>
                                    <ux:InputTextMask Mask="(999)9999-9999" ID="InputTextMask2" />
                                </Plugins>
                            </ext:TextField>
                        </Items>
                    </ext:CompositeField>
                    <ext:DateField ID="dt_Nascimento" runat="server" FieldLabel="Data de Nascimento "
                        AnchorHorizontal="60%">
                        <Plugins>
                            <ux:InputTextMask Mask="99/99/9999" />
                        </Plugins>
                    </ext:DateField>
                </Items>
                <CustomConfig>
                    <ext:ConfigItem Name="width" Value="100%" Mode="Value" />
                </CustomConfig>
            </ext:FormPanel>
        </ext:Anchor>
    </Anchors>
</ext:FormLayout>
