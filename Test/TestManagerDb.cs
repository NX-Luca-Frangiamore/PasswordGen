
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PasswordGen.Model;
using PasswordGen.Service;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Test
{
   
    public class TestManagerDb
    {
        [Theory]
        [InlineData("luca","123")]
        [InlineData("piero", "223")]
        public void InserimentoStampaUtente(string username,string password)
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));

            db.newUtente(username, password);
            int id = db.getId(username, password);
            Assert.True(db.getId(username, password)==id);
        }
        [Fact]
        public void InserimentoStampaPassword()
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));
            db.newUtente("luca", "123");
            Assert.True(db.newPassword(1, new Password { name = "email", password = "1233" }));
            Assert.True(db.getPassword(1, "email")!=null);  
        }
        [Theory]
        [InlineData("luca", "123", "newLuca", "443")]
        [InlineData("piero", "223","newpiero","111")]
        public void CambioUsernamePasswordUtente(string username,string password,string newUsername,string newPassword)
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));

            db.newUtente(username, password);
            int id=db.getId(username, password);
            db.changeUtente(username, password, newUsername, newPassword);

            Assert.True(db.getId(newUsername, newPassword) == id);


        }
        [Fact]
        public void CambioPassword()
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));

            db.newUtente("luca", "123");
            Assert.True(db.newPassword(1,new Password { name="gmail",password="123"}),"password creata correttamente");
            db.changePassword(1, "gmail", "4444");
            Assert.True(db.getPassword(1, "gmail").password == "4444","cambio effettuato correttamente");
            Assert.False(db.changePassword(1, "nonesiste", "4444"),"non posso cambiare una password non esistente");
        }
        [Theory]
        [InlineData("luca", "123","gmail","111")]
        [InlineData("luca", "123", "ff", "1fe11")]
        public void DeleteUtente(string username, string passwordUtente,string nomePassword,string password)
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));
      
            db.newUtente(username, passwordUtente);
            int id = db.getId(username, passwordUtente);
            db.newPassword(id,new Password { name=nomePassword, password=password});
            db.deleteUtente(id);
            Assert.False(db.getId(username, passwordUtente) == id);
            Assert.True(db.getPassword(id,nomePassword) ==null);

        }
        [Theory]
        [InlineData("luca", "123", "gmail", "111")]
        [InlineData("luca", "123", "ff", "1fe11")]
        public void DeletePassword(string username, string passwordUtente, string nomePassword, string password)
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));
           
              db.newUtente(username, passwordUtente);
            int id = db.getId(username, passwordUtente);
            db.newPassword(id, new Password { name = nomePassword, password = password });
            db.deletePassword(id,nomePassword);
            Assert.True(db.getPassword(id, nomePassword) == null);

        }

    }
}