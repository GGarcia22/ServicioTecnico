using ServicioTecnico.Models;
using System.Data.SqlClient;
using System.Data;

namespace ServicioTecnico.Datos
{
    public class ServicioDatos
    {
        // ------------------------------------------------------------------
        public List<ModelServicio> Listar()
        {
            var oLista = new List<ModelServicio>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarServicios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new ModelServicio()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            dispositivo = dr["dispositivo"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                            estado = dr["estado"].ToString(),
                            fechaDeIngreso = Convert.ToDateTime(dr["fechaDeIngreso"])
                        });
                }
            }
            return oLista;
        }


        // ------------------------------------------------------------------

        public ModelServicio Obtener(int id)
        {
            var oServicio = new ModelServicio();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerServicio", conexion);
                cmd.Parameters.AddWithValue("idServicio", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oServicio.id = Convert.ToInt32(dr["id"]);
                        oServicio.idCliente = Convert.ToInt32(dr["idCliente"]);
                        oServicio.dispositivo = dr["dispositivo"].ToString();
                        oServicio.descripcion = dr["descripcion"].ToString();
                        oServicio.estado = dr["estado"].ToString();
                        oServicio.fechaDeIngreso = Convert.ToDateTime(dr["fechaDeIngreso"]);
                    }
                }
            }
            return oServicio;
        }


        public List<ModelServicio> ObtenerTodos(int id)
        {
            var oListaServicios = new List<ModelServicio>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerServiciosDe", conexion);
                cmd.Parameters.AddWithValue("idCliente", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oListaServicios.Add(new ModelServicio()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            dispositivo = dr["dispositivo"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                            estado = dr["estado"].ToString(),
                            fechaDeIngreso = Convert.ToDateTime(dr["fechaDeIngreso"])
                        });
                }
            }
            return oListaServicios;
        }

        // ------------------------------------------------------------------
        public bool Guardar(ModelServicio oServicio)
        {
            bool respuesta = false;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("IngresarServicio", conexion);
                    cmd.Parameters.AddWithValue("idCliente", oServicio.idCliente);
                    cmd.Parameters.AddWithValue("dispositivo", oServicio.dispositivo);
                    cmd.Parameters.AddWithValue("descripcion", oServicio.descripcion);
                    cmd.Parameters.AddWithValue("estado", oServicio.estado);
                    cmd.Parameters.AddWithValue("fechaDeIngreso", oServicio.fechaDeIngreso);
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
        public bool Editar(ModelServicio oServicio)
        {
            bool respuesta = false;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EditarServicio", conexion);
                    cmd.Parameters.AddWithValue("id", oServicio.id);
                    cmd.Parameters.AddWithValue("idCliente", oServicio.idCliente);
                    cmd.Parameters.AddWithValue("dispositivo", oServicio.dispositivo);
                    cmd.Parameters.AddWithValue("descripcion", oServicio.descripcion);
                    cmd.Parameters.AddWithValue("estado", oServicio.estado);
                    cmd.Parameters.AddWithValue("fechaDeIngreso", oServicio.fechaDeIngreso);
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
                    SqlCommand cmd = new SqlCommand("EliminarServicio", conexion);
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
