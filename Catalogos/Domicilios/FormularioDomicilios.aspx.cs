using BLL;
using Proyecto_3_capas_ModasDelCentro.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Proyecto_3_capas_ModasDelCentro.Catalogos.Domicilios
{
    public partial class FormularioDomicilios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("~/");
            }
            if (!IsPostBack) {

                
            }

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", salida = "", respuesta = "", tipo = "", dir = "";
            try
            {
                //creamos el objeto que enviaremos para ctualizar o isrtar
                Domicilios_VO domicilio = new Domicilios_VO();
                domicilio.Calle = txtCalle.Text;
                domicilio.Numero = txtNumero.Text;
                domicilio.Colonia = txtColonia.Text;
                domicilio.Ciudad = txtCiudad.Text;



                if (Request.QueryString["id"] == null)
                {

                    //insertar 
                    salida = BLL_Domicilios.insertar_Domicilio(domicilio);
                }
                else
                {

                    //actualizar
                    domicilio.ID_Domicilio = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Domicilios.Update_Domicilio(domicilio);
                }
                //Preparamos la salida para cachar un error y mostrar ub sweet alert

                if (salida.ToUpper().Contains("ERROR"))
                {

                    titulo = "Ops..";
                    respuesta = salida;
                    tipo = "error";
                  
                }
                else
                {

                    titulo = "Correcto";
                    respuesta = salida;
                    tipo = "success";
                    Session["T_empleado"] = "";
                }
                dir = "../Empleados/ListarEmpleados.aspx";
                SweetAlert.sweet_Alert_Guardar(titulo, respuesta, tipo, dir, this.Page, GetType());


            }
            catch (Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
            }
        }
    }
}