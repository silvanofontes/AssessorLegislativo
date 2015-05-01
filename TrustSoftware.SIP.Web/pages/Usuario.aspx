<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="Usuario.aspx.cs" Inherits="SilvanoFontes.AL.Web.pages.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <!--link href="https://cdn.datatables.net/1.10.6/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" /-->
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
          <h1>
            Usuarios
            <small></small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li class="active">Pages</li>
            <li class="active">Usuario</li>
          </ol>
    </section>
    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-header">
                    <h3 class="box-title">
                        Cadastro de usuários do sistema</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <table id="usuarios" class="table table-bordered table-hover table-striped">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>DataCad</th>
                                <th>Status</th>
                                <th>Face</th>
                                <th>Login</th>
                                <th>UltimoAcesso</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottonPage" runat="server">
    <!--script src="https://cdn.datatables.net/1.10.6/js/jquery.dataTables.min.js" type="text/javascript"></script-->
    <script src="../plugins/datatables/jquery.dataTables.js" type="text/javascript"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.js" type="text/javascript"></script>
    
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#usuarios').dataTable({
                "oLanguage": {
                  "oPaginate": {
                    "sFirst": "<<",
                    "sLast": ">>",
                    "sNext": "Próxima",
                    "sPrevious": "Anterior"
                    },
                "sEmptyTable": "Nenhum resultado",
                "sInfo": "Exibindo _START_ até _END_ do total de _TOTAL_ registros."
                },
                "sAjaxSource": "/api/usuario/all"
            });
        });
    </script>
</asp:Content>
