using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_EVERYTHING.Models
{
    public class MovieDB
    {
        public MovieDB()
        {
            movies = new List<Movie>();

            Movie movie1 = new Movie(1, "Movie 1", "Descirption1", "movie1");
            Movie movie2 = new Movie(2, "Movie 2", "Descirption2", "movie2");
            Movie movie3 = new Movie(3, "Movie 3", "Descirption3", "movie3");
            Movie movie4 = new Movie(4, "Movie 4", "Descirption4", "movie4");
            Movie movie5 = new Movie(5, "Movie 5", "Descirption5", "movie5");
            Movie movie6 = new Movie(6, "Movie 6", "Descirption6", "movie6");
            Movie movie7 = new Movie(7, "Movie 7", "Descirption7", "movie7");
            Movie movie8 = new Movie(8, "Movie 8", "Descirption8", "movie8");

            movies.Add(movie1);
            movies.Add(movie2);
            movies.Add(movie3);
            movies.Add(movie4);
            movies.Add(movie5);
            movies.Add(movie6);
            movies.Add(movie7);
            movies.Add(movie8);
        }

        private List<Movie> movies;

        public Movie GetFirst()
        {
            return movies.First();
        }

        public List<Movie> GetAll()
        {
            return movies;
        }

        public Movie GetById(int id)
        {
            return movies.ElementAt(id);
        }
    }
}