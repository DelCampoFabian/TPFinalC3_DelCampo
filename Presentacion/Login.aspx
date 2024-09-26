<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row col-5 mt-3 m-auto border">
        <h1 class="mt-3 mb-3">Login</h1>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtPassword" class="form-label">Password</label>
            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Button Text="Aceptar" CssClass="btn btn-primary mt-3" ID="btnLogear" OnClick="btnLogear_Click" runat="server" />

        
        </div>
    </div>
</asp:Content>
