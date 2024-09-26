<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="TablaArticulos.aspx.cs" Inherits="Presentacion.TablaArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-8 m-auto">
            <asp:GridView runat="server" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"  AutoGenerateColumns="false" ID="dgvArticulos" CssClass="table table-info table-dark mt-3">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />                     
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" /> 
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />     
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />     
                    <asp:BoundField HeaderText="Precio" DataField="Precio" /> 
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar"/>  
                </Columns>     
            </asp:GridView>
        </div>
    </div>
</asp:Content>
