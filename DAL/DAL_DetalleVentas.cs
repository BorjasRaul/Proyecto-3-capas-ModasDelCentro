using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_DetalleVentas
    {
        //CREATE
        public static string insertar_DetalleVentas(DetalleVenta_VO dtVenta)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Insert_DetalleVenta",
                    "ID_Detalle_Venta", dtVenta.ID_Detalle_Venta,
                    "Venta_ID ", dtVenta.Venta_ID,
                    "Producto_ID ", dtVenta.Producto_ID,
                    "Cantidad ", dtVenta.Cantidad,
                    "Precio_Unitario ", dtVenta.Precio_Unitario,
                    "SubTotal ", dtVenta.SubTotal
                    );

                if (respuesta != 0)
                {
                    salida = "DetalleVenta resgistrado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {

                salida = "Error:" + e.Message;
            }
            return salida;
        }
        //READ
        public static List<DetalleVenta_VO> get_DetalleVenta(params object[] parametros)
        {

            List<DetalleVenta_VO> list = new List<DetalleVenta_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_dtVenta = Metodos_Datos.execute_DataSet("SP_Select_DetalleVenta", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_dtVenta.Tables[0].Rows)
                {

                    list.Add(new DetalleVenta_VO(dr));

                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }

        }
        //UPDATE
        public static string Update_DetalleVenta(DetalleVenta_VO dtVenta)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Update_DetalleVenta",
                    "ID_Detalle_Venta",dtVenta.ID_Detalle_Venta,
                   "Venta_ID ", dtVenta.Venta_ID,
                    "Producto_ID ", dtVenta.Producto_ID,
                    "Cantidad ", dtVenta.Cantidad,
                    "Precio_Unitario ", dtVenta.Precio_Unitario,
                    "SubTotal ", dtVenta.SubTotal

                     );

                if (respuesta != 0)
                {
                    salida = "DetalleVenta actualizado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {

                salida = "Error: " + e.Message;
            }
            return salida;

        }
        //DELETE
        public static string Delete_DetalleVenta(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Delete_DetalleVenta",
                     "@ID_DetalleVenta", id

                     );

                if (respuesta != 0)
                {
                    salida = "DetalleVenta eliminado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {

                salida = "Error: " + e.Message;
            }
            return salida;

        }
    }
}
