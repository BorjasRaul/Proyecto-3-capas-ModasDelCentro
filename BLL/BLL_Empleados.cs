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
    public class BLL_Empleados
    {
        //CREATE
        public static string insertar_Empleado(Empleados_VO empleado)
        {
            
            return DAL_Empleados.insertar_Empleado(empleado);
        }
        //READ
        public static List<Empleados_VO> get_Empleado(params object[] parametros)
        {

                return DAL_Empleados.get_Empleado(parametros);


        }
        //UPDATE
        public static string Update_Empledo(Empleados_VO empleado)
        {
            
            return DAL_Empleados.Update_Empledo(empleado);

        }
        //DELETE
        public static string Delete_Empleado(int id)
        {
            
            return DAL_Empleados.Delete_Empleado(id);

        }
    }
}
