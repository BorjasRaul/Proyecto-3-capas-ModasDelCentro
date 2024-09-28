<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioClientes.aspx.cs" Inherits="Proyecto_3_capas_ModasDelCentro.Catalogos.Clientes.FormularioClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
    <div class="row">
        <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text="" ></asp:Label>
        <asp:Label ID="Subtitulo" runat="server" CssClass="text-center modal-title" Text="" ></asp:Label>
    </div>
    <div class="row">
        <div class="col-md-12">
            <%---Fomulario---%>
            <div class="form-group">
            <%---Fomulario---%>
                <asp:Label ID="lblNombre" runat="server" Text="">Nombre</asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" cssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblApellidoPaterno" runat="server" Text="">Apellido Paterno</asp:Label>
                <asp:TextBox ID="txtApellidoPaterno" runat="server" cssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblApellidoMaterno" runat="server" Text="">Apellido Materno</asp:Label>
                <asp:TextBox ID="txtApellidoMaterno" runat="server" cssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblTelefono" runat="server" Text="">Telefono</asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" cssClass="form-control"></asp:TextBox>

                <br />
                <br />
               
                <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar datos" OnClick="btnActualizar_Click"/>
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click"/>


            </div>
        </div>
    </div>
</div>
</asp:Content>
