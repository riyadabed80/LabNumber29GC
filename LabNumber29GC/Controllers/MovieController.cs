using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LabNumber29GC.Models;

namespace LabNumber29GC.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public List<Movy> ListMovies()
        {
            MovieDatabaseEntities1 ORM = new MovieDatabaseEntities1();


            return ORM.Movies.ToList();


        }

        [HttpGet]
        public List<Movy> ListMovieByCategory(string category)
        {
            MovieDatabaseEntities1 ORM = new MovieDatabaseEntities1();

            return ORM.Movies.Where(c => c.Category.Contains(category)).ToList();


        }

        [HttpGet]
        public Movy RandomPick()
        {
            MovieDatabaseEntities1 ORM = new MovieDatabaseEntities1();

            Random rnd = new Random();
            List<Movy> MovieList = ORM.Movies.ToList();
            return MovieList[rnd.Next(0, MovieList.Count)];


        }
        [HttpGet]
        public Movy RandomPickSpecCategory(string cat)
        {
            MovieDatabaseEntities1 ORM = new MovieDatabaseEntities1();

            //ORM.Movies.Where(c => c.Category == cat).ToList();

            Random rnd = new Random();

            List<Movy> MovieList = ORM.Movies.Where(c => c.Category == cat).ToList();
            return MovieList[rnd.Next(0, MovieList.Count)];




        }

        [HttpGet]
        public List<Movy> RandomNumofPics(int userInput)
        {

            MovieDatabaseEntities1 ORM = new MovieDatabaseEntities1();
            Random rnd = new Random();
            List<Movy> MovieList = ORM.Movies.ToList();
            List<Movy> MovieL = new List<Movy>();
            for (int i = 0; i < userInput; i++)
            {
                int result = rnd.Next(MovieList.Count());
                MovieList.Add(MovieL[result]);
                MovieL.RemoveAt(result);


            }
            return MovieList;

            



        }
        [HttpGet]
        public List<string> ListCategories()
        {

            MovieDatabaseEntities1 ORM = new MovieDatabaseEntities1();

            return ORM.Movies.Select(c => c.Category).Distinct().ToList();



        }
        [HttpGet]
        public Movy MovieTitle(string name)
        {
            MovieDatabaseEntities1 ORM = new MovieDatabaseEntities1();
            Movy result = ORM.Movies.Find(name);
            if(result != null)
            {
                return result;
            }
            else
            {
                Movy info = new Movy { Title = "movie not found" };
                return info;
            }




        }

        public List<Movy> MovieKey(string userInput)
        {
            MovieDatabaseEntities1 ORM = new MovieDatabaseEntities1();

            return ORM.Movies.Where(c => c.Title.Contains(userInput)).ToList();


        }

        



    
    }
}
