using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Productos
    {
        //CREATE
        public static string insertar_Producto(Productos_VO producto)
        {
            
            return DAL_Productos.insertar_Producto(producto);
        }
        //READ
        public static List<Productos_VO> get_Producto(params object[] parametros)
        {

          
                return DAL_Productos.get_Producto(parametros);

        }
        //UPDATE
        public static string Update_Producto(Productos_VO producto)
        {
            
            return DAL_Productos.Update_Producto(producto);

        }
        //DELETE
        public static string Delete_Producto(int id)
        {
            
            return DAL_Productos.Delete_Producto(id);

        }

        public static List<string> get_ProductoByFecha(params object[] parametros)
        {

            return DAL_Productos.get_ProductoByFecha(parametros);
        }

        public static object get_ProductoByDate(params object[] parametros)
        {
            return DAL_Productos.get_ProductoByDate(parametros);
        }
    }
}
