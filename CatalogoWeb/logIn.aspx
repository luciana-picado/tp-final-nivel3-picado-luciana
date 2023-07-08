<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="CatalogoWeb.logIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validar {
            color: red;
            font-size: 12px;
            font-style: italic;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Logueate</h2>

    <div class="row">

        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblUser" CssClass="form-label" runat="server" Text="User"></asp:Label>
                <asp:TextBox ID="txtUser" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validar" runat="server" ControlToValidate="txtUser" ErrorMessage="Debes introducir un email"></asp:RequiredFieldValidator>

            </div>
            <div class="mb-3">
                <asp:Label ID="lblPassword" CssClass="form-label" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                <a href="olvidoPass.aspx">Olvidé mi contraseña</a>
                <asp:RequiredFieldValidator CssClass="validar" runat="server" ControlToValidate="txtPassword" ErrorMessage="Debes introducir una contraseña"></asp:RequiredFieldValidator>

            </div>
            <div class="mb-3">
                <asp:Button ID="btnIngresar" CssClass="btn btn-primary" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
                <a href="default.aspx" class="btn btn-primary">Cancelar</a>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label ID="lblAunNo" runat="server" Text="¿Todavia no te registraste?"></asp:Label>
                <label>Registrate haciendo clic <a href="registro.aspx">aqui</a> </label>
            </div>
        </div>
    </div>
</asp:Content>
