using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movienight
{
    public static class Filmmanager
    {
        public static List<Film> GetFilms()
        {
           return Dalmanager.GetFilms();
        }
        public static List<Actor> GetActors()
        {
            return Dalmanager.GetActors();
        }
        public static List<Film> SearchFilms(string search)
        {
            return Dalmanager.SearchFilms(search);
        }
        public static List<Actor> SearchActors(string search)
        {
            return Dalmanager.SearchActors(search);
        }
        public static List<Film> SearchGenre(string search)
        {
            return Dalmanager.SearchGenre(search);
        }
        public static Actor InsertActor(Actor a)
        {
            return Dalmanager.InsertActor(a);
        }
        public static Film InsertFilm(Film b)
        {
            return Dalmanager.InsertMovie(b);
        }
    }
}
