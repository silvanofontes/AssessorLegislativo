<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="TesteProfile.aspx.cs" Inherits="SilvanoFontes.AL.Web.TesteProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- daterange picker -->
    <link href="plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />
    <link href="plugins/jasny-bootstrap/css/jasny-bootstrap.min.css" rel="stylesheet"
        type="text/css" />
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
                        <div class="row">
                            <div class="col-md-10">
                                <label>
                                    Título</label>
                                <input type="text" class="form-control" placeholder="Número do Título" data-toggle="tooltip"
                                    title="" data-original-title="Será utilizado para acompanhar a data de vencimento." />
                            </div>
                            <div class="col-md-5">
                                <label>
                                    Zona</label>
                                <input type="text" class="form-control" placeholder="Zona" />
                            </div>
                            <div class="col-md-5">
                                <label>
                                    Seção</label>
                                <input type="text" class="form-control" placeholder="Seção" />
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
                            <label>
                                Nome</label>
                            <input type="nome" class="form-control" placeholder="Informe o nome" />
                        </div>
                        <div class="form-group">
                            <label>
                                Email</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-envelope-o"></i>
                                </div>
                                <input type="email" class="form-control" placeholder="seu@email.com.br" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label>
                                Endereço e número</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-home"></i>
                                </div>
                                <input type="text" class="form-control" placeholder="Informe o nome da rua e número." />
                            </div>
                        </div>
                        <div class="form-group">
                            <label>
                                CEP</label>
                            <input type="text" class="form-control" placeholder="CEP" data-inputmask='"mask": "99999-999"'
                                data-mask />
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-3">
                                    <label>
                                        Estado</label>
                                    <select class="form-control" placeholder="UF">
                                        <option selected>RJ</option>
                                    </select>
                                </div>
                                <div class="col-xs-5">
                                    <label>
                                        Cidade</label>
                                    <select class="form-control" placeholder="Cidade">
                                        <option selected>Niterói</option>
                                        <option>São Gonçalo</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>
                                Date de nascimento:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask />
                            </div>
                            <!-- /.input group -->
                        </div>
                        <div class="form-group">
                            <label>
                                Profissão</label>
                            <input type="text" class="form-control" placeholder="Informe profissão." />
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
                                        <input type="text" class="form-control" placeholder="Residencial" data-inputmask='"mask": "(999) 9999-9999"'
                                            data-mask />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-mobile-phone"></i>
                                        </div>
                                        <input type="text" class="form-control" placeholder="Celular" data-inputmask='"mask": "(999) [9]9999-9999"'
                                            data-mask />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-whatsapp"></i>
                                        </div>
                                        <input type="text" class="form-control" placeholder="WhatsApp" data-inputmask='"mask": "(999) [9]9999-9999"'
                                            data-mask data-toggle="tooltip" data-placement="top" data-original-title="Se for o mesmo celular, repita aqui." />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.form group -->
                        <div class="form-group action">
                            <input type="submit" class="btn btn-success" value="Salvar" />
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
    <script type="text/javascript">
        $(function () {
            //Datemask dd/mm/yyyy
            $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });

            $("[data-mask]").inputmask();



        });
    </script>
</asp:Content>
