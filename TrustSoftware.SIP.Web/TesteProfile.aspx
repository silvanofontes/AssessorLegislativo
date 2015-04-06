<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="TesteProfile.aspx.cs" Inherits="SilvanoFontes.AL.Web.TesteProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- daterange picker -->
    <link href="plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />
    <link href="plugins/jasny-bootstrap/css/jasny-bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="plugins/switch-button/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
          <h1>
            Cadastro de Eleitor
            <small>Optional description</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li class="active">Perfil</li>
          </ol>
    </section>
    <div id="panel" class="profile">
        <form runat="server">
        <div class="row">
            <div class="col-md-3">
                <div class="box">
                    <div class="box-header with-border">
                        <h3 class="box-title">
                            Perfil</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <center>
                            <div class="fileinput fileinput-new" data-provides="fileinput">
                                <div class="fileinput-new thumbnail" style="width: 150px; height: 150px;">
                                    <img data-src="holder.js/100%x100%" src="image/noprofileimage.jpg">
                                </div>
                                <div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px;
                                    max-height: 150px;">
                                </div>
                                <div>
                                    <span class="btn btn-default btn-file"><span class="fileinput-new">Selecionar imagem</span>
                                        <span class="fileinput-exists">Alterar</span>
                                        <asp:FileUpload ID="arquivo" runat="server" name="..." />
                                    </span><a href="#" class="btn btn-default fileinput-exists" data-dismiss="fileinput">
                                        Remover</a>
                                </div>
                            </div>
                        </center>
                        <div class="form-group">
                            <label>
                                Eleitor?</label>
                            <!--input id="Checkbox1" type="checkbox"  checked data-on-text="Sim" data-off-text="Não" data-on-color="success" data-off-color="danger"-->
                            <asp:CheckBox runat="server" ID="switchEleitor" Checked data-on-text="Sim" data-off-text="Não" data-on-color="success" data-off-color="danger" />
                        </div>
                        <div class="row">
                            <div class="col-md-10">
                                <label>
                                    Título</label>
                                <asp:TextBox runat="server" ID="txtTitulo" class="form-control" placeholder="Número do Título"
                                    data-toggle="tooltip" title="" data-original-title="Será utilizado para acompanhar a data de vencimento."></asp:TextBox>
                            </div>
                            <div class="col-md-5">
                                <label>
                                    Zona</label>
                                <asp:TextBox ID="txtZona" runat="server" class="form-control" placeholder="Zona"></asp:TextBox>
                            </div>
                            <div class="col-md-5">
                                <label>
                                    Seção</label>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Seção"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <div class="col-md-9">
                <div class="box">
                    <div class="box-body">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-9">
                                    <label>
                                        Nome</label>
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Informe o nome"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>
                                        Date de nascimento:</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-birthday-cake"></i>
                                        </div>
                                        <asp:TextBox ID="TextBox7" runat="server" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'"
                                            data-mask></asp:TextBox>
                                    </div>
                                    <!-- /.input group -->
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-9">
                                    <label>
                                        Endereço e número</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-home"></i>
                                        </div>
                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="Nome da rua/travessa/avenida, o número e o complemento (apto, casa)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label>
                                        Bairro</label>
                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control" placeholder="Bairro"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-3">
                                    <label>
                                        CEP</label>
                                    <asp:TextBox ID="TextBox5" runat="server" class="form-control" placeholder="CEP"
                                        data-inputmask='"mask": "99999-999"' data-mask></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>
                                        Estado</label>
                                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" placeholder="UF">
                                        <asp:ListItem Selected Text="RJ">RJ</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label>
                                        Cidade</label>
                                    <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" placeholder="Cidade">
                                        <asp:ListItem Selected Text="Niterói">Niterói</asp:ListItem>
                                        <asp:ListItem Text="São Gonçalo">São Gonçalo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>
                                Email</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-envelope-o"></i>
                                </div>
                                <asp:TextBox ID="TextBox6" runat="server" class="form-control" placeholder="seu@email.com.br"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>
                                Telefones:</label>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-phone"></i>
                                        </div>
                                        <asp:TextBox ID="TextBox9" runat="server" class="form-control" placeholder="Residencial"
                                            data-inputmask='"mask": "(999) 9999-9999"' data-mask></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-mobile-phone fa-lg"></i>
                                        </div>
                                        <asp:TextBox ID="TextBox10" runat="server" class="form-control" placeholder="Celular"
                                            data-inputmask='"mask": "(999) [9]9999-9999"' data-mask></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <div class="input-group-addon bg-green">
                                            <i class="fa fa-whatsapp fa-lg"></i>
                                        </div>
                                        <asp:TextBox ID="TextBox11" runat="server" class="form-control" placeholder="WhatsApp"
                                            data-inputmask='"mask": "(999) [9]9999-9999"' data-mask data-toggle="tooltip"
                                            data-placement="top" data-original-title="Se for o mesmo celular, repita aqui."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>
                                Profissão</label>
                            <asp:TextBox ID="TextBox8" runat="server" class="form-control" placeholder="Informe profissão."></asp:TextBox>
                        </div>
                        <!-- /.form group -->
                        <div class="form-group action">
                            <asp:Button runat="server" ID="benSalvar" class="btn btn-primary" Text="Salvar" />
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
        </div>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottonPage" runat="server">
    <script src="plugins/jasny-bootstrap/js/jasny-fileinput.js" type="text/javascript"></script>
    <script src="plugins/input-mask/jquery.inputmask.js" type="text/javascript"></script>
    <script src="plugins/input-mask/jquery.inputmask.date.extensions.js" type="text/javascript"></script>
    <script src="plugins/input-mask/jquery.inputmask.extensions.js" type="text/javascript"></script>

    <script src="plugins/switch-button/highlight.js" type="text/javascript"></script>
    <script src="plugins/switch-button/main.js" type="text/javascript"></script>
    <script src="plugins/switch-button/bootstrap-switch.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //Datemask dd/mm/yyyy
            $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });

            $("[data-mask]").inputmask();

            $("[name='switchEleitor']").bootstrapSwitch();


        });
    </script>
</asp:Content>
