using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Domicilios
    {
        //CREATE
        public static string insertar_Domicilio(Domicilios_VO domicilio)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Insert_Domicilio",
                    "Calle ", domicilio.Calle,
                    "Numero ", domicilio.Numero,
                    "Colonia ", domicilio.Colonia,
                    "Ciudad ", domicilio.Ciudad            
                    );

                if (respuesta != 0)
                {
                    salida = "Domicilio resgistrado con exito";
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
        public static List<Domicilios_VO> get_Domicilios(params object[] parametros)
        {

            List<Domicilios_VO> list = new List<Domicilios_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_domicilio = Metodos_Datos.execute_DataSet("SP_Select_Domicilio", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_domicilio.Tables[0].Rows)
                {

                    list.Add(new Domicilios_VO(dr));

                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }

        }
        //UPDATE
        public static string Update_Domicilio(Domicilios_VO domicilio)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Update_Domicilio",
                     "ID_Domicilio", domicilio.ID_Domicilio,
                     "ID_Camion", domicilio.Calle,
                     "Matricula ", domicilio.Numero,
                      "Capacidad ", domicilio.Colonia,
                       "Tipo_Camion ", domicilio.Ciudad
                  
                     );

                if (respuesta != 0)
                {
                    salida = "Domicilio actualizado con exito";
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
        public static string Delete_Domicilio(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Delete_Domicilio",
                     "@ID_Domicilio", id

                     );

                if (respuesta != 0)
                {
                    salida = "Camion eliminado con exito";
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
