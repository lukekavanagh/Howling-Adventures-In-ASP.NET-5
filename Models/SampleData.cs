using System;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ContosoBooks.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (context.Book.Any())
            {
                var whitman = context.Author.Add(
                    new Author {LastName = "Whitman", FirstMidName = "Walt"}).Entity;
                var dickens = context.Author.Add(
                    new Author {LastName = "Dickens", FirstMidName = "Charles"}).Entity;
                var thompson = context.Author.Add(
                    new Author {LastName = "Thompson", FirstMidName = "Hunter S"}).Entity;

                context.Book.AddRange(
                    new Book()
                    {
                        Title = "Leaves of Grass",
                        Year = 1813,
                        Author = whitman,
                        Price = 9.99m,
                        Genre = "Poems"
                    },
                    new Book()
                    {
                        Title = "Song of Myself",
                        Year = 1817,
                        Author = whitman,
                        Price = 15,
                        Genre = "Poems"
                    },
                    new Book()
                    {
                        Title = "Fear and loathing in Las Vegas",
                        Year = 1963,
                        Author = thompson,
                        Price = 5.63M,
                        Genre = "The fallacy of the American dream"
                    },
                    new Book()
                    {
                        Title = "David Copperfield",
                        Year = 1850,
                        Author = dickens,
                        Price = 16,
                        Genre = "Victorian"
                    },
                    new Book()
                    {
                        Title = "Hell's Angels: The Strange and Terrible Saga of the Outlaw Motorcycle Gangs",
                        Year = 1969,
                        Author = thompson,
                        Price = 19.69M,
                        Genre = "Psychedelia"
                    },
                    new Book()
                    {
                        Title = "Great Expectations",
                        Year = 1843,
                        Author = dickens,
                        Price = 18.54M,
                        Genre = "Victorian"
                    }
                 );
                context.SaveChanges();    
                }
            }
        }
    }
