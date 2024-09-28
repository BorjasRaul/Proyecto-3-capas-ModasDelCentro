<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarProductos.aspx.cs" Inherits="Proyecto_3_capas_ModasDelCentro.Catalogos.Productos.ListarProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="row">
            <h3>Lista de Productos</h3>
            <p>
                <asp:Button ID="Insertar" runat="server" Text="Agregar Producto" CssClass="btn btn-primary btn-xs" Width="185px" OnClick="Insertar_Click" />
            </p>
        </div>
        <div class="row">
            <asp:Label ID="lblNombre" runat="server" Text="">Codigos</asp:Label>
            <br />
            <asp:DropDownList ID="ddlFechaIngreso" runat="server" Width="220px" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlFechaIngreso_SelectedIndexChanged"></asp:DropDownList>

            <br />
            <br />
        </div>
        <div class="row">


            <asp:GridView ID="GVProductos" runat="server" CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="ID_Producto,Fecha_Creacion"
                OnRowDeleting="GVProductos_RowDeleting"
                onRowDataBound="GVProductos_RowDataBound1"
                onRowCommand="GVProductos_RowCommand">


                <Columns>
                    <asp:BoundField DataField="ID_Producto" HeaderText="ID Producto" ItemStyle-Width="50px" ReadOnly="true" Visible="false" />
                    <asp:BoundField DataField="Codigo_Producto" HeaderText="Codigo de producto" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Talla" HeaderText="Talla" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Color" HeaderText="Color" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Estampado" HeaderText="Estampado" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Fecha_Creacion" HeaderText="Fecha Creacion" ItemStyle-Width="50px" ReadOnly="true" Visible="false" />

                 
                    <asp:ButtonField ButtonType="Button"  CommandName="Select" HeaderText="Accion" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                    <asp:CommandField ButtonType="Button"  HeaderText="Accion" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>

            </asp:GridView>

        </div>
    </div>
</asp:Content>
