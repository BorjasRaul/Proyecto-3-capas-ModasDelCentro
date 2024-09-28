using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Usuarios
    {
        //CREATE
        public static string insertar_Usuarios(Usuarios_VO usuario)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("sp_InsertarUsuario",
                    "Nombre_Usuario ", usuario.Nombre_Usuario,
                    "Contraseña ", usuario.Contraseña
                   
                  
                    );

                if (respuesta != 0)
                {
                    salida = "Usuario resgistrado con exito";
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
        public static List<Usuarios_VO> get_Usuarios(params object[] parametros)
        {

            List<Usuarios_VO> list = new List<Usuarios_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet ds_cliente = Metodos_Datos.execute_DataSet("SP_Select_Usuarios", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                foreach (DataRow dr in ds_cliente.Tables[0].Rows)
                {

                    list.Add(new Usuarios_VO(dr));

                }
                return list;

            }
            catch (Exception e)
            {

                throw;
            }

        }
        public static List<Usuarios_VO> get_UsuariosLogin(params object[] parametros)
        {

            List<Usuarios_VO> list = new List<Usuarios_VO>();
            try
            {

                //crear un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_DAtaset" proviniente dela cclase metodos_datos
                DataSet usuarioLogin = Metodos_Datos.execute_DataSet("SP_Login", parametros);
                //recorreemos cada renglon existentes de nuestro ds creando objetos VO y añadiendo la lista
                if (usuarioLogin != null) {

                    foreach (DataRow dr in usuarioLogin.Tables[0].Rows)
                    {

                        list.Add(new Usuarios_VO(dr));

                    }
                }
               
                return list;

            }
            catch (Exception e)
            {

                throw;
            }

        }
        //UPDATE
        public static string Update_Usuarios(Usuarios_VO usuario)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("sp_Update_Usuario",
                    
                    "Nombre_Usuario ", usuario.Nombre_Usuario,
                    "Contraseña ", usuario.Contraseña
                    

                     );

                if (respuesta != 0)
                {
                    salida = "Usuario actualizado con exito";
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
        public static string Delete_Usuarios(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_NonQuery("SP_Delete_Usuario",
                     "@ID_Usuarios", id

                     );

                if (respuesta != 0)
                {
                    salida = "Usuario eliminado con exito";
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
