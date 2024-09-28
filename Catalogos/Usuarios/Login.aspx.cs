using BLL;
using Proyecto_3_capas_ModasDelCentro.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Proyecto_3_capas_ModasDelCentro.Catalogos.Usuarios
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", salida = "", respuesta = "", tipo = "";
            Usuarios_VO usuarios = new Usuarios_VO();
            usuarios.Nombre_Usuario = txtUsuario.Text;
            usuarios.Nombre_Usuario=usuarios.Nombre_Usuario.ToUpper();
            usuarios.Contraseña=txtcontraseña.Text;

           Usuarios_VO usuarios_VO = BLL_Usuarios.get_UsuariosLogin(
                "@Nombre_Usuario",usuarios.Nombre_Usuario, "@Contraseña", usuarios.Contraseña)[0];

            if (usuarios_VO == null)
            {

                titulo = "Usuario no encontrado";
                respuesta = "";
                tipo = "info";
                SweetAlert.sweet_Alert(titulo, salida, tipo, this.Page, GetType());
            }
            else {
                Session["Rol"] = usuarios_VO.Rol_ID;
                Session["Usuario"]=usuarios_VO.Nombre_Usuario;
                if (usuarios_VO.Rol_ID == 1) {

                    Response.Redirect("~/");
                }
               
            }
        }
    }
}