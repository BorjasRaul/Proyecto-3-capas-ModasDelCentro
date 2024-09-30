using BLL;
using Proyecto_3_capas_ModasDelCentro.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Proyecto_3_capas_ModasDelCentro.Catalogos.Ventas
{
    public partial class Venta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("~/");
            }

            if (!IsPostBack)
            {

                ViewState["DetalleVentaAux"] = new List<DetalleVentaAux_VO>();
                btnCobrar.Enabled = false;
            }


        }

        protected void GVVentas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Obtener el índice de la fila que se va a eliminar
            int index = e.RowIndex;

            // Aquí puedes obtener el valor de la clave primaria si es necesario
            string codigoProducto = GVVentas.DataKeys[index].Value.ToString();

            List<DetalleVentaAux_VO> dtAux = ViewState["DetalleVentaAux"] as List<DetalleVentaAux_VO>;

            // Encontrar el elemento a eliminar
            var itemToRemove = dtAux.FirstOrDefault(item => item.Codigo_Producto == codigoProducto);

            // Eliminar el elemento de la lista
            if (itemToRemove != null)
            {
                dtAux.Remove(itemToRemove);
            }
            // Actualizar el ViewState
            ViewState["DetalleVentaAux"] = dtAux;

            // Volver a enlazar los datos al GridView
            double subtotal = dtAux.Sum(x => x.PXC);

            subtotal += subtotal * 0.16;
            double total = subtotal;
            txtTotal.Text = total.ToString();
            string totalLetra = ConvertirnumeroToLetra.ToCardinal(decimal.Parse(total.ToString()));
            lblTotalLetra.Text = totalLetra;

            GVVentas.DataSource = dtAux;
            GVVentas.DataBind();
            SweetAlert.sweet_Alert("Producto eliminado de la cuenta", "", "info", this.Page, this.GetType());


        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
          
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                ErrorMessageCantidad.Text = "Campo requerido";
                ErrorMessageCantidad.Visible = true;
                isValid = false;
            }
            else
            {
                ErrorMessageCantidad.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                ErrorMessageCodigo.Text = "Campo requerido";
                ErrorMessageCodigo.Visible = true;
                isValid = false;
            }
            else
            {
                ErrorMessageCodigo.Visible = false;
            }



            if (isValid) {

                string codigo = txtCodigo.Text;
                int Cantidad = int.Parse(txtCantidad.Text);


                List<Productos_VO> dt2 = BLL_Ventas.get_VentasByCodigo("@Codigo_Producto", codigo);

                //List<DetalleVentaAux_VO> dtAux = new List<DetalleVentaAux_VO>();

                // Recuperar la lista del ViewState
                List<DetalleVentaAux_VO> dtAux = ViewState["DetalleVentaAux"] as List<DetalleVentaAux_VO>;
                DetalleVentaAux_VO detalleVentaAux_;

                foreach (var item in dt2)
                {
                    detalleVentaAux_ = new DetalleVentaAux_VO();
                    detalleVentaAux_.ID_Producto = item.ID_Producto;
                    detalleVentaAux_.Codigo_Producto = item.Codigo_Producto;
                    detalleVentaAux_.Descripcion = item.Modelo + " " + item.Marca + " " + item.Talla;
                    detalleVentaAux_.Precio = item.Precio;
                    detalleVentaAux_.Cantidad = Cantidad;
                    detalleVentaAux_.PXC = Cantidad * item.Precio;
                    if (Cantidad < item.Stock)
                    {
                        if (Cantidad == 0)
                        {

                            SweetAlert.sweet_Alert($"Problema con el Codigo{item.Codigo_Producto}", "Ingrese la cantidad correcta, no acepta Cero", "info", this.Page, this.GetType());
                            break;
                        }

                        var itemToRemove = dtAux.FirstOrDefault(itemaux => itemaux.Codigo_Producto == item.Codigo_Producto);

                        // Agrupar por Codigo_Producto y sumar las cantidades
                        int sumaCantidad = dtAux.Where(itemaux => itemaux.Codigo_Producto == item.Codigo_Producto)
                             .Sum(itemaux => itemaux.Cantidad);
                        sumaCantidad = sumaCantidad + Cantidad;
                        if (sumaCantidad > item.Stock)
                        {

                            SweetAlert.sweet_Alert($"Problema con el Codigo{item.Codigo_Producto}", $"Lo sentimos ha sobrepasado el stock del producto {item.Codigo_Producto}", "info", this.Page, this.GetType());
                            break;
                        }


                    }
                    else
                    {
                        SweetAlert.sweet_Alert($"Problema con el Codigo{item.Codigo_Producto}", "No contamos con el stock suficiente", "info", this.Page, this.GetType());
                        break;
                    }

                    dtAux.Add(detalleVentaAux_);


                }

                double subtotal = dtAux.Sum(x => x.PXC);

                txtSubtotal.Text = subtotal.ToString();
                ViewState["DetalleVentaAux"] = dtAux;

                subtotal += subtotal * 0.16;
                double total = subtotal;
                txtTotal.Text = total.ToString();
                string totalLetra = ConvertirnumeroToLetra.ToCardinal(decimal.Parse(total.ToString()));
                lblTotalLetra.Text = totalLetra;
                GVVentas.DataSource = dtAux;
                GVVentas.DataBind();
                txtCantidad.Text = "";
                txtCodigo.Text = "";
                if (subtotal >= 0)
                {
                    btnCobrar.Enabled = true;
                }


            }



        }

        protected void btnCobrar_Click(object sender, EventArgs e)
        {
            List<DetalleVentaAux_VO> listDTV = new List<DetalleVentaAux_VO>();

            foreach (GridViewRow row in GVVentas.Rows)
            {
                DetalleVentaAux_VO dtVAux = new DetalleVentaAux_VO();

                
                  Label labl  = (Label)row.FindControl("ID_Producto");
                dtVAux.ID_Producto = int.Parse(labl.Text);
                dtVAux.Codigo_Producto = row.Cells[1].Text;
                dtVAux.Descripcion = row.Cells[2].Text;
                dtVAux.Precio = Convert.ToDouble(row.Cells[3].Text);
                dtVAux.Cantidad = Convert.ToInt32(row.Cells[4].Text);
                dtVAux.PXC = Convert.ToDouble(row.Cells[5].Text);
                

                listDTV.Add(dtVAux);

            }
            Ventas_VO ventas = new Ventas_VO();
            ventas.Total= double.Parse(txtTotal.Text);
            //ventas.Empleado_ID = int.Parse(Session["ID_Usuario"].ToString());
            ventas.Empleado_ID = 9;
            ventas.Status_ID = 1;

            string salida = BLL_Ventas.insertar_Ventas(ventas);
            
            DetalleVenta_VO detalleVenta_ = new DetalleVenta_VO(); 
            detalleVenta_.Venta_ID = int.Parse(salida);

            


            string titulo, respuesta, tipo;
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

            SweetAlert.sweet_Alert_Guardar(titulo, respuesta, tipo, "Ventass.aspx", this.Page, GetType());




        }
    }
}