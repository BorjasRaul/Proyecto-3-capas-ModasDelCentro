using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Metodos_Datos
    {  
        public static DataSet execute_DataSet(string sp, params object[] parametros)
        {

            //Instancia un DS => objeto ADO
            DataSet ds = new DataSet();

            //obtenemos la cadena de conexion desde la clase configuracion
            string cadenaConexion = configuracion.CadenaConexeion;
            //crear una conexion => sqlconnection objeto ADO
            SqlConnection con = new SqlConnection(cadenaConexion);
            try
            {
                //verificamos si la conexion esta abierta
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    //comando para sql (sp,conexion)=> sqlcommand objeto ADO
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;
                    //validamos si existen y estan completos los parametros
                    //si es diferenet de null y su residuo es diferente de 0 
                    //parametros ={clave,error}

                    if (parametros != null && parametros.Length % 2 != 0)
                    {

                        throw new Exception("Los parametros deben de estar eb pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {

                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());

                        }
                        //Abrimos la conexion
                        con.Open();
                        //ejecutamps el comando
                        //sqlAdapter => objeto de ADO
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //llenamos el ds
                        adapter.Fill(ds);
                        con.Close();
                    }
                }
                return ds;
            }
            catch (Exception e)
            {

                return null;

            }
            finally
            {
                //Verificamos si la conexion esta abierta 
                if (con.State == ConnectionState.Open)
                {

                    con.Close();
                }
            }
        }


        public static int execute_scalar(string sp, params object[] parametros)
        {

            //Variable para el control del resultado
            int id = 0;
            DataSet ds = new DataSet();

            //obtenemos la cadena de conexion desde la clase configuracion
            string cadenaConexcion = configuracion.CadenaConexeion;
            //crear una conexion => sqlconnection objeto ADO
            SqlConnection con = new SqlConnection(cadenaConexcion);
            try
            {
                //verificamos si la conexion esta abierta
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    //comando para sql (sp,conexion)=> sqlcommand objeto ADO
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;
                    //validamos si existen y estan completos los parametros
                    //si es diferenet de null y su residuo es diferente de 0 
                    //parametros ={clave,error}

                    if (parametros != null && parametros.Length % 2 != 0)
                    {

                        throw new Exception("Los parametros deben de estar eb pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i=i+2)
                        {

                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());

                        }
                        //Abrimos la conexion
                        con.Open();
                        //ejecutamos el comando 

                        var result = cmd.ExecuteScalar().ToString();

                        id = int.Parse(result);
                        //cerramos la conexion
                        con.Close();
                    }
                }
                return id;
            }
            catch (Exception e)
            {

                return 0;

            }
            finally
            {
                //Verificamos si la conexion esta abierta 
                if (con.State == ConnectionState.Open)
                {

                    con.Close();
                }
            }
        }

        public static int execute_NonQuery(string sp, params object[] parametros)
        {

            //Variable para el control del resultado
            int id = 0;
            DataSet ds = new DataSet();

            //obtenemos la cadena de conexion desde la clase configuracion
            string cadenaConexcion = configuracion.CadenaConexeion;
            //crear una conexion => sqlconnection objeto ADO
            SqlConnection con = new SqlConnection(cadenaConexcion);
            try
            {
                //verificamos si la conexion esta abierta
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    //comando para sql (sp,conexion)=> sqlcommand objeto ADO
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;
                    //validamos si existen y estan completos los parametros
                    //si es diferenet de null y su residuo es diferente de 0 
                    //parametros ={clave,error}

                    if (parametros != null && parametros.Length % 2 != 0)
                    {

                        throw new Exception("Los parametros deben de estar eb pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {

                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());

                        }
                        //Abrimos la conexion
                        con.Open();
                        //ejecutamos el comando 
                        id = cmd.ExecuteNonQuery();
                        
                        con.Close();
                    }
                }
                return id;
            }
            catch (Exception e)
            {

                return 0;

            }
            finally
            {
                //Verificamos si la conexion esta abierta 
                if (con.State == ConnectionState.Open)
                {

                    con.Close();
                }
            }
        }

    }
}
