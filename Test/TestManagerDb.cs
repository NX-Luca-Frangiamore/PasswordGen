
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


            db.newUtente("luca", "123");
            int id;
            id = db.getId("luca", "123");
            Assert.True(db.newPassword(id,new Password { name="gmail",password="123"}),"password creata correttamente");
            db.changePassword(id, "gmail", "4444");
            Assert.True(db.getPassword(id, "gmail").password == "4444","cambio effettuato correttamente");
            Assert.False(db.changePassword(id, "nonesiste", "4444"),"non posso cambiare una password non esistente");
        }

        [Theory]
        [InlineData("luca", "123")]
        [InlineData("piero", "223")]
        public void CancellazioneUtente(string username, string password)
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));

            db.newUtente(username, password);
            int id = db.getId(username, password);
            db.newPassword(id, new Password { name = "test",password="test" });
            db.deleteUtente(id);
            Assert.False(db.getId(username, password) == id);
            Assert.True(db.getPassword(id, "test") ==null);
        }
        [Theory]
        [InlineData(true,"luca", "123","gmail","122")]
        [InlineData(false, "luca", "123", "facebook", "222")]
        [InlineData(true,"piero", "223","facebook","233")]
        public void CancellazionePassword(bool createUtente,string username, string passwordUtente, string nomePassword,string password)
        {
            var opt = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "Context")
            .UseLazyLoadingProxies().Options;

            IManagerDb db = new ManagerDb(new Context(opt));
            if(createUtente)
              db.newUtente(username, passwordUtente);
            int id = db.getId(username, passwordUtente);
            db.newPassword(id,new Password { name= nomePassword,password=password });
            db.deletePassword(id, nomePassword);
            Debug.WriteLine((db.getPassword(id, nomePassword)));
            Assert.True(db.getPassword(id,nomePassword)==null);
        }
    }
}