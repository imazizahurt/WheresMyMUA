using System.Collections.Generic;
using WheresMyMUA.Models;
using MySql.Data.MySqlClient;

namespace WheresMyMUA
{
    public class ArtistsRepository
    {
        public static string ConnectionString { get; set; }

        public List<Artist> GetAllProducts()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            List<Artist> artists = new List<Artist>();

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, Name, Specialty, Location, Phone FROM artists;";

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Artist artist = new Artist()
                    {
                        ID = (int)dataReader["ID"],
                        Name = dataReader["Name"].ToString(),
                        Specialty = dataReader["Specialty"].ToString(),
                        Location = dataReader["Location"].ToString(),
                        Phone = (int)dataReader["Phone"]
                    };

                    artists.Add(artist);
                }

                return artists;
            }
        }

        public int InsertArtist(string name, string specialty, string location, int phone)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO Artists (Name, Specialty, Location, Phone) " +
                                  "VALUES (@name, @specialty, @location, @phone);";
                                                                  //removed category id
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("specialty", specialty);
                cmd.Parameters.AddWithValue("location", location);
                cmd.Parameters.AddWithValue("phone", phone);

                //  STOPPED HERE....START FROM HERE

                return cmd.ExecuteNonQuery();
            }
        }

        /*public int UpdateProduct(Product product)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Products SET Name = @name, Price = @price " +
                                  "WHERE ProductID = @pid";
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("pid", product.Id);

                return cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM Products " +
                                                    "WHERE ProductID=" + id, conn);
                cmd.ExecuteNonQuery();
            }
        }*/

        public List<Artist> GetArtistsByName(string Name)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            List<Artist> artist = new List<Artist>();

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, Name, Specialty, Location, Phone " +
                                  "FROM artists " +
                                  "WHERE Name = @xyz " +
                                  "ORDER BY ID";
                cmd.Parameters.AddWithValue("xyz", Name);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Artist artists = new Artist()
                    {
                        ID = (int)dataReader["ID"],
                        Name = dataReader["Name"].ToString(),
                        Specialty = dataReader["Specialty"].ToString(),
                        Location = dataReader["Location"].ToString(),
                        Phone = (int)dataReader["Phone"]
                    };

                    artist.Add(artists);
                }

                return artist;
            }
        }

        public Artist GetArtist(int id)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, Name, Specialty, Location, Phone " +
                                  "FROM artists " +
                                  "WHERE ID=" + id;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    Artist artist = new Artist()
                    {
                        ID = (int)dataReader["ID"],
                        Name = dataReader["Name"].ToString(),
                        Specialty = dataReader["Specialty"].ToString(),
                        Location = dataReader["Location"].ToString(),
                        Phone = (int)dataReader["Phone"]
                    };

                    return artist;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}