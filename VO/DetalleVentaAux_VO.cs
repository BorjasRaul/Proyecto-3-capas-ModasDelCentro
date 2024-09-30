using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VO
{
    [Serializable]
    public class DetalleVentaAux_VO
    {
        private int _ID_Producto;
        private string _Codigo_Producto;
        private string _Modelo;
        private string _Marca;
        private string _Talla;
        private double _Precio;
        private int _stock;
        private int _Cantidad;
        private double _PXC;
        private string _Descripcion;

        public int ID_Producto { get => _ID_Producto; set => _ID_Producto = value; }
        public string Codigo_Producto { get => _Codigo_Producto; set => _Codigo_Producto = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Talla { get => _Talla; set => _Talla = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double PXC { get => _PXC; set => _PXC = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }

        public DetalleVentaAux_VO()
        {
            ID_Producto = 0;
            Codigo_Producto = "";
            Modelo = "";
            Marca = "";
            Talla = "";
            Precio = 0;
            Stock = 0;
            Cantidad = 0;
            PXC = 0;
            Descripcion = "";
        }
    }
}
