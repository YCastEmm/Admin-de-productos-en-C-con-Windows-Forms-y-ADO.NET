using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Productos.Persistidor
{
    public class ADOPersister : IPersistible
    {
        public static string ConnectionString = @"Data Source=DESKTOP-HFSE29V; Initial Catalog=ProductoDB;Integrated Security=True;TrustServerCertificate=True;";


        public List<Producto> Find(string partOfDescription)
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@partOfDescription", partOfDescription);
                    command.CommandText = @"
                        SELECT * FROM Producto
                        WHERE Descripcion LIKE '%' + @partOfDescription + '%'
                                ";

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable); //se ejecuta la consulta

                    productos = ConvertDataTableToList(dataTable);
                }
            }

            return productos;
        }


        private List<Producto> ConvertDataTableToList(DataTable dataTable)
        {
            List<Producto> productos = new List<Producto>();
            foreach (DataRow row in dataTable.Rows)
            {
                Producto producto = new Producto();
                producto.Id = Convert.ToInt32(row["ID"]);
                producto.Descripcion = row["Descripcion"].ToString();
                producto.Marca = row["Marca"].ToString();
                producto.Precio = Convert.ToDouble(row["Precio"]);
                producto.Stock = Convert.ToInt32(row["Stock"]);

                productos.Add(producto);
            }
            return productos;
        }

        public Producto Load(int id)
        {
            Producto producto = new Producto();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    //command.CommandText = @"
                    //    SELECT * 
                    //    FROM Producto
                    //    WHERE id = @id 
                    //            ";
                    command.CommandText = "Producto_sel";
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable); //se ejecuta la consulta

                    bool noExisteElProducto = (dataTable.Rows.Count == 0);
                    if (noExisteElProducto)
                        throw new Exception($"El producto con id = {id} no existe.");

                    List<Producto> productos = ConvertDataTableToList(dataTable);
                    producto = productos[0];
                }
            }

            return producto;
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    //command.CommandText = @"DELETE 
                    //                Producto 
                    //                WHERE Id = @id";

                    command.CommandText = @"Producto_del";

                    connection.Open();
                    int recordsAffecter = command.ExecuteNonQuery(); //INSERT, DELETE, UPDATE
                    connection.Close();

                    if (recordsAffecter != 1)
                    {
                        throw new Exception("Error, solo un producto tendria que eliminarse");
                    };
                }
            }
        }

        public void Remove(Producto producto)
        {
            this.Remove(producto.Id.Value);
        }

        public void Save(Producto producto)
        {
            if (producto.Id.HasValue)
                Update(producto); //Modificar el producto existente
            else
                Insert(producto); //Adiciona un nuevo producto         
        }

        private void Insert(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Marca", producto.Marca);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.CommandText = @"INSERT INTO Producto
                                               ([Descripcion]
                                               ,[Marca]
                                               ,[Precio]
                                               ,[Stock])
                                           VALUES
                                               (@Descripcion
                                               ,@Marca
                                               ,@Precio
                                               ,@Stock)";


                    connection.Open();
                    int recordsAffecter = command.ExecuteNonQuery(); //INSERT, DELETE, UPDATE
                    producto.Id = GetIdFromDB(command);
                    connection.Close();

                    if (recordsAffecter != 1)
                    {
                        throw new Exception("Error, solo un producto debe ser afectado.");
                    };
                }
            }
        }

        /// <summary>
        /// Consulta por el id del producto dado por la 
        /// base de datos.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private int GetIdFromDB(SqlCommand command)
        {
            command.Parameters.Clear();
            command.CommandText = "select @@IDENTITY";
            var objId = command.ExecuteScalar();
            int id = Convert.ToInt32(objId);
            return id;
        }

        private void Update(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", producto.Id);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Marca", producto.Marca);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.CommandText = @"
                                            UPDATE Producto
                                            SET [Descripcion] = @Descripcion,
                                                [Marca] = @Marca,
                                                [Precio] = @Precio,
                                                [Stock] = @Stock
                                            WHERE id = @id
                                        ";

                    connection.Open();
                    int recordsAffecter = command.ExecuteNonQuery(); //INSERT, DELETE, UPDATE
                    connection.Close();

                    if (recordsAffecter != 1)
                    {
                        throw new Exception("Error, solo un producto debe ser afectado.");
                    };
                }
            }
        }
    }
}
