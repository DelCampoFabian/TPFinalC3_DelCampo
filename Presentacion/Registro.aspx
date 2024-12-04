<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Presentacion.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
     .CampoObligatorio{
         font-size: 12px;
         color: #ff5555;
     }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row col-5 mt-3 m-auto border">
        <h1 class="text-center fs-2 m-3">Registrarse</h1>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="CampoObligatorio" ErrorMessage="Campo obligatorio" ControlToValidate="txtEmail" runat="server" />
            <asp:RegularExpressionValidator CssClass="CampoObligatorio" ErrorMessage="Ingresé un email" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtPassword" class="form-label">Password</label>
            <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator  CssClass="CampoObligatorio" ErrorMessage="Campo obligatorio" ControlToValidate="txtPassword" runat="server" />
            <asp:Button Text="Registrarse" CssClass="btn btn-primary mt-3" ID="btnRegistro" OnClick="btnRegistro_Click" runat="server" />
        </div>
    </div>
</asp:Content>
