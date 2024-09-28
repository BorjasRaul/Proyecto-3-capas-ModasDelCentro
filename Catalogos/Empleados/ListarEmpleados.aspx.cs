using BLL;
using Proyecto_3_capas_ModasDelCentro.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_3_capas_ModasDelCentro.Catalogos.Empleados
{
    public partial class ListarEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null )
            {
                Response.Redirect("~/");
            }
            if (!IsPostBack)
            {

                Cargar_Grid();
            }

        }

        private void Cargar_Grid()
        { 
            
            GVEmpleados.DataSource = BLL_Empleados.get_Empleado();
            GVEmpleados.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioEmpleados.aspx");
        }

        protected void GVEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Recupero el id de camion
            int idCamion = int.Parse(GVEmpleados.DataKeys[e.RowIndex].Values["ID_Empleado"].ToString());

            string respuesta = BLL_Empleados.Delete_Empleado(idCamion);

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
            Cargar_Grid();
        }

        protected void GVEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el click que se detecta) tiene la proiedad select
            if (e.CommandName == "Select")
            {

                //recupero el indice en funcion de aquel elelemtno qeu haya detonado el evento 
                int VarIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el id en funcion del inidice que recuperamos 
                string id = GVEmpleados.DataKeys[VarIndex].Values["ID_Empleado"].ToString();


                string seleccion = e.CommandName;

                //redirecciono al formulario de edicion, pasando como parametro el ID
                Response.Redirect($"FormularioEmpleados.aspx?id=" + id + "&tselection=" + seleccion + " ");
            }
        }

        protected void GVEmpleados_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVEmpleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVEmpleados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}