<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="lista.aspx.cs" Inherits="CatalogoWeb.lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <label for="txtFiltroRapido" class="form-label">Filtrá tu búsqueda</label>
                        <asp:TextBox ID="txtFiltroRapido" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ckbFiltroAvanzado" OnCheckedChanged="ckbFiltroAvanzado_CheckedChanged" AutoPostBack="true" Text="Filtro Avanzado" runat="server" />
                    </div>
                </div>
            </div>
            <%if (ckbFiltroAvanzado.Checked)
                {%>

            <div class="row">
                <div class="col-3">
                    <asp:Label ID="lblCampo" runat="server" CssClass="form-label" Text="Campo"></asp:Label>
                    <asp:DropDownList ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged"  AutoPostBack="true" CssClass="form-control" runat="server">
                        <asp:ListItem>Nombre</asp:ListItem>
                        <asp:ListItem>Precio</asp:ListItem>
                        <asp:ListItem>Marca</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="lblCriterio" runat="server" CssClass="form-label" Text="Criterio"></asp:Label>
                    <asp:DropDownList ID="ddlCriterio" OnSelectedIndexChanged="ddlCriterio_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="lblFiltro" CssClass="form-label" runat="server" Text="Filtro"></asp:Label>
                    <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" runat="server" Text="Buscar" />
                <asp:Button ID="btnRefrescar" OnClick="btnRefrescar_Click" CssClass="btn-primary" runat="server" Text="Refrescar" />
            </div>
            </div>
            </div>
            <%} %>
            <asp:GridView ID="dgvArticulos" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged1" DataKeyNames="Id" OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" CssClass="table" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="seleccionar" />
                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <a href="detalle.aspx" class="btn btn-primary">Agregar</a>
    </div>
</asp:Content>
