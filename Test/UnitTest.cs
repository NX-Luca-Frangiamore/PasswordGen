
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using PasswordGen.Data;
using PasswordGen.Model;
using PasswordGen.Repository;
using PasswordGen.Service.PasswordService;
using PasswordGen.Service.UtenteService;
namespace UnitTest
{
    public class UnitTest
    {
        [Theory]
        [InlineData("", "12")]
        [InlineData("peppe1", "")]
        public async void Creation_InvalidUser_NotAllowed(string username, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtente(username, password)).ReturnsAsync(default(Utente));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IUtenteService utenteService = new UtenteService(mock.Object);
        
            (await utenteService.NewUtente(username, password)).Should().Be(false);
           
        }
        [Theory]
        [InlineData("luca", "12356")]
        [InlineData("peppe1", "fgf")]
        public async void Creation_ValidUser_Allowed(string username, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtente(username,password)).ReturnsAsync(default(Utente));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IUtenteService utenteService = new UtenteService(mock.Object);
       
            (await utenteService.NewUtente(username, password)).Should().Be(true); ;
   
        }

        [Theory]
        [InlineData("", "12356",null,"fffr")]
        [InlineData("peppe1", "333343","frfr","ff")]
        public async void Changing_UserCredential_NotAllowed(string username, string passwordUsername,string newUsername,string newPassword)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtente(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IUtenteService utenteService = new UtenteService(mock.Object);
            
            (await (utenteService.ChangeUtente(username, passwordUsername,newUsername,newPassword))).Should().Be(false);
      
        }
        [Theory]
        [InlineData("gmail", "12")]
        [InlineData("", "333343")]
        [InlineData("frfr", "3")]
        [InlineData("frfr", "ffffffffffffffff3")]
        public void Creazione_Password_NonAvvenuta(string username, string password)
        {
            PasswordModel.Create(username, password).Should().BeNull();
        }
        [Theory]
        [InlineData("", "123f3g", "gma4il", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "88")]
        [InlineData("luca", "88", "gmail", "22442")]
        [InlineData("luca", "83438", "", "4rrerr2")]

        public async void Adding_InvalidPassword_NotAllowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object);
            
            (await passwordService.NewPassword(username, passwordUsername, passwordName, password)).Should().Be(false); 
 
        }
        [Theory]
        [InlineData("luca", "123f3g", "gma4il", "24442")]
        [InlineData("luca", "3ffrf", "gl", "88333")]


        public async void Adding_ValidPassword_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object);

            (await passwordService.NewPassword(username, passwordUsername, passwordName, password)).Should().Be(true); 

        }

        [Theory]
        [InlineData("luca", "123f3g", "", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "88")]
        [InlineData("luca", "83833", "", "22442")]
        [InlineData("luca", "8", "gmail", "24jjj2")]
        [InlineData("luca", "83438", "", "24jjj2")]

        public async void Delete_Password_NotAllowed(string username, string passwordUsername, string passwordName, string password)
        {

            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object);
            await passwordService.NewPassword(username, passwordUsername, passwordName, password);

            (await passwordService.DeletePassword(username, passwordUsername, passwordName)).Should().Be(false);

        }
        [Theory]
        [InlineData("luca", "123f3g", "ffff", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "8438")]

        public async void Delete_Password_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object);
            await passwordService.NewPassword(username, passwordUsername, passwordName, password);

            (await passwordService.DeletePassword(username, passwordUsername, passwordName)).Should().Be(true);

        }
        [Theory]
        [InlineData("luca", "123f3g", "", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "8")]
        [InlineData("luca", "", "gmail", "8")]

        public async void Printing_NoExistentPassword_NotAllowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object);
            await passwordService.NewPassword(username, passwordUsername, passwordName, password);

            (await passwordService.GetPassword(username, passwordUsername, passwordName)).Should().Be(null);

        }
        [Theory]
        [InlineData("luca", "123f3g", "facebook", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "8fgtgf")]
        [InlineData("luca", "1111", "gmail", "8rfrfr")]

        public async void Printing_Password_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object);
            await passwordService.NewPassword(username, passwordUsername, passwordName, password);

            (await passwordService.GetPassword(username, passwordUsername, passwordName)).Should().NotBe(null);

        }
        [Theory]
        [InlineData("peppe", "1g2")]
        [InlineData("luca", "333343")]
       
        public async void Creation_DuplicatedUser_NotAllowed(string username, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtente(username, password)).ReturnsAsync(Utente.Create(username,password));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IUtenteService utenteService =new UtenteService(mock.Object);

            (await utenteService.NewUtente(username, password)).Should().Be(false);

        }
    }
}