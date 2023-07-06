<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="lista.aspx.cs" Inherits="CatalogoWeb.lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView DataKeyNames="Id" AllowPaging="true" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" CssClass="table table-dark table-striped-columns" ID="dgvArticulos" runat="server"  AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
