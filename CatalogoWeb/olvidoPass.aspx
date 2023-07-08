<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="olvidoPass.aspx.cs" Inherits="CatalogoWeb.olvidoPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Olvidaste tu contraseña?</h2>
            <h1>Olvidaste tu contraseña?</h1>
        <div class="col-4">
            <div class="mb-3">
                <asp:Label ID="lblIngresá" CssClass="form-label" runat="server" Text="Ingresá tu email:"></asp:Label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-primary" OnClick="btnEnviar_Click" Text="Enviar" />
            <a href="logIn.aspx" class="btn btn-primary">Volver</a>
        </div>
        <asp:Label ID="lblProx" Visible="false" runat="server" Text="Pagina en mantenimiento... proximamente"></asp:Label>
    </div>
</asp:Content>
