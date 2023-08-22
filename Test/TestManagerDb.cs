
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
        public void InserimentoUtente()
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
        public void InserimentoPassword()
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));
            db.newUtente("luca", "123");
            Assert.True(db.newPassword(1, new Password { name = "email", password = "1233" }));
            Assert.True(db.getPassword(1, "email")!=null);
         


        }
    }
}