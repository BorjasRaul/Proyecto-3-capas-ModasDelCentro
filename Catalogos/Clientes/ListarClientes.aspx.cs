using BLL;
using Proyecto_3_capas_ModasDelCentro.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_3_capas_ModasDelCentro.Catalogos.Clientes
{
    public partial class ListarClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("~/");
            }
            if (!IsPostBack)
            {

                Cargar_Grid();
            }
        }
        public void Cargar_Grid()
        {
           
            //Carga la informacion desde la bll al gv
            GVClientes.DataSource = BLL_Clientes.get_Clientes();
            GVClientes.DataBind();
        }

        protected void GVClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Recupero el id de camion
            int idCamion = int.Parse(GVClientes.DataKeys[e.RowIndex].Values["ID_Clientes"].ToString());
            
            string respuesta = BLL_Clientes.Delete_Clientes(idCamion);
            
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

        protected void GVClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el click que se detecta) tiene la proiedad select
            if (e.CommandName == "Select")
            {

                //recupero el indice en funcion de aquel elelemtno qeu haya detonado el evento 
                int VarIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el id en funcion del inidice que recuperamos 
                string id = GVClientes.DataKeys[VarIndex].Values["ID_Clientes"].ToString();


                string seleccion = e.CommandName;

                //redirecciono al formulario de edicion, pasando como parametro el ID
                Response.Redirect($"FormularioClientes.aspx?id="+id+"&tselection="+seleccion+" ");
            }
        }

        protected void GVClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioClientes.aspx");
        }
    }
}