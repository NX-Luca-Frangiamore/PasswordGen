
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
        public void VerificaInserimentoUtente()
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
    }
}