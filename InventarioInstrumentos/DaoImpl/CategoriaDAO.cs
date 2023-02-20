﻿using InventarioInstrumentos.Conexion;
using InventarioInstrumentos.Dao;
using InventarioInstrumentos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioInstrumentos.DaoImpl
{
    public class CategoriaDAO : ICategoriaDAO
    {

        ConexionBD conexionBD = new ConexionBD();


        public void Actualizar(Categoria categoria)
        {
            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("UPDATE Categoria SET NombreCategoria = @NombreCategoria", conexionBD.conexion);
                comando.Parameters.AddWithValue("@NombreCategoria", categoria.NombreCategoria);
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
                SqlCommand comando = new SqlCommand("DELETE FROM Categoria WHERE Id = @IdCategoria", conexionBD.conexion);
                comando.Parameters.AddWithValue("@IdCategoria", id);
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

        public void Insertar(Categoria categoria)
        {

            try
            {
                conexionBD.AbrirConexion();
                SqlCommand comando = new SqlCommand("INSERT INTO Categoria (NombreCategoria) VALUES (@NombreCategoria)", conexionBD.conexion);
                comando.Parameters.AddWithValue("@NombreCategoria", categoria.NombreCategoria);
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

        public Categoria ObtenerPorId(int id)
        {
            try
            {
                conexionBD.AbrirConexion();
                Categoria categoria = new Categoria();
                SqlCommand comando = new SqlCommand("SELECT * FROM Categoria WHERE Id = @IdCategoria", conexionBD.conexion);
                comando.Parameters.AddWithValue("@IdCategoria", id);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        categoria.Id = (int)reader["Id"];
                        categoria.NombreCategoria = (string)reader["NombreCategoria"];
                    }
                }
                return categoria;


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

        public List<Categoria> ObtenerTodos()
        {
            try
            {
                conexionBD.AbrirConexion();
                List<Categoria> categorias = new List<Categoria>();
                SqlCommand comando = new SqlCommand("SELECT * FROM Categoria", conexionBD.conexion);


                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Categoria categoria = new Categoria()
                        {
                            Id = (int)reader["Id"],
                            NombreCategoria = (string)reader["NombreCategoria"]
                        };
                        categorias.Add(categoria);

                    }
                }
                return categorias;


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
    }
}