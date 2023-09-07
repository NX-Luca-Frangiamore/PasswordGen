
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using PasswordGen.Data;
using PasswordGen.Model;
using PasswordGen.Repository;
using PasswordGen.Service.PasswordService;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory;
using PasswordGen.Service.UtenteService;
using static PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory.FactoryBuilder;

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
        [InlineData("", "333343", null,"fffr")]
        [InlineData("peppe1", "333343","frfr","ff")]
        public async void Changing_UserCredential_NotAllowed(string username, string passwordUsername,string newUsername,string newPassword)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtente(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IUtenteService utenteService = new UtenteService(mock.Object);
            
            (await (utenteService.ChangeUtente(1,newUsername,newPassword))).Should().Be(false);
      
        }
        [Theory]
        [InlineData("", "123f3g", "gma4il", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "88")]
        [InlineData("luca", "88", "gmail", "22442")]
        [InlineData("luca", "83438", "", "4rrerr2")]

        public async void Adding_InvalidPassword_NotAllowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object,null);
            
            (await passwordService.NewPassword(1, passwordName, password)).Should().Be(false); 
 
        }
        [Theory]
        [InlineData("luca", "123f3g", "gma4il", "24442")]
        [InlineData("luca", "3ffrf", "gl", "88333")]


        public async void Adding_ValidPassword_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object,null);

            (await passwordService.NewPassword(1, passwordName, password)).Should().Be(true); 

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
            mock.Setup(x => x.GetUtenteWithPassword(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object,null);
            await passwordService.NewPassword(1, passwordName, password);

            (await passwordService.DeletePassword(1, passwordName)).Should().Be(false);

        }
        [Theory]
        [InlineData("luca", "123f3g", "ffff", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "8438")]

        public async void Delete_Password_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object,null);
            await passwordService.NewPassword(1, passwordName, password);

            (await passwordService.DeletePassword(1, passwordName)).Should().Be(true);

        }
        [Theory]
        [InlineData("luca", "123f3g", "", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "8")]
        [InlineData("luca", "", "gmail", "8")]

        public async void Getting_NoExistentPassword_NotAllowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object,null);
            await passwordService.NewPassword(1, passwordName, password);

            (await passwordService.GetPassword(1, passwordName)).Should().Be(null);

        }
        [Theory]
        [InlineData("luca", "123f3g", "facebook", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "8fgtgf")]
        [InlineData("luca", "1111", "gmail", "8rfrfr")]

        public async void Getting_Password_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object,null);
            await passwordService.NewPassword(1, passwordName, password);

            (await passwordService.GetPassword(1, passwordName)).Should().NotBe(null);

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
        [Theory]
        [InlineData("peppe", "1gn2")]
        [InlineData("luca", "333343")]

        public async void Creation_DuplicatedPassword_NotAllowed(string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtenteWithPassword(1)).ReturnsAsync(Utente.Create("luca", "test"));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object,null);

           (await passwordService.NewPassword(1, passwordName, password)).Should().Be(true); ;

           (await passwordService.NewPassword(1, passwordName, password)).Should().Be(false);
        }
        [Theory]
        [InlineData("facebook",TypePassword.soft)]
        [InlineData("whatapp", TypePassword.medium)]
        [InlineData("whatapp", TypePassword.hard)]
        public async void Creation_RandomPassword_Allowed(string passwordName, TypePassword type)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtenteWithPassword(1)).ReturnsAsync(Utente.Create("luca", "test"));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, new FactoryBuilder());

            (await passwordService.NewPassword(1,passwordName,type)).Should().NotBe(null);
            
        }
        [Theory]
        [InlineData("", TypePassword.soft)]
        [InlineData(null, TypePassword.soft)]
        public async void Creation_RandomPassword_NotAllowed(string passwordName, TypePassword type)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtenteWithPassword(1)).ReturnsAsync(Utente.Create("luca", "test"));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, new FactoryBuilder());

            (await passwordService.NewPassword(1, passwordName, type)).Should().Be(null);

        }
    }
}