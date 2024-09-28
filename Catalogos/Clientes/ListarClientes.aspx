<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarClientes.aspx.cs" Inherits="Proyecto_3_capas_ModasDelCentro.Catalogos.Clientes.ListarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="row">
            <h3>Lista de Clientes</h3>
            <p>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />
            </p>
        </div>
        <div class="row">

            <asp:GridView ID="GVClientes" runat="server" CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="ID_Clientes"
                OnRowDeleting="GVClientes_RowDeleting"
                OnRowCommand="GVClientes_RowCommand"
                OnRowEditing="GVClientes_RowEditing"
                OnRowUpdating="GVClientes_RowUpdating"
                OnRowCancelingEdit="GVClientes_RowCancelingEdit">

                <Columns>
                    <asp:BoundField DataField="ID_Clientes" HeaderText="Id cliente" ItemStyle-Width="50px" ReadOnly="true" visible="false"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido paterno" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Domicilio_ID" HeaderText="domicilio" ItemStyle-Width="85px" />



                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Accion" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                    <asp:CommandField ButtonType="Button" HeaderText="Accion" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
