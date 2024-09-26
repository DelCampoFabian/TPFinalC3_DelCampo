<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Presentacion.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Detalle del producto</h1>
    <div class="row">
        <div class="d-flex justify-content-center">
            <div class="pe-4">
                <asp:Image ID="imgDetalle" CssClass="img-fluid" runat="server" />
            </div>
            <div class="d-flex flex-column ps-4">
                <asp:Label ID="lblNombre" cssClass="fs-1 fw-bold" runat="server" Text=""></asp:Label>
                <div>
                    <span class="fs-3 fw-semibold">Codigo:</span>
                    <asp:Label ID="lblCodigo" CssClass="fs-3 fw-semibold" runat="server" Text=""></asp:Label>
                </div>
                <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
                <div>
                    <span Class="fs-3 fw-semibold">Precio:</span>
                    <asp:Label ID="lblPrecio" CssClass="fs-3 fw-semibold" runat="server" Text=""></asp:Label>
                </div>
                <div class="mt-3">
                    <asp:Label ID="lblCategoria" CssClass="bg-info-subtle text-dark p-2 me-3" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblMarca" CssClass="bg-warning-subtle p-2" runat="server" Text=""></asp:Label>

                </div>
            </div>
        </div>
            
            
    </div>
</asp:Content>
