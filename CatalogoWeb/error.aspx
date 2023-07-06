<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="CatalogoWeb.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .error{
            color:black;
            font-size:15px;
            justify-content:center
        }
        .error h2{
            color:red;
            font-size:35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error">
    <h2>Oh no! Hubo un problema</h2>
    <asp:Label ID="lblMensaje" runat="server" CssClass="form-label"></asp:Label>
    </div>
</asp:Content>
