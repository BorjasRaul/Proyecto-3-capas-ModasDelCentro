<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioDomicilios.aspx.cs" Inherits="Proyecto_3_capas_ModasDelCentro.Catalogos.Domicilios.FormularioDomicilios" %>

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
                    <asp:Label ID="lblCalle" runat="server" Text="">Calle</asp:Label>
                    <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblNumero" runat="server" Text=""> Numero #</asp:Label>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblColonia" runat="server" Text="">Colonia</asp:Label>
                    <asp:TextBox ID="txtColonia" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblCiudad" runat="server" Text="">Ciudad</asp:Label>
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />


                </div>
            </div>
        </div>
    </div>
</asp:Content>
