using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Usuarios_VO
    {

        private int _ID_Usuario;
        private string _Nombre_Usuario;
        private string _Contraseña;
        private int _Rol_ID;

        public int ID_Usuario { get => _ID_Usuario; set => _ID_Usuario = value; }
        public string Nombre_Usuario { get => _Nombre_Usuario; set => _Nombre_Usuario = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public int Rol_ID { get => _Rol_ID; set => _Rol_ID = value; }

        public Usuarios_VO()
        {


            ID_Usuario = 0;
            Nombre_Usuario = "";
            Contraseña = "";
            Rol_ID = 0;
        }

        public Usuarios_VO(DataRow dr) {

            ID_Usuario = int.Parse(dr["ID_Usuario"].ToString());
            Nombre_Usuario = dr["Nombre_Usuario"].ToString();
            Contraseña = dr["Contraseña"].ToString();
            Rol_ID = int.Parse(dr["Rol_ID"].ToString());
        }
    }
}
