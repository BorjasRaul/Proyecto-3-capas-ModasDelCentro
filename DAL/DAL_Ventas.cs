using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Ventas
    {
        //CREATE
        public static string insertar_Ventas(Ventas_VO venta)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_scalar("SP_Insert_Venta",
                    "Total ", venta.Total,
                    "Empleado_ID ", venta.Empleado_ID,
                    //"Cliente_ID ", venta.Cliente_ID,
                    "Status_ID ", venta.Status_ID
                    //"Folio ", venta.Folio
                    );

                if (respuesta != 0)
                {
                    salida = respuesta.ToString();
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
        public static List<Ventas_VO> get_Ventas(params object[] parametros)
        {

            List<Ventas_VO> list = new List<Ventas_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_ventas = Metodos_Datos.execute_DataSet("SP_Select_Venta", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_ventas.Tables[0].Rows)
                {

                    list.Add(new Ventas_VO(dr));

                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }

        }
        //UPDATE
        public static string Update_Ventas(Ventas_VO venta)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Update_Venta",
                   "Total ", venta.Total,
                    "Empleado_ID ", venta.Empleado_ID,
                    "Cliente_ID ", venta.Cliente_ID,
                    "Status_ID ", venta.Status_ID
                    //"Folio ", venta.Folio

                     );

                if (respuesta != 0)
                {
                    salida = "Venta actualizado con exito";
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
        public static string Delete_Ventas(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Delete_Venta",
                     "@ID_Venta", id

                     );

                if (respuesta != 0)
                {
                    salida = "venta eliminada con exito";
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
