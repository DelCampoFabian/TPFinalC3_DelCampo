<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col-2 mt-3 ">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <h4 class="text-center">Filtrar</h4>
                    <nav class="nav flex-column align-items-center">
                        <div>
                            <asp:CheckBox ID="cbCategoria" runat="server" OnCheckedChanged="cbCategoria_CheckedChanged" AutoPostBack="true" />
                            <label class="form-check-label">Categoria</label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select m-3 ">
                        </asp:DropDownList>
                    </nav>
                    <nav class="nav flex-column align-items-center">
                        <div>
                            <asp:CheckBox ID="cbMarca" runat="server" OnCheckedChanged="cbMarca_CheckedChanged" AutoPostBack="true" />
                            <label class="form-check-label">Marca</label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select m-3 ">
                        </asp:DropDownList>
                    </nav>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div>
                <asp:Button ID="btnAplican" CssClass="btn btn-primary m-3" runat="server" Text="Aplicar" OnClick="btnAplican_Click" />
            </div>
        </div>
        <div class="col-10">

            <div class="row g-2 mt-3">
                <asp:Repeater runat="server" ID="rpArticulos">
                    <ItemTemplate>
                        <div class="col-4">
                            <div class="card" style="width: 18rem;">
                                <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" alt="<%#Eval("Nombre")%>">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                    <p class="card-text"><%#Eval("Marca.Descripcion")%></p>
                                    <p class="card-text"><%#Eval("Precio")%>$</p>
                                    <a href="Detalle.aspx?id=<%#Eval("Id")%>" class="btn btn-primary">Detalle</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
