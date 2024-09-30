using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_3_capas_ModasDelCentro
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {

                UsuarioMaster.InnerText = Session["Usuario"].ToString();
                IniciarSesion.Visible = false;

            }
            else { 
            
                IniciarSesion.Visible=true;
                CerrarSesion.Visible = false;
            }
           
          
        }

        protected void CerrarSesion_ServerClick(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Session["Rol"] = null;
            CerrarSesion.Visible = false;
            IniciarSesion.Visible = true;
            Response.Redirect("~/");
        }
    }

}
