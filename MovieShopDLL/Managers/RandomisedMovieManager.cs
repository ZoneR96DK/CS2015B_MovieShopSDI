using System;
using System.Collections.Generic;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    public class RandomisedMovieManager
    {
        private static RandomisedMovieManager _instance;

        private RandomisedMovieManager()
        {
        }

        public static RandomisedMovieManager Instance => _instance ?? (_instance = new RandomisedMovieManager());

        public List<Movie> PickFiveRandomFilms()
        {
            using (var db = new MovieShopContext())
            {
                var rnd = new Random();
                var randomisedList = new List<Movie>();
                for (var i = 0; i < 5; i++)
                {
                    var fullList = db.Movies.ToList();
                    var count = fullList.Count();
                    var rndNr = rnd.Next(count);
                    var isRandomNumber = fullList.Skip(rndNr).FirstOrDefault();
                    if (randomisedList.Contains(isRandomNumber))
                    {
                        i--;
                    } else {
                    randomisedList.Add(isRandomNumber);
                    }
                }
                return randomisedList;
            }
        }
    }
}