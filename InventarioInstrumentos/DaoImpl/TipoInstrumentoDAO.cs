using InventarioInstrumentos.Conexion;
using InventarioInstrumentos.Dao;
using InventarioInstrumentos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace InventarioInstrumentos.DaoImpl
{
    internal class TipoInstrumentoDAO : ITipoInstrumentoDAO
    {

        ConexionBD conexionBD = new ConexionBD();
        public void Actualizar(int id, TipoInstrumento tipoInstrumento)
        {
            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("UPDATE TipoInstrumento SET NombreInstrumento = @NombreInstrumento WHERE Id = @idTipo", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdTipo", id);
                comando.Parameters.AddWithValue("@NombreInstrumento", tipoInstrumento.NombreInstrumento);
                comando.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("DELETE FROM TipoInstrumento WHERE Id = @IdTipo", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdTipo", id);
                comando.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public void Insertar(TipoInstrumento tipoInstrumento)
        {
            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("INSERT INTO TipoInstrumento (NombreInstrumento) VALUES (@NombreInstrumento)", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@NombreInstrumento", tipoInstrumento.NombreInstrumento);
                comando.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public TipoInstrumento ObtenerPorId(int id)
        {
            try
            {
                conexionBD.AbrirConexion();
                TipoInstrumento tipoInstrumento = new TipoInstrumento();    
                SqlCommand comando = new SqlCommand("SELECT * FROM TipoInstrumento WHERE Id = @IdTipo", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdTipo", id);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        tipoInstrumento.Id = (int)reader["Id"];
                        tipoInstrumento.NombreInstrumento = (string)reader["NombreInstrumento"];
                    }
                }
                return tipoInstrumento;


            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public List<TipoInstrumento> ObtenerTodos()
        {
            try
            {
                conexionBD.AbrirConexion();
                List<TipoInstrumento> tiposInstrumento = new List<TipoInstrumento>();
                SqlCommand comando = new SqlCommand("SELECT * FROM TipoInstrumento", conexionBD.ObtenerConexion());

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TipoInstrumento tipoInstrumento = new TipoInstrumento();

                        tipoInstrumento.Id = (int)reader["Id"];
                        tipoInstrumento.NombreInstrumento = (string)reader["NombreInstrumento"];

                        tiposInstrumento.Add(tipoInstrumento);
                    }
                }

                return tiposInstrumento;

            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

        }
    }
}
