using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Empleados_VO
    {
         private int _Id_Empleado ;
         private string _Nombre ;
         private string _Apellido_Pat ;
         private string _Apellido_Mat ;
         private string _Fecha_Nacimiento ;
         private int _Domicilio_ID ;
         private string _Telefono ;
         private string _Fecha_Ingreso;

        public int Id_Empleado { get => _Id_Empleado; set => _Id_Empleado = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido_Pat { get => _Apellido_Pat; set => _Apellido_Pat = value; }
        public string Apellido_Mat { get => _Apellido_Mat; set => _Apellido_Mat = value; }
        public string Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public int Domicilio_ID { get => _Domicilio_ID; set => _Domicilio_ID = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Fecha_Ingreso { get => _Fecha_Ingreso; set => _Fecha_Ingreso = value; }

        public Empleados_VO() {
            Id_Empleado = 0;
            Nombre = "";
            Apellido_Pat = "";
            Apellido_Mat = "";
            Fecha_Nacimiento = "";
            Domicilio_ID = 0;
            Telefono = "";
            Fecha_Ingreso = "";

        }
        public Empleados_VO(DataRow dr)
        {
            Id_Empleado = int.Parse(dr["Id_Empleado"].ToString());
            Nombre = dr["Nombre"].ToString();
            Apellido_Pat = dr["Apellido_Pat"].ToString();
            Apellido_Mat = dr["Apellido_Mat"].ToString(); 
            Fecha_Nacimiento = dr["Fecha_Nacimiento"].ToString();
            Domicilio_ID = string.IsNullOrEmpty(dr["Domicilio_ID"].ToString()) ? 0 : int.Parse(dr["Domicilio_ID"].ToString());
            Telefono = dr["Telefono"].ToString(); 
            Fecha_Ingreso = dr["Fecha_Ingreso"].ToString(); 

        }

    }
}
