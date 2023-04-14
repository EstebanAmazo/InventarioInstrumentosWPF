using InventarioInstrumentos.Conexion;
using InventarioInstrumentos.Dao;
using InventarioInstrumentos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace InventarioInstrumentos.DaoImpl
{
    public class InstrumentoDAO : IInstrumentoDAO
    {
        

        ConexionBD conexionBD = new ConexionBD();

        public void Actualizar(int id, Instrumento instrumento)
        {
            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("UPDATE Instrumento SET Serial = @Serial, Modelo = @Modelo, Stock = @Stock, Precio = @Precio, Estado = @Estado, Gama = @Gama, FechaIngreso = @FechaIngreso, IdCategoria = @IdCategoria, IdMarca = @IdMarca, IdTipo = @IdTipo WHERE Id = @IdInstrumento;", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdInstrumento", id);
                comando.Parameters.AddWithValue("@Serial", instrumento.Serial);
                comando.Parameters.AddWithValue("@Modelo", instrumento.Modelo);
                comando.Parameters.AddWithValue("@Stock", instrumento.Stock);
                comando.Parameters.AddWithValue("@Precio", instrumento.Precio);
                comando.Parameters.AddWithValue("@Estado", instrumento.Estado);
                comando.Parameters.AddWithValue("@Gama", instrumento.Gama);
                comando.Parameters.AddWithValue("@FechaIngreso", instrumento.FechaIngreso);
                comando.Parameters.AddWithValue("@IdCategoria", instrumento.Categoria.Id);
                comando.Parameters.AddWithValue("@IdMarca", instrumento.Marca.Id);
                comando.Parameters.AddWithValue("IdTipo", instrumento.TipoInstrumento.Id);
                comando.ExecuteNonQuery();
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

        public bool Eliminar(int id)
        {
            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("DELETE FROM Instrumento WHERE Id = @IdInstrumento", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdInstrumento", id);
                comando.ExecuteNonQuery();
                return true;
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

        public void Insertar(Instrumento instrumento)
        {
            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("INSERT INTO Instrumento(Serial, Modelo, Stock, Precio, Estado, Gama, FechaIngreso, IdCategoria, IdMarca, IdTipo) VALUES (@Serial, @Modelo, @Stock, @Precio, @Estado, @Gama, @FechaIngreso, @IdCategoria, @IdMarca, @IdTipo);", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@Serial", instrumento.Serial);
                comando.Parameters.AddWithValue("@Modelo", instrumento.Modelo);
                comando.Parameters.AddWithValue("@Stock", instrumento.Stock);
                comando.Parameters.AddWithValue("@Precio", instrumento.Precio);
                comando.Parameters.AddWithValue("@Estado", instrumento.Estado);
                comando.Parameters.AddWithValue("@Gama", instrumento.Gama);
                comando.Parameters.AddWithValue("@FechaIngreso", instrumento.FechaIngreso);
                comando.Parameters.AddWithValue("@IdCategoria", instrumento.Categoria.Id);
                comando.Parameters.AddWithValue("@IdMarca", instrumento.Marca.Id);
                comando.Parameters.AddWithValue("IdTipo", instrumento.TipoInstrumento.Id);
                comando.ExecuteNonQuery();
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



        public Instrumento ObtenerPorId(int id)
        {
            try
            {
                conexionBD.AbrirConexion();
                Instrumento instrumento = new Instrumento();
                string consulta = "SELECT I.Id, I.Serial, I.Modelo, I.Stock, I.Precio, I.Estado, I.Gama, I.IdCategoria, I.IdMarca, I.IdTipo, C.Id AS IdCategoria, C.NombreCategoria, M.Id AS IdMarca, M.NombreMarca, T.Id AS IdTipo, T.NombreInstrumento " +
                    "FROM Instrumento I INNER JOIN Categoria C ON I.IdCategoria = C.Id " +
                    "INNER JOIN Marca M ON I.IdMarca = M.Id " +
                    "INNER JOIN TipoInstrumento T ON I.IdTipo = T.Id " + 
                    "WHERE I.Id = @IdInstrumento";
                SqlCommand comando = new SqlCommand(consulta, conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdInstrumento", id);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        instrumento.Id = (int)reader["Id"];
                        instrumento.Serial = (string)reader["Serial"];
                        instrumento.Modelo = (string)reader["Modelo"];
                        instrumento.Stock = (int)reader["Stock"];
                        instrumento.Precio = (decimal)reader["Precio"];
                        instrumento.Estado = (Estado)Enum.Parse(typeof(Estado), reader["Estado"].ToString());
                        instrumento.Gama = (Gama)Enum.Parse(typeof(Gama), reader["Gama"].ToString());
                  //      instrumento.FechaIngreso = (DateTime)reader["FechaIngreso"];
                        instrumento.Categoria = new Categoria()
                        {
                            Id = (int)reader["IdCategoria"],
                            NombreCategoria = (string)reader["NombreCategoria"]
                        };
                        instrumento.Marca = new Marca()
                        {
                            Id = (int)reader["IdMarca"],
                            NombreMarca = (string)reader["NombreMarca"]
                        };
                        instrumento.TipoInstrumento = new TipoInstrumento()
                        {
                            Id = (int)reader["IdTipo"],
                            NombreInstrumento = (string)reader["NombreInstrumento"]
                        };
                    }
                }
                return instrumento;
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

        public List<Instrumento> ObtenerTodos()
        {
            try
            {
                conexionBD.AbrirConexion();
                List<Instrumento> instrumentos= new List<Instrumento>();
                string consulta = "SELECT I.Id, I.Serial, I.Modelo, I.Stock, I.Precio, I.Estado, I.Gama, I.IdCategoria, I.FechaIngreso, I.IdMarca, I.IdTipo, C.Id AS IdCategoria, C.NombreCategoria, M.Id AS IdMarca, M.NombreMarca, T.Id AS IdTipo, T.NombreInstrumento " +
                    "FROM Instrumento I INNER JOIN Categoria C ON I.IdCategoria = C.Id " +
                    "INNER JOIN Marca M ON I.IdMarca = M.Id " +
                    "INNER JOIN TipoInstrumento T ON I.IdTipo = T.Id ";
                SqlCommand comando = new SqlCommand(consulta, conexionBD.ObtenerConexion());
      

                //

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                   while (reader.Read())
                    {
                        Instrumento instrumento = new Instrumento();

                        instrumento.Id = (int)reader["Id"];
                        instrumento.Serial = (string)reader["Serial"];
                        instrumento.Modelo = (string)reader["Modelo"];
                        instrumento.Stock = (int)reader["Stock"];
                        instrumento.Precio = (decimal)reader["Precio"];
                        instrumento.Estado = (Estado)Enum.Parse(typeof(Estado), reader["Estado"].ToString());
                        instrumento.Gama = (Gama)Enum.Parse(typeof(Gama), reader["Gama"].ToString());
                        instrumento.FechaIngreso = (DateTime)reader["FechaIngreso"];
                        instrumento.Categoria = new Categoria()
                        {
                            Id = (int)reader["IdCategoria"],
                            NombreCategoria = (string)reader["NombreCategoria"]
                        };
                        instrumento.Marca = new Marca()
                        {
                            Id = (int)reader["IdMarca"],
                            NombreMarca = (string)reader["NombreMarca"]
                        };
                        instrumento.TipoInstrumento = new TipoInstrumento()
                        {
                            Id = (int)reader["IdTipo"],
                            NombreInstrumento = (string)reader["NombreInstrumento"]
                        };

                        instrumentos.Add(instrumento);
                    }
                }
                return instrumentos;
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






        public string ObtenerNombreCategoria(int IdInstrumento)
        {

            try

            {

                conexionBD.AbrirConexion();
                string nombreCategoria = "";

                SqlCommand comando = new SqlCommand("SELECT C.NombreCategoria from Instrumento I INNER JOIN Categoria C on I.IdCategoria = C.Id WHERE I.Id = @Id;", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@Id", IdInstrumento);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nombreCategoria = (string)reader[0];
                    }
                }
                Console.WriteLine(nombreCategoria);

                return nombreCategoria;
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

        public string ObtenerNombreMarca(int id)
        {
            try
            {
                conexionBD.AbrirConexion();
                string nombreMarca = "";
                SqlCommand comando = new SqlCommand("SELECT M.NombreMarca from Instrumento I INNER JOIN Marca M on I.IdMarca = M.Id WHERE I.Id =@IdInstrumento;", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue(@"IdInstrumento", id);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nombreMarca = (string)reader[0];
                    }
                }

                return nombreMarca;
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

        public string ObtenerNombreTipo(int id)
        {
            try
            {
                conexionBD.AbrirConexion();
                string nombreTipo = "";
                SqlCommand comando = new SqlCommand("SELECT T.NombreInstrumento FROM Instrumento I INNER JOIN TipoInstrumento T ON I.IdTipo = T.Id WHERE I.Id =@IdInstrumento;", conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdInstrumento", id);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nombreTipo = (string)reader[0];
                    }
                }

                return nombreTipo;
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
