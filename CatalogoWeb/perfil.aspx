<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="CatalogoWeb.perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validar{
            color:red;
            font-size:12px;
            font-style:italic;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Mi perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" CssClass="form-label" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblApellido" runat="server" CssClass="form-label" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label ID="lblImgPerfil" runat="server" CssClass="form-label" Text="Imagen de perfil"></asp:Label>
                <input id="inpImagenPerfil" class="form-control" runat="server" type="file" />
                <div>
                    <asp:Image ID="imgImagenPerfil" ImageUrl="data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBw8ODw0ODQ0QDhANDw8NDw8ODQ8NDw0PFREWFhURFRUYHSggGBolGxUTITEhJSkrLi4uFx8zODMtNygtLisBCgoKBQUFDgUFDisZExkrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrK//AABEIAOEA4QMBIgACEQEDEQH/xAAaAAEBAQEBAQEAAAAAAAAAAAAAAQIEAwUH/8QALRABAAIBAgQFAwMFAAAAAAAAAAERAgMEITFRYRJBcbHwUoGRMqHRIkKS4fH/xAAUAQEAAAAAAAAAAAAAAAAAAAAA/8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEQMRAD8A/cbLRAastEBqy2VBbLZAastEBqy2VBbLZUFstEBqy0AWy2VBbLZAastEBqy2VBbLZUC1ZABLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBQAQQBRAFEAUQBRAFEAURMs4jjMxHrNA0PONbD68f8AKGwUQBRAFEAUQBRAFEAWvlf6E+fOACWWAFlgBZYAWWAFlgBby19xGHPjPSObz3e58PDH9Xs+dM3xniD21d3nl5+GOkfy8JnqADWGpOP6ZmPSWQHVhvs451PrFOjQ3sZTUx4Z/aXzQH27Lcm13UTWOXCevV1gWWAFlgBZYAWWAAAAzZYNDNlg0M2WDQzZYNPLcavgxmfPlHq3b5++1Lyr6fcHPlNzc85QAAAAAAAHfsde/wCmeccvRwN6GVZYz3B9gZssGhmywaGbLBoZssGhm1BA+ewAAAB89wA+e4BMvj55XMz1l9fLlPpL48gAAAAAAAALjzj1hGtKLyxjvAPrRyUAPnuAAAAfPYAZFoBAAAAAAAAHy9bGspju+nlNRM9It8vUznKbnzBkAAAAAAAB07HC5menu5ndsZ/pntIOkAAAAAAAAAARAaEAUQBRACXys4qZjpL6r5u4w8OU9+MA8wAAAAAAAH0NnFYR3fPfR2+NYwD2EAUQBRAFGVBRkACywAssALLACywHnraUZ8/Lzellg+XlFTMdEb1orKfVgAAAAAAHTtdGMoufKXY8drFYR3uXtYAWWAFlgBZYAWWAFoAAAAAAAAAADk3uPGJ68HM79xjE4zflxcAAAAAAPXbYXlHbiDtwioiOkNIoAAAAAAAAIAAAAAAAADOWcRzmgaTLKI4zwc2puvpj7y58spnnNg9dfX8XCOEe7xAAAAABccpibhAHfo6sZR384ej5kS99PczHPj7g7BjDUjLlP8tgAAAWAAAFgMqgADGrqxjHfoDeWURxmXPnuvpi+8vDPOcpuf8AjIPWdxl1r7POZvnxQAAAAAAAAAAAAAiW41so/un3YAesbjLrfrD1w3MecV+7lAfRib5K+fp6k48vw7dPUjKLgG0AFEtQZstADPOomXDnlc3L23OXGujwAAAAAAAAAAAAAAAAAAAAAa08/DNsgPoRlfEtz7XLnH3e4LYgAFpMg485uZnuyAAAAAAAAAAAAAAAAAAAAAAAN6M1lH4djhx5x6w7bBQASPn5lM+U+gA4gAAAAAAAAAAAAAAAAAAAAAAAHdiAKAD/2Q=="
                        runat="server" CssClass="img-fluid mb-3" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <div>
                    <asp:Label ID="lblContraseña" runat="server" CssClass="form-label" Text="¿Desea actualizar su contraseña?"></asp:Label>
                    <asp:CheckBox ID="ckbPass" AutoPostBack="true" runat="server"  />
                </div>
                <div>
                    <asp:Label ID="lblIngreseNuev" CssClass="form-label" runat="server" Text="Ingrese su nueva contraseña"></asp:Label>
                    <asp:TextBox ID="txtContraseña" TextMode="Password" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>

                    <div>
                        <asp:Button ID="btnPass" runat="server" OnClick="btnPass_Click" CssClass="btn btn-danger" Text="Actualizar" />

                    </div>
                </div>
                <div>
                    <asp:Label ID="lblExito" runat="server" CssClass="form-label"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <a href="default.aspx" class="btn btn-primary">Regresar</a>
    </div>
</asp:Content>
