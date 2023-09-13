using Moq;

using FluentAssertions;
using PasswordGen.Model;
using PasswordGen.Repository;
using PasswordGen.Service.PasswordService;
using PasswordGen.Service.PasswordService.GeneratorePassword.Factory;
using PasswordGen.Service.UtenteService;
using static PasswordGen.Service.PasswordService.GeneratorePassword.Factory.FactoryBuilder;

namespace Password
{
    public class UnitTestPasswords
    {
        [Theory]
        [InlineData("luca", "123f3g", "g", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "88")]
        [InlineData("luca", "8338", "gmail", "")]
        [InlineData("luca", "83438", "", "4rrerr2")]

        public async void Adding_InvalidPassword_NotAllowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.GetUtente(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, null);

            (await passwordService.NewPassword(1, passwordName, password)).Should().Be(false);

        }
        [Theory]
        [InlineData("luca", "123f3g", "gma4il", "24442")]
        [InlineData("luca", "3ffrf", "gl7", "88333")]


        public async void Adding_ValidPassword_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.GetUtente(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, null);

            (await passwordService.NewPassword(1, passwordName, password)).Should().Be(true);

        }

        [Theory]
        [InlineData("luca", "123f3g", "gmaill", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "frfed")]

        public async void Delete_Password_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.GetUtente(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, null);
            await passwordService.NewPassword(1, passwordName, password);

            (await passwordService.DeletePassword(1, passwordName)).Should().Be(true);

        }
        [Theory]
        [InlineData("luca", "123f3g", "", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "8")]
        [InlineData("luca", "rrrrr", "gmail", "")]

        public async void Getting_PasswordNotCreated_NotAllowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.GetUtente(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, null);

            (await passwordService.GetPassword(1, passwordName)).Should().Be(null!);

        }
        [Theory]
        [InlineData("luca", "123f3g", "facebook", "24442")]
        [InlineData("luca", "3ffrfr3g", "gmail", "8fgtgf")]
        [InlineData("luca", "1111", "gmail", "8rfrfr")]

        public async void Getting_PasswordCreated_Allowed(string username, string passwordUsername, string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.GetUtente(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, null);

            await passwordService.NewPassword(1, passwordName, password);

            (await passwordService.GetPassword(1, passwordName)).Should().NotBe(null!);

        }

        [Theory]
        [InlineData("facebook", TypePassword.soft)]
        [InlineData("whatapp", TypePassword.medium)]
        [InlineData("whatapp", TypePassword.hard)]
        public async void Creation_RandomPassword_Allowed(string passwordName, TypePassword type)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtente(1)).ReturnsAsync(Utente.Create("luca", "test"));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, new FactoryBuilder());

            (await passwordService.NewPasswordRandom(1, passwordName, type)).Should().NotBe(null!);

        }
        [Theory]
        [InlineData("", TypePassword.soft)]
        [InlineData(null, TypePassword.soft)]
        public async void Creation_RandomPasswordWithNameInvalid_NotAllowed(string passwordName, TypePassword type)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtente(1)).ReturnsAsync(Utente.Create("luca", "test"));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, new FactoryBuilder());

            (await passwordService.NewPasswordRandom(1, passwordName, type)).Should().Be(null!);

        }

        [Theory]
        [InlineData( "facebook", "24442")]
        [InlineData("gmail", "8fgtgf")]
        [InlineData("gmail", "8rfrfr")]

        public async void Creating_PasswordByUserNotExisting_NotAllowed(string passwordName, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.GetUtente(1)).Returns<Utente>(null!);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IPasswordService passwordService = new PasswordService(mock.Object, null);

            (await passwordService.NewPassword(1, passwordName, password)).Should().Be(false);


        }
    }
}
