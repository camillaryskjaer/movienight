using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Hvor er alle dine kodekommentar og hvad med fejlhåndtering???????????
namespace movienight
{
    public class Dalmanager
    {
        private static string cs = @"Data Source = (localdb)\MSSQLLocaldb;Initial Catalog = MovieNightNew; Integrated Security = True";

        public static List<Film> GetFilms()
        {
            List<Film> films = new List<Film>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, titel, release_date, description, genre FROM Movies1", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string titel = (string)rdr["titel"];
                    string description = (string)rdr["description"];
                    string year = (string)rdr["release_date"];
                    int genre = (int)rdr["genre"];
                    Film f = new Film(id, titel, description, year, genre);


                    films.Add(f);
                }
            }
            return films;
        }
        public static List<Actor> GetActors()
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, FirstName, LastName FROM Actors", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string firstname = (string)rdr["FirstName"];
                    string lastname = (string)rdr["LastName"];
                    Actor a = new Actor(id, firstname, lastname);

                    actors.Add(a);
                }
            }
            return actors;
        }
        public static List<Film> SearchFilms(string search)
        {
            List<Film> films = new List<Film>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                
                SqlCommand cmd = new SqlCommand("SELECT ID, titel, release_date, description, genre FROM Movies1 where titel like @search", connection);
                SqlParameter sp = new SqlParameter();

                sp.ParameterName = "@search";

                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string titel = (string)rdr["titel"];
                    string year = (string)rdr["release_date"];
                    string description = (string)rdr["description"];
                    int genre = (int)rdr["genre"];

                    Film f = new Film(id, titel, description, year, genre);

                    films.Add(f);
                }
                             
            }
            return films;
        }
        public static List<Actor> SearchActors(string search)
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT ID, FirstName, LastName FROM Actors where FirstName like @search", connection);
                SqlParameter sp = new SqlParameter();

                sp.ParameterName = "@search";

                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string firstname = (string)rdr["FirstName"];
                    string lastname = (string)rdr["LastName"];
                    Actor a = new Actor(id, firstname, lastname);

                    actors.Add(a);
                }

            }
            return actors;
        }
        public static List<Film> SearchGenre(string search)
        {
            List<Film> genres = new List<Film>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT titel, release_date, description, Movies1.genre FROM Movies1 JOIN Genres ON Movies1.genre = Genres.ID WHERE Genres.genre = @search", connection);
                SqlParameter sp = new SqlParameter();

                sp.ParameterName = "@search";

                sp.Value = search;
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    string titel = (string)rdr["titel"];
                    string year = (string)rdr["release_date"];
                    string description = (string)rdr["description"];                
                    int genre = (int)rdr["genre"];
                    Film film = new Film(titel, description, year, genre);

                    genres.Add(film);
                }

            }
            return genres;
        }
        public static Film InsertMovie(Film b)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Movies1(titel, release_date, description, genre) OUTPUT INSERTED.ID values(@tn,@rd,@dn,@gi)", connection);

                cmd.Parameters.Add(new SqlParameter("@tn", b.Titel));
                cmd.Parameters.Add(new SqlParameter("@rd", b.Year));
                cmd.Parameters.Add(new SqlParameter("@dn", b.Description));
                cmd.Parameters.Add(new SqlParameter("@gi", b.Genre));
                int newId = (Int32)cmd.ExecuteScalar();
                b.Id = newId;
            }
            return b;
        }
        public static Actor InsertActor(Actor a)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Actors(FirstName,LastName) OUTPUT INSERTED.ID  values(@fn,@ln)", connection);
                
                cmd.Parameters.Add(new SqlParameter("@fn", a.Firstname));
                cmd.Parameters.Add(new SqlParameter("@ln", a.Lastname));               
                int newId = (Int32)cmd.ExecuteScalar();
                a.Id = newId;

            }
            return a;
        }
        

    }
}
