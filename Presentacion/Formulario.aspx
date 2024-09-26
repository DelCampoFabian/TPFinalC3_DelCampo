<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Presentacion.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row g-3 col-10 m-auto">
        <div class="col-6">
            <div class="col-md-12">
                <label for="txtID" class="form-label">ID</label>
                <asp:TextBox runat="server" ID="txtID" CssClass="form-control" />
            </div>
            <div class="col-md-12">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="col-md-12">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="col-md-12">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="col-md-12">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <div class="col-md-12">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <div class="container">
                <div class="row justify-content-between ">
                    <asp:Button Text="Aceptar" CssClass="btn btn-primary mt-4 col-3" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" />
                    <asp:Button Text="Eliminar" CssClass="btn btn-danger mt-4 col-3" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" />
                </div>
            </div>
            <%if (ConfirmaEliminar)
                {  %>
            <div class="mt-5">
                <h5 class="text-center">¿Desea eliminar el Articulo?</h5>
                <div class="row justify-content-center">
                    <asp:Button Text="Si" CssClass="btn btn-success mt-4 me-2 col-3" runat="server" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
                    <asp:Button Text="No" CssClass="btn btn-danger mt-4 ms-2 col-3" runat="server" ID="btnRechazar" OnClick="btnRechazar_Click" />
                </div>
            </div>
            <%} %>

        </div>
        <div class="col-6">
            <div class="col-12">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" />
            </div>
            <div class="col-md-12">
                <label for="txtImg" class="form-label">Imagen Url</label>
                <asp:TextBox runat="server" ID="txtImg" OnTextChanged="txtImg_TextChanged" AutoPostBack="true" CssClass="form-control" />
                <asp:Image ID="imgArticulo" ImageUrl="https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=" CssClass="img-fluid mt-2" Style="max-width: 400px" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
