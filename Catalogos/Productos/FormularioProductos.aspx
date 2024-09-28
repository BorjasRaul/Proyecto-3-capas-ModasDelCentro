<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProductos.aspx.cs" Inherits="Proyecto_3_capas_ModasDelCentro.Catalogos.Productos.FormularioProductos" %>
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
                 <asp:Label ID="lblModelo" runat="server" Text="">Modelo</asp:Label>
                 <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control"></asp:TextBox>

                 <asp:Label ID="lblMarca" runat="server" Text="">Marca</asp:Label>
                 <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control"></asp:TextBox>

                 <asp:Label ID="lblTalla" runat="server" Text="">Talla</asp:Label>
                 <asp:TextBox ID="txtTalla" runat="server" CssClass="form-control"></asp:TextBox>

                 <asp:Label ID="LblColor" runat="server" Text="">Color</asp:Label>
                   <asp:TextBox ID="txtColor" runat="server" CssClass="form-control"></asp:TextBox>

                  <asp:Label ID="lblEstampado" runat="server" Text="">Estampado</asp:Label>
                 <asp:TextBox ID="txtEstampado" runat="server" CssClass="form-control" ></asp:TextBox>


                 <asp:Label ID="lblPrecio" runat="server" Text="">Precio</asp:Label>
                 <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>

                 <asp:Label ID="lblStock" runat="server" Text="">Stock</asp:Label>
                 <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>

                 <br />
                 <br />

                 <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar datos" OnClick="btnActualizar_Click" />
                 <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />

             </div>
         </div>
     </div>
 </div>
</asp:Content>
