using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Domicilios_VO
    {
        private int _ID_Domicilio;
        private string _Calle;
        private string _Numero;
        private string _Colonia;
        private string _Ciudad;



        public int ID_Domicilio { get => _ID_Domicilio; set => _ID_Domicilio = value; }
        public string Calle { get => _Calle; set => _Calle = value; }
        public string Numero { get => _Numero; set => _Numero = value; }
        public string Colonia { get => _Colonia; set => _Colonia = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }


        public Domicilios_VO()

        {
            ID_Domicilio = 0;
            Calle = "";
            Numero = "";
            Colonia = "";
            Ciudad = "";

        }
        public Domicilios_VO(DataRow dr)
        {

            ID_Domicilio = int.Parse(dr["ID_Domicilio"].ToString());
            Calle = dr["Calle"].ToString();
            Numero = dr["Numero"].ToString();
            Colonia = dr["Colonia"].ToString();
            Ciudad = dr["Ciudad"].ToString();
        }
    }
}
    


