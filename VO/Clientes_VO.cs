using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Clientes_VO
    {
   private int _ID_Clientes ;
   private string _Nombre ;
   private string _Apellido_Paterno ;
   private string _Apellido_Materno ;
   private string _Telefono ;
        private int _Domicilio_ID;

        public int ID_Clientes { get => _ID_Clientes; set => _ID_Clientes = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido_Paterno { get => _Apellido_Paterno; set => _Apellido_Paterno = value; }
        public string Apellido_Materno { get => _Apellido_Materno; set => _Apellido_Materno = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public int Domicilio_ID { get => _Domicilio_ID; set => _Domicilio_ID = value; }

        public Clientes_VO() {

            ID_Clientes=0;
            Nombre="";
            Apellido_Paterno="";
            Apellido_Materno="";
            Telefono="";
            Domicilio_ID=0;

        }
        public Clientes_VO(DataRow dr) {
            ID_Clientes= int.Parse(dr["ID_Clientes"].ToString());
            Nombre= dr["Nombre"].ToString();
            Apellido_Paterno= dr["Apellido_Paterno"].ToString();
            Apellido_Materno= dr["Apellido_Materno"].ToString();
            Telefono= dr["Telefono"].ToString();
            Domicilio_ID= int.Parse(dr["ID_Clientes"].ToString());

        }
    }
}
