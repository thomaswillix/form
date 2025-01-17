﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto.Controladores
{
    public class ImagenDAO
    {

        public DataTable obtenerImagenes()
        {
            // Cadena de conexión a la base de datos
            string connectionString = ConnectionDB.construirCadenaConexión();
            // Query para obtener las imagenes
            string query = "SELECT * FROM Imagenes";

            // Crear una tabla para almacenar los resultados
            DataTable dataTable = new DataTable();

            // Crear la conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                // Crear un adaptador de datos
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    // Llenar la tabla con los resultados de la consulta
                    adapter.Fill(dataTable);
                }
                connection.Close();
            }

            return dataTable;
        }
        public string obtenerImagen(string usu)
        {
            // Cadena de conexión a la base de datos
            string connectionString = ConnectionDB.construirCadenaConexión();
            // Query para obtener las imagenes
            string query = "SELECT foto FROM Imagenes where usuario = @usu";

            string sReturnString = null;
            using (SqlConnection connection = new SqlConnection(connectionString)) //Access database
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usu", usu);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        sReturnString = (string)reader.GetValue(0);
                        break;
                    }
                }
                return sReturnString;
            }
        }

        // Modificado: Ahora los parámetros son pasados como argumentos
        public void actualizarImagenes(string usuario, string foto)
        {
            // Cadena de conexión a la base de datos
            // Ver método construirCadenaConexión más arriba
            string connectionString = ConnectionDB.construirCadenaConexión();
            // Query de inserción
            string query = "Update Imagenes set foto = @foto where usuario = @usuario";

            // Crear la conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                // Crear un objeto SqlCommand con la consulta y la conexión
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros y sus valores
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@foto", foto);
                    try
                    {
                        // Ejecutar la consulta de inserción
                        int registrosAfectados = command.ExecuteNonQuery();
                        MessageBox.Show($"Se actualizó correctamente la foto de perfil en la base de datos, vuelva a iniciar sesión para ver los cambios");
                        connection.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Error al actualizar la foto de perfil");
                        connection.Close();
                    }
                }
            }
        }
        public void insertarUsuario(string usuario)
        {
            // Cadena de conexión a la base de datos
            // Ver método construirCadenaConexión más arriba
            string connectionString = ConnectionDB.construirCadenaConexión();
            // Query de inserción
            string query = "INSERT INTO Imagenes (usuario) VALUES (@usuario)";

            // Crear la conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                // Crear un objeto SqlCommand con la consulta y la conexión
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros y sus valores
                    command.Parameters.AddWithValue("@usuario", usuario);
                    try
                    {
                        // Ejecutar la consulta de inserción
                        int registrosAfectados = command.ExecuteNonQuery();
                        MessageBox.Show($"Se insertó correctamente el registro. Registros afectados: {registrosAfectados}");
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar el registro: {ex.Message}");
                        connection.Close();
                    }
                }
            }
        }

        public bool existeFoto(string ruta)
        {
            // Cadena de conexión a la base de datos
            string connectionString = ConnectionDB.construirCadenaConexión();
            // Query para obtener los jugadores
            string query = "SELECT foto FROM Imagenes where foto = @ruta";

            // Crear la conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros y sus valores
                    command.Parameters.AddWithValue("@ruta", ruta);
                    try
                    {
                        // Ejecutar la consulta de inserción
                        int registrosAfectados = command.ExecuteNonQuery();
                        MessageBox.Show($"Se encontró la foto");
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al buscar la foto: {ex.Message}");
                        connection.Close();
                        return false;
                    }
                }
            }
        }
        public bool existeUsu(string usu)
        {
            // Cadena de conexión a la base de datos
            string connectionString = ConnectionDB.construirCadenaConexión();
            // Query para obtener los jugadores
            string query = "SELECT usuario FROM Imagenes where usuario = @usu";

            // Crear una tabla para almacenar los resultados
            DataTable dataTable = new DataTable();

            // Crear la conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros y sus valores
                    command.Parameters.AddWithValue("usu", SqlDbType.VarChar).Value = usu;
                    try
                    {
                        // Ejecutar la consulta de inserción
                        int registrosAfectados = command.ExecuteNonQuery();
                        MessageBox.Show($"Se encontró el usuario.");
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Error de búsqueda");
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public int numeroRegistros()
        {
            // Cadena de conexión a la base de datos
            string connectionString = ConnectionDB.construirCadenaConexión();
            // Query para obtener los jugadores
            string query = "SELECT * FROM Imagenes count(usuario)";
            int result = 0;
            // Crear la conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    result = (int)command.ExecuteScalar();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar el número de registros: {ex.Message}");
                    connection.Close();
                    return result;
                }
                // Crear un adaptador de datos
            }
            return result;
        }
    }
}
