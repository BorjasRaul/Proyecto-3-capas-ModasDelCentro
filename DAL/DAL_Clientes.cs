using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Clientes
    {
        //CREATE
        public static string insertar_Clientes(Clientes_VO cliente)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Insert_Cliente",
                    "Nombre ", cliente.Nombre,
                    "Apellido_Paterno ", cliente.Apellido_Paterno,
                    "Apellido_Materno ", cliente.Apellido_Materno,
                    "Telefono ", cliente.Telefono
                    );

                if (respuesta != 0)
                {
                    salida = "Cliente resgistrado con exito";
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
        public static List<Clientes_VO> get_Clientes(params object[] parametros)
        {

            List<Clientes_VO> list = new List<Clientes_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_cliente = Metodos_Datos.execute_DataSet("SP_Select_Cliente", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_cliente.Tables[0].Rows)
                {

                    list.Add(new Clientes_VO(dr));

                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }

        }
        //UPDATE
        public static string Update_Clientes(Clientes_VO cliente)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Update_Cliente",
                    "ID_Clientes", cliente.ID_Clientes,
                    "Nombre ", cliente.Nombre,
                    "Apellido_Paterno ", cliente.Apellido_Paterno,
                    "Apellido_Materno ", cliente.Apellido_Materno,
                    "Telefono ", cliente.Telefono

                     );

                if (respuesta != 0)
                {
                    salida = "Cliente actualizado con exito";
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
        public static string Delete_Clientes(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Delete_Cliente",
                     "@ID_Clientes", id

                     );

                if (respuesta != 0)
                {
                    salida = "Cliente eliminado con exito";
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
