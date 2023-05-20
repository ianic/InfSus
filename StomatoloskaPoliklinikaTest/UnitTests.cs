using Microsoft.Extensions.DependencyInjection;
using StomatoloskaPoliklinika.Models;
using StomatoloskaPoliklinika.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StomatoloskaPoliklinika.Controllers;

namespace StomatoloskaPoliklinikaTest
{
    [TestClass]
    public class PoslovniSlojUnitTests
    {
        [TestMethod]
        public void ShouldAddStomatolog()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "TestDatabase"));

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            var stomatolog = new Stomatolog
            {
                Ime = "Mario",
                Prezime = "Maric",
                BrojTelefona = "123456789",
                Email = "mario.maric@gmail.com",
                Lozinka = "mario123",
                Specijalizacija = "Opæa stomatologija",
                Cijena = 100
            };

            dbContext.Stomatolog.Add(stomatolog);
            dbContext.SaveChanges();

            var dodaniStomatolog = dbContext.Stomatolog.Find(stomatolog.Id);

            Assert.IsNotNull(dodaniStomatolog);
            Assert.AreEqual(stomatolog.Ime, dodaniStomatolog.Ime);
            Assert.AreEqual(stomatolog.Prezime, dodaniStomatolog.Prezime);
            Assert.AreEqual(stomatolog.BrojTelefona, dodaniStomatolog.BrojTelefona);
            Assert.AreEqual(stomatolog.Email, dodaniStomatolog.Email);
            Assert.AreEqual(stomatolog.Lozinka, dodaniStomatolog.Lozinka);
            Assert.AreEqual(stomatolog.Specijalizacija, dodaniStomatolog.Specijalizacija);
            Assert.AreEqual(stomatolog.Cijena, dodaniStomatolog.Cijena);
        }
    }
    [TestClass]
    public class PrezentacijskiSlojUnitTests
    {
        [TestMethod]
        public async Task ShouldCreateStomatolog()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new StomatologController(context);
                var stomatolog = new Stomatolog
                {
                    Ime = "Mario",
                    Prezime = "Maric",
                    BrojTelefona = "123456789",
                    Email = "mario.maric@gmail.com",
                    Lozinka = "mario123",
                    Specijalizacija = "Opæa stomatologija",
                    Cijena = 100
                };

                var result = await controller.Create(stomatolog) as RedirectToActionResult;

                Assert.IsNotNull(result);
                Assert.AreEqual("Index", result.ActionName);
            }
        }

        [TestMethod]
        public async Task ShouldDeleteStomatolog()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new StomatologController(context);
                var stomatolog = new Stomatolog
                {
                    Ime = "Mario",
                    Prezime = "Maric",
                    BrojTelefona = "123456789",
                    Email = "mario.maric@gmail.com",
                    Lozinka = "mario123",
                    Specijalizacija = "Opæa stomatologija",
                    Cijena = 100
                };
                context.Stomatolog.Add(stomatolog);
                context.SaveChanges();

                var result = await controller.DeleteConfirmed(stomatolog.Id) as RedirectToActionResult;

                Assert.IsNotNull(result);
                Assert.AreEqual("Index", result.ActionName);
            }
        }
        [TestMethod]
        public async Task ShouldNotCreateStomatolog()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new StomatologController(context);
                var stomatolog = new Stomatolog
                {
                    Ime = "Mario",
                    Prezime = "Maric",
                    BrojTelefona = "123456789",
                    Email = "mario.maric@gmail.com",
                    Lozinka = "mario",
                    Specijalizacija = "Opæa stomatologija",
                    Cijena = 100
                };

                var result = await controller.Create(stomatolog) as ViewResult;

                Assert.IsNotNull(result);
                Assert.AreEqual(stomatolog, result.Model);
                Assert.IsFalse(controller.ModelState.IsValid); 
                Assert.IsTrue(controller.ModelState.ContainsKey("Lozinka")); 
            }
        }

    }
    [TestClass]
    public class DataAccessLayerTests
    {
        private DbContextOptions<ApplicationDbContext> _options;
        private ApplicationDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(_options);

            var stomatolog = new Stomatolog
            {
                Id = 1,
                Ime = "Mario",
                Prezime = "Maric",
                BrojTelefona = "123456789",
                Email = "mario.maric@gmail.com",
                Lozinka = "mario",
                Specijalizacija = "Opæa stomatologija",
                Cijena = 100
            };

            _context.Stomatolog.Add(stomatolog);
            _context.SaveChanges();
        }

        [TestMethod]
        public void UpdateStomatolog_ShouldUpdateStomatologInDatabase()
        {
            var stomatolog = _context.Stomatolog.Find(1);

            Assert.AreEqual("Mario", stomatolog.Ime);
            Assert.AreEqual("Maric", stomatolog.Prezime);

            stomatolog.Ime = "Ivan";
            stomatolog.Prezime = "Ivic";

            _context.SaveChanges();

            var updatedStomatolog = _context.Stomatolog.Find(1);
            Assert.AreEqual("Ivan", updatedStomatolog.Ime);
            Assert.AreEqual("Ivic", updatedStomatolog.Prezime);
        }
    }

}
