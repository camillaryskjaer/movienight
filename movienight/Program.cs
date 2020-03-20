using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace movienight
{
    class Program
    {
        static void Main(string[] args)
        {                      
            List<Film> film = Filmmanager.GetFilms();
            foreach (Film item in film)
            {
                Console.WriteLine(item.Titel);
            }
            Console.WriteLine("");
            List<Actor> actors = Filmmanager.GetActors();
            foreach (Actor item in actors)
            {
                Console.WriteLine(item.Firstname + item.Lastname);
            }
            Console.ReadLine();

            Console.WriteLine("indtast film:");
            string searchfilms = Console.ReadLine();
            foreach (Film item in Filmmanager.SearchFilms(searchfilms))
            {
                Console.WriteLine(item.Titel);
            }
            Console.ReadLine();

            Console.WriteLine("indtast navn:");
            string searchactors = Console.ReadLine();
            foreach (Actor item in Filmmanager.SearchActors(searchactors))
            {
                Console.WriteLine(item.Firstname + item.Lastname);
            }
            Console.ReadLine();

            Console.WriteLine("indtast genre");
            string searchgenre = Console.ReadLine();
            foreach (Film item in Filmmanager.SearchGenre(searchgenre))
            {
                Console.WriteLine(item.Titel);
            }
            Console.ReadLine();

            Console.WriteLine("indtast ny film");
            string titel = Console.ReadLine();
            string release = Console.ReadLine();
            string description = Console.ReadLine();
            int genre = int.Parse(Console.ReadLine());
            Filmmanager.InsertFilm(new Film(titel, release, description, genre));

            Console.WriteLine("indtast firstname og lastname!");
            string firstname = Console.ReadLine();
            string lastname = Console.ReadLine();
                            
            Filmmanager.InsertActor(new Actor(firstname, lastname));

            
            Console.ReadLine();
        }
    }
}
