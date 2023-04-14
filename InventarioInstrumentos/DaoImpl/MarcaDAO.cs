using InventarioInstrumentos.Conexion;
using InventarioInstrumentos.Dao;
using InventarioInstrumentos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventarioInstrumentos.DaoImpl
{

    public class MarcaDAO : IMarcaDAO
    {
        ConexionBD conexionBD = new ConexionBD();
        public void Actualizar(int id, Marca marca)
        {
            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("UPDATE Marca SET NombreMarca = @NombreMarca WHERE Id = @idMarca", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdMarca", id);
                comando.Parameters.AddWithValue("@NombreMarca", marca.NombreMarca);
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
                SqlCommand comando = new SqlCommand("DELETE FROM Marca WHERE Id = @IdMarca", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdMarca", id);
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

        public void Insertar(Marca marca)
        {
            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("INSERT INTO Marca (NombreMarca) VALUES (@NombreMarca)", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@NombreMarca", marca.NombreMarca);
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

        public Marca ObtenerPorId(int id)
        {
            try
            {
                conexionBD.AbrirConexion();
                Marca marca = new Marca();
                SqlCommand comando = new SqlCommand("SELECT * FROM Marca WHERE Id = @IdMarca", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdMarca", id);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        marca.Id = (int)reader["Id"];
                        marca.NombreMarca = (string)reader["NombreMarca"];
                    }
                }
                return marca;


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

        public List<Marca> ObtenerTodos()
        {
            try
            {
                conexionBD.AbrirConexion();
                List<Marca> marcas = new List<Marca>();
                SqlCommand comando = new SqlCommand("SELECT * FROM Marca", conexionBD.ObtenerConexion());

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Marca marca = new Marca();

                        marca.Id = (int)reader["Id"];
                        marca.NombreMarca = (string)reader["NombreMarca"];
             
                        marcas.Add(marca);

                    }
                }
                return marcas;
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
