using StomatoloskaPoliklinika.Models;
using StomatoloskaPoliklinika.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StomatoloskaPoliklinika.Controllers;

namespace StomatoloskaPoliklinikaTest
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public async Task PovezanostSvihSlojevaTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Database.EnsureCreated();
            }

            var controller = new StomatologController(new ApplicationDbContext(dbContextOptions));

            var stomatolog = new Stomatolog
            {
                Id = 8,
                Ime = "Pero",
                Prezime = "Peric",
                BrojTelefona = "123456789",
                Email = "pero.peric@gmail.com",
                Lozinka = "pero123",
                Specijalizacija = "Opća stomatologija",
                Cijena = 200
            };

            var result = await controller.Create(stomatolog);

            var redirectResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectResult);
            Assert.AreEqual(nameof(StomatologController.Index), redirectResult.ActionName);
            Assert.IsNull(redirectResult.ControllerName);

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var savedStomatolog = await dbContext.Stomatolog.FindAsync(8);
                Assert.IsNotNull(savedStomatolog);
                Assert.AreEqual("Pero", savedStomatolog.Ime);
                Assert.AreEqual("Peric", savedStomatolog.Prezime);
                Assert.AreEqual("123456789", savedStomatolog.BrojTelefona);
                Assert.AreEqual("pero.peric@gmail.com", savedStomatolog.Email);
                Assert.AreEqual("pero123", savedStomatolog.Lozinka);
                Assert.AreEqual("Opća stomatologija", savedStomatolog.Specijalizacija);
                Assert.AreEqual(200, savedStomatolog.Cijena);
            }
        }
    }
}
