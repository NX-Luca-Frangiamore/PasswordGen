
using FluentAssertions;
using Moq;
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
            UtenteService utenteService = new UtenteService(mock.Object);
            //Action
            var r = await utenteService.NewUtente(username, password);
            //Assert
            r.Should().Be(false);
        }
        [Theory]
        [InlineData("luca", "12356")]
        [InlineData("peppe1", "fgf")]
        public async void Creation_ValidUser_Allowed(string username, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            UtenteService utenteService = new UtenteService(mock.Object);
            //Action
            var r = await utenteService.NewUtente(username, password);
            //Assert
            r.Should().Be(true);
        }

        [Theory]
        [InlineData("", "12356",null,"fffr")]
        [InlineData("peppe1", "333343","frfr","ff")]
        public async void Changing_UserCredential_NotAllowed(string username, string passwordUsername,string newUsername,string newPassword)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtente(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            UtenteService utenteService = new UtenteService(mock.Object);
            //Action
            var r = await (utenteService.ChangeUtente(username, passwordUsername,newUsername,newPassword));
            //Assert
            r.Should().Be(false);
        }
        [Theory]
        [InlineData("gmail", "12")]
        [InlineData("", "333343")]
        [InlineData("frfr", "3")]
        [InlineData("frfr", "ffffffffffffffff3")]
        public void Creazione_Password_NonAvvenuta(string name, string password)
        {
            PasswordModel.Create(name, password).Should().BeNull();
        }
        [Theory]
        [InlineData("", "123f3g", "gma4il", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "88")]
        [InlineData("luca", "88", "gmail", "22442")]
        [InlineData("luca", "83438", "", "4rrerr2")]

        public async void Adding_InvalidPassword_NotAllowed(string username, string passwordUsername, string passwordName, string password)
        {
            //Arrange

            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            PasswordService passwordService = new PasswordService(mock.Object);
            //Action
            var r = await passwordService.NewPassword(username, passwordUsername, passwordName, password);
            //Assert
            r.Should().Be(false);
        }
        [Theory]
        [InlineData("luca", "123f3g", "gma4il", "24442")]
        [InlineData("luca", "3ffrf", "gl", "88333")]


        public async void Adding_ValidPassword_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            //Arrange
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            PasswordService passwordService = new PasswordService(mock.Object);

            //Action
            var r = await passwordService.NewPassword(username, passwordUsername, passwordName, password);

            //Assert
            r.Should().Be(true);
        }

        [Theory]
        [InlineData("luca", "123f3g", "", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "88")]
        [InlineData("luca", "83833", "", "22442")]
        [InlineData("luca", "8", "gmail", "24jjj2")]
        [InlineData("luca", "83438", "", "24jjj2")]

        public async void Delete_Password_NotAllowed(string username, string passwordUsername, string passwordName, string password)
        {
            //Arrange

            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            PasswordService passwordService = new PasswordService(mock.Object);
            //Action

            //Assert
            await passwordService.NewPassword(username, passwordUsername, passwordName, password);

            (await passwordService.DeletePassword(username, passwordUsername, passwordName)).Should().Be(false);

        }
        [Theory]
        [InlineData("luca", "123f3g", "ffff", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "8438")]

        public async void Delete_Password_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            //Arrange

            Mock<IManagerDb> mock = new Mock<IManagerDb>(null);
            mock.Setup(x => x.GetUtenteWithPassword(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            PasswordService passwordService = new PasswordService(mock.Object);
            //Action

            //Assert
            await passwordService.NewPassword(username, passwordUsername, passwordName, password);

            (await passwordService.DeletePassword(username, passwordUsername, passwordName)).Should().Be(true);

        }
    }
}