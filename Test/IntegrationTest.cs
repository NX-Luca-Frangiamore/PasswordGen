using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PasswordGen.Data;
using PasswordGen.Model;
using PasswordGen.Service.Db;
using PasswordGen.Service.Logic.LogicPassword;
using PasswordGen.Service.Logic.LogicUtente;
namespace Test
{
  
    

    }
    public class IntegrationTest
    {
        private (IUtenteManager, IPasswordManager) StartDB()
        {
            var opt = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "Context")
              .UseLazyLoadingProxies().Options;
            Context contex = new(opt);
            contex.Database.EnsureDeleted();
            IManagerDb db = new ManagerDb(contex);
            return (new UtenteManager(db), new PasswordManager(db));

        }
    [Theory]
        [InlineData("luca","144",false)]
        [InlineData("", "",false)]
        [InlineData("", "1rr44",false)]
        [InlineData("luca", "1rr44",true)]
        public void Inserimento_Utente(string username,string passwordUsername, bool result)
        {   
            //Arrange
            (IUtenteManager utenteRepository,_) = StartDB();
            //Action
            bool r = utenteRepository.NewUtente(username, passwordUsername).Result;
            //Assert
            r.Should().Be(result); ;
        }
        [Theory]
        [InlineData("","123f3g","gma4il","24442",false)]
        [InlineData("luca", "3ffrfr3g", "gmail", "88",false)]
        [InlineData("luca", "88", "gmail", "22442",false)]
        [InlineData("luca", "83438", "gmail", "22442", true)]

        public async void Inserimento_Password(string username, string passwordUsername,string passwordName,string password, bool result)
        {
        //Arrange

            (IUtenteManager utenteManager, IPasswordManager passwordManager) = StartDB();
            //Action
            await utenteManager.NewUtente(username, passwordUsername);
            //Assert
            (await passwordManager.NewPassword(username, passwordUsername, passwordName, password)).Should().Be(result);        
        }
    [Theory]
    [InlineData("luca", "123f3g", "gma4il", "24442", true)]
    [InlineData("luca", "3ffrfr3g", "gmail", "88", false)]
    [InlineData("luca", "83833", "", "22442", false)]
    [InlineData("luca", "83438", "gmail", "24jjj2", true)]
    [InlineData("luca", "83438", "", "24jjj2", false)]

    public async void Cancellazione_Password(string username, string passwordUsername, string passwordName, string password, bool result)
    {
        //Arrange

        (IUtenteManager utenteManager, IPasswordManager passwordManager) = StartDB();
        //Action
        await utenteManager.NewUtente(username, passwordUsername);
        //Assert
        (await passwordManager.NewPassword(username, passwordUsername, passwordName, password)).Should().Be(result);
        (await passwordManager.DeletePassword(username, passwordUsername, passwordName)).Should().Be(result);

    }
}

