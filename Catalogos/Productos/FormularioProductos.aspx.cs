using BLL;
using Proyecto_3_capas_ModasDelCentro.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Proyecto_3_capas_ModasDelCentro.Catalogos.Productos
{
    public partial class FormularioProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("~/");
            }
            if (!IsPostBack)
            {


               
                int rol = int.Parse(Session["Rol"].ToString());

                if (Request.QueryString["Id"] != null  )
                {

                    // Recupera el parámetro de la URL
                    string tipoSeleccion = Request.QueryString["tselection"];

                    // Realiza la condición if
                    if (tipoSeleccion == "Select")
                    {

                        int id = int.Parse(Request.QueryString["Id"]);
                        Productos_VO productos = BLL_Productos.get_Producto("@ID_Producto", id)[0];
                        if (productos != null)
                        {
                            
                            txtModelo.Text = productos.Modelo;
                            txtModelo.Enabled = false;
                            txtMarca.Text = productos.Marca;
                            txtMarca.Enabled = false;
                            txtTalla.Text = productos.Talla;
                            txtTalla.Enabled = false;
                            txtColor.Text = productos.Color;
                            txtColor.Enabled = false;
                            txtEstampado.Text = productos.Estampado;
                            txtEstampado.Enabled = false;
                            txtPrecio.Text = productos.Precio.ToString();
                            txtPrecio.Enabled = false;
                            txtStock.Text = productos.Stock.ToString();
                            txtStock.Enabled = false;
                         
                            btnGuardar.Enabled = true;
                            btnGuardar.Visible = false;


                        }


                    }
                    else
                    {
                        btnActualizar.Enabled = false;
                        btnActualizar.Visible = false;

                    }


                }
                else
                {
                  
                    btnActualizar.Visible = false;
                    btnGuardar.Enabled = true;

                }

            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            SweetAlert.sweet_Alert_Update("ListarProductos.aspx", this.Page, GetType());
            //SweetAlert.sweet_Alert("Desae actualizar", "", "info", this.Page, GetType());

            txtModelo.Enabled = true;
            txtMarca.Enabled = true;
            txtTalla.Enabled = true;
            txtColor.Enabled = true;
            txtEstampado.Enabled = true;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", salida = "", respuesta = "", tipo = "";
            try
            {
                //creamos el objeto que enviaremos para ctualizar o isrtar
                Productos_VO productos = new Productos_VO();
                productos.Modelo=txtModelo.Text;           
                productos.Marca=txtMarca.Text;            
                productos.Talla=txtTalla.Text;             
                productos.Color=txtColor.Text;              
                productos.Estampado=txtEstampado.Text;           
                productos.Precio= double.Parse( txtPrecio.Text);        
                productos.Stock= int.Parse( txtStock.Text);


                if (Request.QueryString["id"] == null)
                {


                    salida = BLL_Productos.insertar_Producto(productos);
                }
                else
                {

                    //actualizar
                    productos.ID_Producto = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Productos.Update_Producto(productos);
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

                SweetAlert.sweet_Alert_Guardar(titulo, respuesta, tipo, "ListarProductos.aspx", this.Page, GetType());

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