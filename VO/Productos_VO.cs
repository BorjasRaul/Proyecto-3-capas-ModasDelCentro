using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Productos_VO
    {
        private int _ID_Producto;
        private string _Fecha_Creacion;
        private string _Codigo_Producto;
        private string _Modelo;
        private string _Marca;
        private string _Talla;
        private string _Color;
        private string _Estampado;
        private double _Precio;
        private int _Stock;

        public int ID_Producto { get => _ID_Producto; set => _ID_Producto = value; }
        public string Fecha_Creacion { get => _Fecha_Creacion; set => _Fecha_Creacion = value; }
        public string Codigo_Producto { get => _Codigo_Producto; set => _Codigo_Producto = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Talla { get => _Talla; set => _Talla = value; }
        public string Color { get => _Color; set => _Color = value; }
        public string Estampado { get => _Estampado; set => _Estampado = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public int Stock { get => _Stock; set => _Stock = value; }

        public Productos_VO()
        {
            ID_Producto = 0;
            Fecha_Creacion = string.Empty;
            Codigo_Producto = string.Empty;
            Modelo = string.Empty;
            Marca = string.Empty;
            Talla = string.Empty;
            Color = string.Empty;
            Estampado = string.Empty;
            Precio = 0;
            Stock = 0;

        }

        public Productos_VO(DataRow dr) {

            ID_Producto=int.Parse(dr["ID_Producto"].ToString());
            Fecha_Creacion=dr["Fecha_Creacion"].ToString();
            Codigo_Producto=dr["Codigo_Producto"].ToString();
            Modelo=dr["Modelo"].ToString();
            Marca=dr["Marca"].ToString();
            Talla=dr["Talla"].ToString();
            Color=dr["Color"].ToString();
            Estampado=dr["Estampado"].ToString();
            Precio=double.Parse(dr["Precio"].ToString());
            Stock =int.Parse(dr["Stock"].ToString());
        }


    }
}
