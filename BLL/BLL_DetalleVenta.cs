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
    internal class BLL_DetalleVenta
    {
        //CREATE
        public static string insertar_DetalleVentas(DetalleVenta_VO dtVenta)
        {
            
            return DAL_DetalleVentas.insertar_DetalleVentas(dtVenta);
        }
        //READ
        public static List<DetalleVenta_VO> get_DetalleVenta(params object[] parametros)
        {

          
                return DAL_DetalleVentas.get_DetalleVenta(parametros);


        }
        //UPDATE
        public static string Update_DetalleVenta(DetalleVenta_VO dtVenta)
        {
           
            return DAL_DetalleVentas.Update_DetalleVenta(dtVenta);

        }
        //DELETE
        public static string Delete_DetalleVenta(int id)
        {
           
            return DAL_DetalleVentas.Delete_DetalleVenta(id);

        }
    }
}
