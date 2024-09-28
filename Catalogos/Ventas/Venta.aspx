<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="Proyecto_3_capas_ModasDelCentro.Catalogos.Ventas.Venta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h3>Venta</h3>
        <p>
            <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />

        </p>
        <asp:Label ID="lblCodigoProd" runat="server" Text="">Dijite Codigo de producto</asp:Label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"
            ErrorMessage="El campo Código es obligatorio." CssClass="error" Display="Dynamic">
        </asp:RequiredFieldValidator>
        <asp:Label ID="lblCantidad" runat="server" Text="">Cantidad</asp:Label>
        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidad"
            ErrorMessage="El campo Cantidad es obligatorio." CssClass="error" Display="Dynamic">
        </asp:RequiredFieldValidator>
    </div>
    <div class="row">

        <asp:GridView ID="GVVentas" runat="server" CssClass="table table-bordered table-striped table-condensed"
            AutoGenerateColumns="false"
            DataKeyNames="Codigo_Producto"
            OnRowDeleting="GVVentas_RowDeleting">

            <Columns>
                <asp:BoundField DataField="Codigo_Producto" HeaderText="Codigo" ItemStyle-Width="85px" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Width="85px" />
                <asp:BoundField DataField="Precio" HeaderText="Precio unitario" ItemStyle-Width="85px" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="85px" />
                <asp:BoundField DataField="PXC" HeaderText="PXC" ItemStyle-Width="85px" />
                <asp:CommandField ButtonType="Button" HeaderText="Accion" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
            </Columns>

        </asp:GridView>

    </div>
    <asp:Label ID="lblSubtotal" runat="server" Text="">Subtotal</asp:Label>
    <asp:TextBox ID="txtSubtotal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

    <br />
    <asp:Label ID="lblTotal" runat="server" Text="">Total :</asp:Label>
    <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
    <br />
    <asp:Label ID="lblTotalLetra" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <p>
        <asp:Button ID="btnCobrar" runat="server" Text="Cobrar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="btnCobrar_Click" />

    </p>

</asp:Content>
