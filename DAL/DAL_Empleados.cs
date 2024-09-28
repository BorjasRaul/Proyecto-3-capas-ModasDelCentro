using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Empleados
    {
        //CREATE
        public static string insertar_Empleado(Empleados_VO empleado)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Insert_Empleado",
                    "Nombre ", empleado.Nombre,
                    "Apellido_Pat ", empleado.Apellido_Pat,
                    "Apellido_Mat ", empleado.Apellido_Mat,
                    "Fecha_Nacimiento ", empleado.Fecha_Nacimiento,
                    "Domicilio_ID ", empleado.Domicilio_ID,
                    "Telefono ", empleado.Telefono,
                    "Fecha_Ingreso ", empleado.Fecha_Ingreso
                    );

                if (respuesta != 0)
                {
                    salida = "Empleado resgistrado con exito";
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
        public static List<Empleados_VO> get_Empleado(params object[] parametros)
        {

            List<Empleados_VO> list = new List<Empleados_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_empleado = Metodos_Datos.execute_DataSet("SP_Select_Empleado", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_empleado.Tables[0].Rows)
                {

                    list.Add(new Empleados_VO(dr));

                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }

        }
        //UPDATE
        public static string Update_Empledo(Empleados_VO empleado)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Update_Empleado",
                     "Id_Empleado ", empleado.Id_Empleado,
                   "Nombre ", empleado.Nombre,
                    "Apellido_Pat ", empleado.Apellido_Pat,
                    "Apellido_Mat ", empleado.Apellido_Mat,
                    "Fecha_Nacimiento ", empleado.Fecha_Nacimiento,
                    "Domicilio_ID ", empleado.Domicilio_ID,
                    "Telefono ", empleado.Telefono,
                    "Fecha_Ingreso ", empleado.Fecha_Ingreso

                     );

                if (respuesta != 0)
                {
                    salida = "Empleado actualizado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {

                salida = "Erro: " + e.Message;
            }
            return salida;

        }
        //DELETE
        public static string Delete_Empleado(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Delete_Empleado",
                     "@ID_Empleado", id

                     );

                if (respuesta != 0)
                {
                    salida = "Empleado eliminado con exito";
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
