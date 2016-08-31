namespace TEST_EVERYTHING.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TEST_EVERYTHING.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    //internal sealed class Configuration : DbMigrationsConfiguration<TEST_EVERYTHING.Models.ApplicationDbContext>
    internal sealed class Configuration : DbMigrationsConfiguration<TEST_EVERYTHING.DataLayer.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TEST_EVERYTHING.DataLayer.MovieContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
                /*context.Movies.AddOrUpdate(
                  m => m.Id,
                  new Movie() { Id = 1, Name = "movie 1", Description = "movie1 description 1", ImageName = "movie1"},
                  new Movie { Id = 2, Name = "movie 2", Description = "movie1 description 2", ImageName = "movie2" },
                  new Movie { Id = 3, Name = "movie 3", Description = "movie1 description 3", ImageName = "movie3" }
                );*/

            /*string json = @"{
                    ""Name"": ""Bad Boys"",
                    ""ReleaseDate"": ""1995-4-7T00:00:00"",
                    ""ErrorDate"": """",
                    ""Genres"": { ""Action"",""Comedy""}}";*/
            /*string jsonMovie = @"{
                    ""Id"": 4,
                    ""Name"": ""movie 4"",
                    ""Description"": ""movie description 4"",
                    ""ImageName"": ""movie4""
            }";

            Movie movie = JsonConvert.DeserializeObject<Movie>(jsonMovie);
            context.Movies.AddOrUpdate(
                  m => m.Id,
                  movie );*/

            //COMPLEX ADD: WORKING.
            //OPGELET: IN HET BUSINESS OBJECT Orderline WERD MovieId toegevoegd als property => 1..1 ipv 0..1 en je kan een 
            //reference naar reeds bestaande data seeden via de Id. Voorbeeld voor 0..1 hier beneden
            context.Orders.AddOrUpdate(
                o => o.OrderId,
                new Order()
                {
                    OrderId = 3,
                    Orders = new List<OrderLine> 
                    {
                        new OrderLine() { OrderLineId = 4, MovieId = 1 , Quantity = 1},
                        new OrderLine() { OrderLineId = 5, MovieId = 2 , Quantity = 2},
                        new OrderLine() { OrderLineId = 6, MovieId = 1 , Quantity = 3}
                    }
                });

            //!!!!!!!!!!!!!!!!!!  SEEDING A 0..1 EXAMPLE:
            /*var products = GetProducts();
            var product1 = products[0];
            var product2 = products[1];
            var customer = new Customer
            {
                FirstName = "Julie",
                LastName = "Lerman",
                ContactDetail = new ContactDetail { TwitterAlias = "julielerman" },
                DateOfBirth = DateTime.Now
            };
            var order = new Order
            {
                DestinationLatLong = DbGeography.FromText("POINT(44.292401 -72.968102)"),
                OrderDate = DateTime.Now,
                OrderSource = OrderSource.InPerson,
                LineItems = { new LineItem{Product = product1, Quantity =2 },
                    new LineItem{Product = product2, Quantity = 1} }
            };
            customer.Orders.Add(order);
            using (var context = new SalesModelContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }*/


            //COMPLEX SEED
            /*var students = new List<Student>
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander", 
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",    
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",     
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas", 
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan",      LastName = "Li",        
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",   
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",    
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",  
                    EnrollmentDate = DateTime.Parse("2005-08-11") }
            };
         students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
         context.SaveChanges();

         var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3, },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3, },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3, },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4, },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4, },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3, },
                new Course {CourseID = 2042, Title = "Literature",     Credits = 4, }
            };
         courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
         context.SaveChanges();

         var enrollments = new List<Enrollment>
            {
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID, 
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, 
                    Grade = Grade.A 
                },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID, 
                    Grade = Grade.C 
                 },                            
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID, 
                    Grade = Grade.B
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B         
                 },
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Barzdukas").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Li").StudentID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Justice").StudentID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B         
                 }
            };

         foreach (Enrollment e in enrollments)
         {
            var enrollmentInDataBase = context.Enrollments.Where(
                s =>
                     s.Student.StudentID == e.StudentID &&
                     s.Course.CourseID == e.CourseID).SingleOrDefault();
            if (enrollmentInDataBase == null)
            {
               context.Enrollments.Add(e);
            }
         }
         context.SaveChanges();
      }*/
            //OTHER COMPLEX EXAMPLE
            /*    context.Authors.AddOrUpdate(x => x.Id,
        new Author() { Id = 1, Name = "Jane Austen" },
        new Author() { Id = 2, Name = "Charles Dickens" },
        new Author() { Id = 3, Name = "Miguel de Cervantes" }
        );

    context.Books.AddOrUpdate(x => x.Id,
        new Book() { Id = 1, Title = "Pride and Prejudice", Year = 1813, AuthorId = 1, 
            Price = 9.99M, Genre = "Comedy of manners" },
        new Book() { Id = 2, Title = "Northanger Abbey", Year = 1817, AuthorId = 1, 
            Price = 12.95M, Genre = "Gothic parody" },
        new Book() { Id = 3, Title = "David Copperfield", Year = 1850, AuthorId = 2, 
            Price = 15, Genre = "Bildungsroman" },
        new Book() { Id = 4, Title = "Don Quixote", Year = 1617, AuthorId = 3, 
            Price = 8.95M, Genre = "Picaresque" }
        );*/
        }
    }
}
