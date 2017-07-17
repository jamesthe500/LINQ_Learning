using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Diagnostics;


namespace LinqIntro
{
    class Program
    {
        public static void Main()
        {
            QuerySqlServer();
            //QueryXml();
            //QueryEmployees();
            //QueryTypes();
        }

        private static void QuerySqlServer()
        {
            MovieReviewsDataContext dc = new MovieReviewsDataContext();

            IEnumerable<Movie> topMovies =
                from m in dc.Movies
                where m.ReleaseDate.Year > 2006
                orderby m.Reviews.Average(r => r.Rating) descending
                select m;

            foreach (Movie movie in topMovies)
            {
                Console.WriteLine(movie.Title);

            }

        }
    }
}
