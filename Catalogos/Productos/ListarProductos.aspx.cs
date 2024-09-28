using BLL;
using Proyecto_3_capas_ModasDelCentro.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Proyecto_3_capas_ModasDelCentro.Catalogos.Productos
{
    public partial class ListarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("~/");
            }
            if (!IsPostBack)
            {

                Cargarddl();
            }
        }

        private void Cargarddl()
        {

            ListItem ddlFecha = new ListItem("Seleccione un Codigo", "");
            ddlFechaIngreso.Items.Add(ddlFecha);
            List<string> list_C = BLL_Productos.get_ProductoByFecha();
            if (list_C.Count > 0)
            {
                foreach (var c in list_C)
                {

                    ListItem Ci = new ListItem((DateTime.Parse(c).ToString("yyyyMMdd")));
                    ddlFechaIngreso.Items.Add((Ci));
                }

            }

        }

        private void Cargar_Grid(string itemSelect)
        {
            if (!string.IsNullOrEmpty(itemSelect))
            {
                GVProductos.DataSource = BLL_Productos.get_ProductoByDate("@Fecha_Creacion", itemSelect);
            }
            else
            {

                GVProductos.DataSource = BLL_Productos.get_Producto();
            }
            GVProductos.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioProductos.aspx");
        }

        protected void GVProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Recupero el id de camion
            int idCamion = int.Parse(GVProductos.DataKeys[e.RowIndex].Values["ID_Producto"].ToString());
            string fecha = GVProductos.DataKeys[e.RowIndex].Values["Fecha_Creacion"].ToString();
            fecha = DateTime.Parse(fecha).ToString("yyyyMMdd");
            string respuesta = BLL_Productos.Delete_Producto(idCamion);

            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("Error"))
            {

                titulo = "Error";
                msg = respuesta;
                tipo = "Error";
            }
            else
            {

                titulo = "Correcto";
                msg = respuesta;
                tipo = "Succes";
            }
            //sweeet alert
            SweetAlert.sweet_Alert(titulo, msg, tipo, this.Page, GetType());
            //Recargamos el grid
            ddlFechaIngreso.Text = fecha;
            Cargar_Grid(fecha);
        }
        protected void ddlFechaIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelect = ddlFechaIngreso.Text;

            Cargar_Grid(itemSelect);

        }



        protected void GVProductos_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Session["Rol"] = 1;
                int rol = int.Parse(Session["Rol"].ToString());


                Button btnDetalles = (Button)e.Row.Cells[10].Controls[0]; // Ajusta el índice de la celda según tu GridView
                Button btnEliminar = (Button)e.Row.Cells[11].Controls[0]; // Ajusta el índice de la celda según tu GridView
                if (rol == 1)
                {

                    btnDetalles.Visible = true;
                    btnEliminar.Visible = true;
                }
                else {

                    btnDetalles.Visible = false;
                    btnEliminar.Visible = false;
                }

            }
        }

        protected void GVProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el click que se detecta) tiene la proiedad select
            if (e.CommandName == "Select")
            {

                //recupero el indice en funcion de aquel elelemtno qeu haya detonado el evento 
                int VarIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el id en funcion del inidice que recuperamos 
                string id = GVProductos.DataKeys[VarIndex].Values["ID_Producto"].ToString();


                string seleccion = e.CommandName;

                //redirecciono al formulario de edicion, pasando como parametro el ID
                Response.Redirect($"FormularioProductos.aspx?id=" + id + "&tselection=" + seleccion + " ");
            }
        }
    }
}