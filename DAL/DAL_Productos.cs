using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Productos
    {
        //CREATE
        public static string insertar_Producto(Productos_VO producto)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Insert_Producto",
                    "Modelo ", producto.Modelo,
                    "Marca ", producto.Marca,
                    "Talla ", producto.Talla,
                    "Color ", producto.Color,
                    "Estampado ", producto.Estampado,
                    "Precio ", producto.Precio,
                    "Stock ", producto.Stock
                    );

                if (respuesta != 0)
                {
                    salida = "Producto resgistrado con exito";
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
        public static List<Productos_VO> get_Producto(params object[] parametros)
        {

            List<Productos_VO> list = new List<Productos_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_producto = Metodos_Datos.execute_DataSet("SP_Select_Producto", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_producto.Tables[0].Rows)
                {

                    list.Add(new Productos_VO(dr));

                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }

        }
        //UPDATE
        public static string Update_Producto(Productos_VO producto)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Update_Producto",
                    "ID_Producto ", producto.ID_Producto,
                    "Modelo ", producto.Modelo,
                    "Marca ", producto.Marca,
                    "Talla ", producto.Talla,
                    "Color ", producto.Color,
                    "Estampado ", producto.Estampado,
                    "Precio ", producto.Precio,
                    "Stock ", producto.Stock

                     );

                if (respuesta != 0)
                {
                    salida = "Producto actualizado con exito";
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
        public static string Delete_Producto(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Delete_Producto",
                     "@ID_Producto", id

                     );

                if (respuesta != 0)
                {
                    salida = "Producto eliminado con exito";
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

        public static List<string> get_ProductoByFecha(params object[] parametros)
        {
            List<string> list = new List<string>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_producto = Metodos_Datos.execute_DataSet("Select_Producto_ByFechaIngreso", parametros);
               // List<string> listaux = new List<string>();
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_producto.Tables[0].Rows)
                {

                    // listaux.Add(dr.ToString()) ;
                    //list.Add(new Productos_VO(dr));
                    list.Add(dr[0].ToString());
                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static List<Productos_VO> get_ProductoByDate(object[] parametros)
        {

            List<Productos_VO> list = new List<Productos_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_producto = Metodos_Datos.execute_DataSet("SP_Select_ProductoByDate", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_producto.Tables[0].Rows)
                {

                    list.Add(new Productos_VO(dr));

                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static List<Productos_VO> get_VentasByCodigo(params object[] parametros)
        {
            List<Productos_VO> list = new List<Productos_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_producto = Metodos_Datos.execute_DataSet("Sp_SelectByCodigo", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_producto.Tables[0].Rows)
                {

                    list.Add(new Productos_VO(dr));

                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
