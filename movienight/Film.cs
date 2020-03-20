using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movienight
{
    public class Film
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string titel;
        public string Titel
        {
            get { return titel; }
            set { titel = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string year;
        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        private int genre;
        public int Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public Film(string titel, string description, string year, int genre)
        {
            this.titel = titel;
            this.description = description;
            this.year = year;
            this.genre = genre;
            
        }
        public Film(int id, string titel, string description, string year, int genre)
         : this(titel, description, year, genre)
        {
            this.id = Id;
        }
    }
}

