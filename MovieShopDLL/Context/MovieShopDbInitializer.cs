using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Context
{
    public class MovieShopDbInitializer : CreateDatabaseIfNotExists<MovieShopContext>
    {
        protected override void Seed(MovieShopContext context)
        {
            context.Movies.Add(new Movie()
            {
                Title = "The Shawshank Redemption",
                Year = new DateTime(1994, 1, 1),
                Price = 100,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BODU4MjU4NjIwNl5BMl5BanBnXkFtZTgwMDU2MjEyMDE@._V1_UX182_CR0,0,182,268_AL_.jpg"
            });

            context.Movies.Add(new Movie()
            {
                Title = "The Godfather",
                Year = new DateTime(1972, 1, 1),
                Price = 80,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjEyMjcyNDI4MF5BMl5BanBnXkFtZTcwMDA5Mzg3OA@@._V1_UX182_CR0,0,182,268_AL_.jpg"
            });

            context.Movies.Add(new Movie()
            {
                Title = "The Dark Knight",
                Year = new DateTime(2008, 1, 1),
                Price = 120,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"
            });

            context.Movies.Add(new Movie()
            {
                Title = " Schindler's List",
                Year = new DateTime(1993, 1, 1),
                Price = 100,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMzMwMTM4MDU2N15BMl5BanBnXkFtZTgwMzQ0MjMxMDE@._V1_UX182_CR0,0,182,268_AL_.jpg"
            });

            context.Movies.Add(new Movie()
            {
                Title = "12 Angry Men",
                Year = new DateTime(1957, 1, 1),
                Price = 80,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BODQwOTc5MDM2N15BMl5BanBnXkFtZTcwODQxNTEzNA@@._V1_UX182_CR0,0,182,268_AL_.jpg"
            });

            context.Movies.Add(new Movie()
            {
                Title = "Pulp Fiction",
                Year = new DateTime(1994, 1, 1),
                Price = 100,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTkxMTA5OTAzMl5BMl5BanBnXkFtZTgwNjA5MDc3NjE@._V1_UX182_CR0,0,182,268_AL_.jpg"
            });

            context.Customers.Add(new Customer()
            {
                FirstName = "Adam",
                LastName = "First",
                Email = "adam.first@mail.net"
            });

            context.Customers.Add(new Customer()
            {
                FirstName = "Bill",
                LastName = "Second",
                Email = "bill.second@mail.net"
            });

            context.Customers.Add(new Customer()
            {
                FirstName = "Clare",
                LastName = "Third",
                Email = "clare.third@mail.net"
            });

            context.Customers.Add(new Customer()
            {
                FirstName = "David",
                LastName = "Fourth",
                Email = "david.forth@mail.net"
            });

            base.Seed(context);
        }
    }
}
