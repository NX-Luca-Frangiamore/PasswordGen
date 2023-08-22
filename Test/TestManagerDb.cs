
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
        [Fact]
        public void InserimentoStampaUtente()
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));

            db.newUtente("luca", "123");
            db.newUtente("paolo", "3");
            Assert.False(db.getId("luca", "123")==0);
            Assert.True(db.getId("paolo", "3")==2);
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
        [Fact]
        public void CambioUsernamePasswordUtente()
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));

            db.newUtente("luca", "123");
            db.newUtente("paolo", "333");

            Assert.True(db.getId("luca", "123")==1,"utente inserito");
            db.changeUtente("luca", "123", "lucaCCC", "");
            Assert.True(db.getId("lucaCCC", "123") == 1,"utente cambiato correttamente:username");

            db.changeUtente("paolo", "333", "paolo1", "111");
            Assert.True(db.getId("paolo1", "111") == 2, "utente cambiato correttamente:username,password");

            Assert.False(db.changeUtente("peppe", "333", "paolo1", "111"),"non posso cambiare un utente che non esiste");

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
    }
}