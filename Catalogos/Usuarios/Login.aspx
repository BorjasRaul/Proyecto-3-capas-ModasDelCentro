<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_3_capas_ModasDelCentro.Catalogos.Usuarios.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
            <asp:Label ID="Subtitulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-12">
                <%---Fomulario---%>
                <div class="form-group">
                    <%---Fomulario---%>
                    <asp:Label ID="lblUsuario" runat="server" Text="">Usuario</asp:Label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblContraseña" runat="server" Text=""> Contraseña</asp:Label>
                    <asp:TextBox ID="txtcontraseña" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
         <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />

    </div>

</asp:Content>
