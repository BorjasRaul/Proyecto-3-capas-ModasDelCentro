using BLL;
using Proyecto_3_capas_ModasDelCentro.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Proyecto_3_capas_ModasDelCentro.Catalogos.Empleados
{
    public partial class FormularioEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("~/");
            }
            if (!IsPostBack)
            {
                txtFecha_Nacimiento.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
                if (Request.QueryString["Id"] != null)
                {

                    // Recupera el parámetro de la URL
                    string tipoSeleccion = Request.QueryString["tselection"];

                    // Realiza la condición if
                    if (tipoSeleccion == "Select")
                    {

                        int id = int.Parse(Request.QueryString["Id"]);
                        Empleados_VO cliente = BLL_Empleados.get_Empleado("@ID_Empleado", id)[0];
                        if (cliente != null)
                        {
                            txtNombre.Text = cliente.Nombre;
                            txtNombre.Enabled = false;
                            txtApellido_Pat.Text = cliente.Apellido_Pat;
                            txtApellido_Pat.Enabled = false;
                            txtApellido_Mat.Text = cliente.Apellido_Mat;
                            txtApellido_Mat.Enabled = false;
                            txtFecha_Nacimiento.Text = DateTime.Parse( cliente.Fecha_Nacimiento).ToString("yyyy-MM-dd");
                            txtFecha_Nacimiento.Enabled = false;
                            txtDomicilio.Text = cliente.Domicilio_ID.ToString();
                            txtTelefono.Text = cliente.Telefono;
                            txtTelefono.Enabled = false;
                            txtFecha_Ingreso.Text= DateTime.Parse( cliente.Fecha_Ingreso).ToString("yyyy-MM-dd");
                            txtFecha_Ingreso.Enabled = false;
                            btnGuardar.Enabled = true;
                            btnGuardar.Visible = false;
                        }


                        // Realiza alguna acción
                    }
                    else
                    {
                        btnActualizar.Enabled = false;
                        btnActualizar.Visible = false;

                    }


                }
                else
                {
                    btnActualizar.Enabled = false;
                    btnActualizar.Visible = false;
                    btnGuardar.Enabled = true;
                    lblFecha_Ingreso.Visible = false;
                    txtFecha_Ingreso.Visible = false;
                    Session["T_empleado"] = "nuevo";

                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            SweetAlert.sweet_Alert_Update("ListarEmpleados.aspx", this.Page, GetType());
            //SweetAlert.sweet_Alert("Desae actualizar", "", "info", this.Page, GetType());
          
            txtNombre.Enabled = true;
            txtApellido_Pat.Enabled = true;
            txtApellido_Mat.Enabled = true;
            txtTelefono.Enabled = true;
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", salida = "", respuesta = "", tipo = "",dir="";
            try
            {
                //creamos el objeto que enviaremos para ctualizar o isrtar
                Empleados_VO Empleado = new Empleados_VO();
                Empleado.Nombre = txtNombre.Text;
                Empleado.Apellido_Pat = txtApellido_Pat.Text;
                Empleado.Apellido_Mat = txtApellido_Mat.Text;
                Empleado.Fecha_Nacimiento= DateTime.Parse(txtFecha_Nacimiento.Text).ToString("yyyy-MM-dd");
                
                Empleado.Domicilio_ID = string.IsNullOrEmpty(txtDomicilio.Text) ? 0 : int.Parse(txtDomicilio.Text);
                Empleado.Telefono = txtTelefono.Text;
                Empleado.Fecha_Ingreso= txtFecha_Ingreso.Text;
               

                 
                if (Request.QueryString["id"] == null)
                {

                    //insertar 
                    salida = BLL_Empleados.insertar_Empleado(Empleado);
                }
                else
                {

                    //actualizar
                    Empleado.Id_Empleado = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Empleados.Update_Empledo(Empleado);
                }
                //Preparamos la salida para cachar un error y mostrar ub sweet alert

                if (salida.ToUpper().Contains("ERROR"))
                {

                    titulo = "Ops..";
                    respuesta = salida;
                    tipo = "error";
                    dir = "ListarEmpleados.aspx";
                }
                else
                {

                    titulo = "Correcto";
                    respuesta = salida;
                    tipo = "success";
                    if (Session["T_empleado"].ToString() == "nuevo")
                    {
                        dir = "../Domicilios/FormularioDomicilios.aspx";
                    }
                    else {
                        dir = "ListarEmpleados.aspx";
                    }
                   
                }

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
