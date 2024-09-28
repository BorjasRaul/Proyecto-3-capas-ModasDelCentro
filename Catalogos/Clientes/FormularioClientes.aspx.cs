using BLL;
using Proyecto_3_capas_ModasDelCentro.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Proyecto_3_capas_ModasDelCentro.Catalogos.Clientes
{
    public partial class FormularioClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("~/");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {

                    // Recupera el parámetro de la URL
                    string tipoSeleccion = Request.QueryString["tselection"];

                    // Realiza la condición if
                    if (tipoSeleccion == "Select")
                    {

                        int id = int.Parse(Request.QueryString["Id"]);
                        Clientes_VO cliente = BLL_Clientes.get_Clientes("@ID_Clientes", id)[0];
                        if (cliente != null)
                        {
                            txtNombre.Text = cliente.Nombre;
                            txtNombre.Enabled = false;
                            txtApellidoPaterno.Text = cliente.Apellido_Paterno;
                            txtApellidoPaterno.Enabled = false;
                            txtApellidoMaterno.Text = cliente.Apellido_Materno;
                            txtApellidoMaterno.Enabled = false;
                            txtTelefono.Text = cliente.Telefono;
                            txtTelefono.Enabled = false;
                            btnGuardar.Enabled = true;
                            btnGuardar.Visible=false;
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
                    Session["Empleado"] = "Nuevo";
                    btnActualizar.Enabled = false;
                    btnActualizar.Visible = false;

                }


            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", salida = "", respuesta = "", tipo = "";
            try
            {
                //creamos el objeto que enviaremos para ctualizar o isrtar
                Clientes_VO Clientes = new Clientes_VO();
                Clientes.Nombre = txtNombre.Text;
                Clientes.Apellido_Paterno = txtApellidoPaterno.Text;
                Clientes.Apellido_Materno = txtApellidoMaterno.Text;
                Clientes.Telefono = txtTelefono.Text;
                //decido si voy a actualizar o insertar

                ///decido si voy a actualizar o insertar 
                if (Request.QueryString["id"] == null)
                {

                    //insertar 
                    salida = BLL_Clientes.insertar_Clientes(Clientes);
                }
                else
                {

                    //actualizar
                    Clientes.ID_Clientes = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Clientes.Update_Clientes(Clientes);
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
                }

                SweetAlert.sweet_Alert_Guardar(titulo,respuesta, tipo, "ListarClientes.aspx", this.Page, GetType());


            }
            catch (Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            SweetAlert.sweet_Alert_Update("ListarClientes.aspx",this.Page, GetType());
            //SweetAlert.sweet_Alert("Desae actualizar", "", "info", this.Page, GetType());
            txtNombre.Enabled = true;
            txtApellidoPaterno.Enabled = true;
            txtApellidoMaterno.Enabled = true;
            txtTelefono.Enabled = true;
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

        }

    }
}