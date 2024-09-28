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
    public class BLL_Clientes
    {
        //CREATE
        public static string insertar_Clientes(Clientes_VO cliente)
        {
           
            return DAL_Clientes.insertar_Clientes(cliente);
        }
        //READ
        public static List<Clientes_VO> get_Clientes(params object[] parametros)
        {

            
                return DAL_Clientes.get_Clientes(parametros);


        }
        //UPDATE
        public static string Update_Clientes(Clientes_VO cliente)
        {
          
            return DAL_Clientes.Update_Clientes(cliente);

        }
        //DELETE
        public static string Delete_Clientes(int id)
        {
            
            return DAL_Clientes.Delete_Clientes(id);

        }
    }
}
