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
    public class BLL_Usuarios
    {
        //CREATE
        public static string insertar_Usuarios(Usuarios_VO usuario)
        {
            
            return DAL_Usuarios.insertar_Usuarios(usuario);
        }
        //READ
        public static List<Usuarios_VO> get_Usuarios(params object[] parametros)
        {
   
                return DAL_Usuarios.get_Usuarios(parametros);
        }

        public static List<Usuarios_VO> get_UsuariosLogin(params object[] parametros)
        {

            return DAL_Usuarios.get_UsuariosLogin(parametros);
        }
        //UPDATE
        public static string Update_Usuarios(Usuarios_VO usuario)
        {
            
            return DAL_Usuarios.Update_Usuarios(usuario);

        }
        //DELETE
        public static string Delete_Usuarios(int id)
        {
           
            return DAL_Usuarios.Delete_Usuarios(id);

        }


    }
}
