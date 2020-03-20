using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movienight
{
    public class Genre
    {
        private int id;               
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string genres;

        public string Genres
        {
            get { return genres; }
            set { genres = value; }
        }

        public Genre(int id, string genre)
        {
            this.id = id;
            this.genres = genre;
        }

    }
}
