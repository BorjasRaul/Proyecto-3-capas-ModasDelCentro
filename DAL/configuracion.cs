using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class configuracion
    {
        static string _cadenaConexion = @"Data Source=LAPTOP-1OT8ER8T;Initial Catalog=ModasDelCentro_DB;Integrated Security=true;";

        public static string CadenaConexeion {

            get { return _cadenaConexion; }
        }

    }
}
