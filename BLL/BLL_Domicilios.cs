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
    public class BLL_Domicilios
    {
        //CREATE
        public static string insertar_Domicilio(Domicilios_VO domicilio)
        {
            
            return DAL_Domicilios.insertar_Domicilio(domicilio);
        }
        //READ
        public static List<Domicilios_VO> get_Domicilios(params object[] parametros)
        {

                return DAL_Domicilios.get_Domicilios(parametros);

            

        }
        //UPDATE
        public static string Update_Domicilio(Domicilios_VO domicilio)
        {
            
            return DAL_Domicilios.Update_Domicilio(domicilio);

        }
        //DELETE
        public static string Delete_Domicilio(int id)
        {
            
            return DAL_Domicilios.Delete_Domicilio(id);

        }
    }
}
