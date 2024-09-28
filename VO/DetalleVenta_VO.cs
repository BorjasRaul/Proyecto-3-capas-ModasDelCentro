using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class DetalleVenta_VO
    {
        private int _ID_Detalle_Venta;
        private int _Venta_ID;
        private int _Producto_ID;
        private int _Cantidad;
        private double _Precio_Unitario;
        private double _SubTotal;

        public int ID_Detalle_Venta { get => _ID_Detalle_Venta; set => _ID_Detalle_Venta = value; }
        public int Venta_ID { get => _Venta_ID; set => _Venta_ID = value; }
        public int Producto_ID { get => _Producto_ID; set => _Producto_ID = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Precio_Unitario { get => _Precio_Unitario; set => _Precio_Unitario = value; }
        public double SubTotal { get => _SubTotal; set => _SubTotal = value; }

        public DetalleVenta_VO()
        {


            ID_Detalle_Venta = 0;
            Venta_ID = 0;
            Producto_ID = 0;
            Cantidad = 0;
            Precio_Unitario = 0;
            SubTotal = 0;
        }
        public DetalleVenta_VO(DataRow dr) {

            ID_Detalle_Venta = int.Parse(dr[""].ToString());
            Venta_ID = int.Parse(dr[""].ToString());
            Producto_ID = int.Parse(dr[""].ToString());
            Cantidad = int.Parse(dr[""].ToString());
            Precio_Unitario = double.Parse(dr[""].ToString());
            SubTotal = double.Parse(dr[""].ToString());


        }
    }
}
