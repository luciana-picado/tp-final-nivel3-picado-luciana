<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="favoritos.aspx.cs" Inherits="CatalogoWeb.favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="repFav" runat="server">
        <ItemTemplate>
            <div class="row row-cols-1 row-cols-md-2 g-4">
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("Articulo.ImagenUrl") %>" class="card-img-top" alt="<%#Eval("Articulo.Nombre") %>">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Articulo.Nombre")%></h5>
                            <p class="card-text"><%#Eval("Marca.Descripcion") %></p>
                            <p style="font-size:15px" class="card-text"><%#Eval("Categoria.Descripcion") %></p>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
