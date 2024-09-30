using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Ventas_VO
    {
        //private int _ID_Venta;
        private double _Total;
        private int _Empleado_ID;
        private int _Cliente_ID;
        private int _Status_ID;
        //private int _Folio;
        //private string _Fecha_Venta;


        //public int ID_Venta { get => _ID_Venta; set => _ID_Venta = value; }
        public double Total { get => _Total; set => _Total = value; }
        public int Empleado_ID { get => _Empleado_ID; set => _Empleado_ID = value; }
        public int Cliente_ID { get => _Cliente_ID; set => _Cliente_ID = value; }
        public int Status_ID { get => _Status_ID; set => _Status_ID = value; }
        /// <summary>
        /// public int Folio { get => _Folio; set => _Folio = value; }
        /// </summary>
      ///  public string Fecha_Venta { get => _Fecha_Venta; set => _Fecha_Venta = value; }
        public Ventas_VO()
        {
            //ID_Venta = 0;
            Total = 0;
            Empleado_ID = 0;
            Cliente_ID = 0;
            Status_ID = 0;
            //Folio = 0;
            //Fecha_Venta = "";

        }

        public Ventas_VO(DataRow dr)
        {
            //ID_Venta = int.Parse(dr["ID_Venta"].ToString());
            Total = double.Parse(dr["Total"].ToString());
            Empleado_ID = int.Parse(dr["Empleado_ID"].ToString());
            Cliente_ID = int.Parse(dr["Cliente_ID"].ToString());
            Status_ID = int.Parse(dr["Status_ID"].ToString());
            //Folio = int.Parse(dr["Folio"].ToString());
            //Fecha_Venta = dr["Fecha_Venta"].ToString();

        }
    }
}
