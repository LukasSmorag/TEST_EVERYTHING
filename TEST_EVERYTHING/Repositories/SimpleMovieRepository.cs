using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST_EVERYTHING.DataLayer;
using TEST_EVERYTHING.Models;

namespace TEST_EVERYTHING.Repositories
{
    public class SimpleMovieRepository: IDisposable
    {
        readonly MovieContext _context = new MovieContext();

        public Movie FindById(int id)
        {
            Movie movie = _context.Movies.Find(id);
            return movie;
        }

        public Movie GetFirstMovie()
        {
            return FindById(1);
        }

        public void Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public List<Movie> GetAll()
        {
           return _context.Movies.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}