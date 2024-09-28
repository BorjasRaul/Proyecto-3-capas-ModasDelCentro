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
    public class BLL_Ventas
    {
        //CREATE
        public static string insertar_Ventas(Ventas_VO venta)
        {
            
            return DAL_Ventas.insertar_Ventas(venta);
        }
        //READ
        public static List<Ventas_VO> get_Ventas(params object[] parametros)
        {

            
                return DAL_Ventas.get_Ventas(parametros);

            

        }
        //UPDATE
        public static string Update_Ventas(Ventas_VO venta)
        {
            
            return DAL_Ventas.Update_Ventas(venta);

        }
        //DELETE
        public static string Delete_Ventas(int id)
        {
            
            return DAL_Ventas.Delete_Ventas(id);

        }

        public static List<Productos_VO> get_VentasByCodigo(params object[] parametros)
        {
            return DAL_Productos.get_VentasByCodigo(parametros);
        }
    }
}
