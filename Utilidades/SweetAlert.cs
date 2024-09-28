using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Proyecto_3_capas_ModasDelCentro.Utilidades
{
    public class SweetAlert
    {

        public static void sweet_Alert(string titulo, string msg, string type, Page pg, Object obj)
        {

            string sa = "<script languaje='javascript'>" +
                "Swal.fire({" +
                " title: '" + titulo + "'," +
                " text: '" + msg + "'," +
                "  icon: '" + type + "'" +
                "});" +
                "</script>";
            //Referencia al tipo objeto que voy a trabajar
            Type csType = obj.GetType();
            //ClientScriptManager me ayuda a incrustar bloques de codigo de js en tiempo real 
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(csType, sa, sa);


        }
        public static void sweet_Alert(string titulo, string msg, string type, Page pg, Object obj, string dir)
        {

            string sa = "<script languaje='javascript'>" +
    "Swal.fire({" +
    "title: '" + titulo + "'," +
    "text: '" + msg + "'," +
    "icon: '" + type + "'" +
    "}).then((result)=>{" +
    "if(result.isConfirmed){" +
    "window.location.href = '" + dir + "'" +
    "}" +
    "});" +
    "</script>";
            //Referencia al tipo objeto que voy a trabajar
            Type csType = obj.GetType();
            //ClientScriptManager me ayuda a incrustar bloques de codigo de js en tiempo real 
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(csType, sa, sa);


        }
        public static void sweet_Alert_Update( string dir, Page pg, object obj)
        {



            var sa = "<script languaje='javascript'>" +
                  "Swal.fire({" +
                  "title: '¿Desea Actualizar el registro?'," +
                  "icon: 'info'," +
                  "showDenyButton: true," +
                  "confirmButtonText: 'Actualizar'," +
                  "denyButtonText: 'Cancelar'" +
                  "}).then((result) => {" +
                  "if (result.isDenied) {  " +
                  "window.location.href = '"+dir+"';" +
                  "} else if (result.isConfirmed) {  " +
                  "}" +
                  "});" +
                  "</script>";

            //Referencia al tipo objeto que voy a trabajar
            Type csType = obj.GetType();
            //ClientScriptManager me ayuda a incrustar bloques de codigo de js en tiempo real 
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(csType, sa, sa);
        }
        public static void sweet_Alert_Guardar(string titulo,string msg,string tipo,string dir, Page pg, object obj) {


            var sa = "<script type='text/javascript'>" +
                    "Swal.fire({position: 'top-end'," +
                    "icon: '" + tipo + "'," +
                    "title: '" + msg + "'," +
                    "showConfirmButton: false, timer: 1500}).then(() => {window.location.href = '" + dir + "';});" +
                    "</script>";
            //Referencia al tipo objeto que voy a trabajar
            Type csType = obj.GetType();
            //ClientScriptManager me ayuda a incrustar bloques de codigo de js en tiempo real 
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(csType, sa, sa);
        }
    }
}