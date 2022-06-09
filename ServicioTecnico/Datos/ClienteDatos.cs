using ServicioTecnico.Models;
using System.Data.SqlClient;
using System.Data;

namespace ServicioTecnico.Datos
{
    public class ClienteDatos
    {
        // ---------------------------------------------------------
        public List<ModelCliente> Listar()
        {
            var oLista = new List<ModelCliente>();  
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarClientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new ModelCliente()
                        {
                            id = Convert.ToInt32(dr["id"]),      
                            nombre = dr["nombre"].ToString(),
                            domicilio = dr["domicilio"].ToString(),
                            telefono = dr["telefono"].ToString()
                        });
                }
            }
            return oLista;
        }


        // ------------------------------------------------------------
        public ModelCliente Obtener(int id)
        {
            var oCliente = new ModelCliente();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerCliente", conexion);
                cmd.Parameters.AddWithValue("idCliente", id); 
                cmd.CommandType = CommandType.StoredProcedure; 

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCliente.id = Convert.ToInt32(dr["id"]);
                        oCliente.nombre = dr["nombre"].ToString();
                        oCliente.domicilio = dr["domicilio"].ToString();
                        oCliente.telefono = dr["telefono"].ToString();
                    }
                }             
            }
            return oCliente;
        }

        // --------------------------------------------------------------
        public bool Guardar(ModelCliente oCliente)
        {
            bool respuesta = false;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("IngresarCliente", conexion);  
                    cmd.Parameters.AddWithValue("nombre", oCliente.nombre);
                    cmd.Parameters.AddWithValue("domicilio", oCliente.domicilio);
                    cmd.Parameters.AddWithValue("telefono", oCliente.telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        // ------------------------------------------------------------------
        public bool Editar(ModelCliente oCliente)
        {
            bool respuesta = false;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EditarCliente", conexion);
                    cmd.Parameters.AddWithValue("id", oCliente.id);  
                    cmd.Parameters.AddWithValue("nombre", oCliente.nombre);
                    cmd.Parameters.AddWithValue("domicilio", oCliente.domicilio);
                    cmd.Parameters.AddWithValue("telefono", oCliente.telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }

            return respuesta;
        }


        // ------------------------------------------------------------------

        public bool Eliminar(int id)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EliminarCliente", conexion);
                    cmd.Parameters.AddWithValue("id", id);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
