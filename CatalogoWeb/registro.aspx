<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="CatalogoWeb.registro" %>

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
    <h2>Creá tu perfil</h2>

    <div class="row">

        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblUser" CssClass="form-label" runat="server" Text="User"></asp:Label>
                <asp:TextBox ID="txtUser" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validar" runat="server" ErrorMessage="Debes ingresar un email con su formato correspondiente" ControlToValidate="txtUser" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblPassword" CssClass="form-label" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validar" runat="server" ErrorMessage="Debea ingresar un password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>

            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegistrarse" CssClass="btn btn-primary" runat="server" OnClick="btnRegistrarse_Click" Text="Registrarse" />
                <a href="default.aspx" class="btn btn-primary">Cancelar</a>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <div class="mb-3">
                <asp:Label ID="lblYaTenes" runat="server" Text="¿Ya tenes un usuario?"></asp:Label>
                <a href="logIn.aspx">Ingresa aqui</a>
            </div>
        </div>
    </div>
</asp:Content>
