using Microsoft.Data.SqlClient;
using System.Data;
using WebAppTareas.Models;

namespace WebAppTareas.Datos
{
    public class TareaDatos
    {
        public List<TareaModel> Listar()
        {

            var oLista = new List<TareaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SelectTareas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new TareaModel()
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Titulo = dr["titulo"].ToString(),
                            Descripcion = dr["descripcion"].ToString(),
                            Fechacreacion = Convert.ToDateTime(dr["fechacreacion"]),
                            Estado = Convert.ToInt32(dr["estado"]),
                        });

                    }
                }
            }

            return oLista;
        }

        public TareaModel Obtener(int id)
        {

            var oTarea = new TareaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("GetTarea", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oTarea.Id = Convert.ToInt32(dr["ID"]);
                        oTarea.Titulo = dr["titulo"].ToString();
                        oTarea.Descripcion = dr["descripcion"].ToString();
                        oTarea.Fechacreacion = Convert.ToDateTime(dr["fechacreacion"]);
                        oTarea.Estado = Convert.ToInt32(dr["estado"]);
                    }
                }
            }

            return oTarea;
        }

        public bool Guardar(TareaModel oTarea)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertTarea", conexion);
                    cmd.Parameters.AddWithValue("titulo", oTarea.Titulo);
                    cmd.Parameters.AddWithValue("descripcion", oTarea.Descripcion);
                    cmd.Parameters.AddWithValue("estado", oTarea.Estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception ex)
            {

                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool Editar(TareaModel oTarea)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("UpdateTarea", conexion);
                    cmd.Parameters.AddWithValue("id", oTarea.Id);
                    cmd.Parameters.AddWithValue("titulo", oTarea.Titulo);
                    cmd.Parameters.AddWithValue("descripcion", oTarea.Descripcion);
                    cmd.Parameters.AddWithValue("estado", oTarea.Estado);
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

        public bool Eliminar(int id)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("DeleteTarea", conexion);
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
