<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarEmpleados.aspx.cs" Inherits="Proyecto_3_capas_ModasDelCentro.Catalogos.Empleados.ListarEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="row">
            <h3>Lista de empleados</h3>
            <p>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />
            </p>
        </div>
        <div class="row">

            <asp:GridView ID="GVEmpleados" runat="server" CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="ID_Empleado"
                OnRowDeleting="GVEmpleados_RowDeleting"
                OnRowCommand="GVEmpleados_RowCommand"
                OnRowEditing="GVEmpleados_RowEditing"
                OnRowUpdating="GVEmpleados_RowUpdating"
                OnRowCancelingEdit="GVEmpleados_RowCancelingEdit">

                <Columns>
                    <asp:BoundField DataField="ID_Empleado" HeaderText="Id Empleado" ItemStyle-Width="50px" ReadOnly="true" Visible="false" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Apellido_Pat" HeaderText="Apellido paterno" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Apellido_Mat" HeaderText="Apellido Materno" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Fecha_Nacimiento" HeaderText="Fecha de Nacimiento" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Domicilio_ID" HeaderText="domicilio" ItemStyle-Width="85px" Visible="false" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Fecha_Ingreso" HeaderText="Fecha de ingreso" ItemStyle-Width="85px" />

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Accion" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                    <asp:CommandField ButtonType="Button" HeaderText="Accion" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>

            </asp:GridView>

        </div>
    </div>
</asp:Content>
