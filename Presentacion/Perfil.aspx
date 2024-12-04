<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Presentacion.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style>
      .CampoRequerido{
          color: #ff5555;
          font-size: 12px;
      }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="fs-2 m-3 text-center">Mi Perfil</h1>
    <div class="row d-flex justify-content-center">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"  />
                <asp:RequiredFieldValidator cssClass="CampoRequerido" ErrorMessage="Campo obligatorio" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator cssClass="CampoRequerido" ErrorMessage="Campo obligatorio" ControlToValidate="txtApellido" runat="server" />     
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary"  runat="server" />
                    <a href="Default.aspx">Regresar</a>
                </div>
            </div>

        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input ID="txtImagen" type="file" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil" runat="server" CssClass="img-fluid" />
        </div>

    </div>
</asp:Content>
