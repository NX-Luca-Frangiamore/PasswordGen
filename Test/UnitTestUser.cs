
using FluentAssertions;
using Moq;
using PasswordGen.Model;
using PasswordGen.Repository;
using PasswordGen.Service.UtenteService;
namespace User
{
    public class UnitTestUser
    {
        [Theory]
        [InlineData("Luca", "333343")]
        [InlineData("peppe1", "333343")]
        public void Creation_UserWithCorrectCredential_Allowed(string username, string passwordUsername)
        {
            var u = Utente.Create(username, passwordUsername);

            u.UsernameUtente.Should().Be(username);
            u.PasswordUtente.Should().Be(passwordUsername);

        }
        [Theory]
        [InlineData("Luca", "4")]
        [InlineData("", "333343")]
        public void Creation_UserWithWrongCredential_NotAllowed(string username, string passwordUsername)
        {
            var u = Utente.Create(username, passwordUsername);

            u.Should().Be(null);

        }

        [Theory]
        [InlineData("Luca", "333343", null,"fffr")]
        [InlineData("peppe1", "333343","frfr","ff")]
        public async void Changing_WrongUserCredential_NotAllowed(string username, string passwordUsername,string newUsername,string newPassword)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.GetUtente(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IUtenteService utenteService = new UtenteService(mock.Object);

            var u = await utenteService.GetUtente(1);
            u.UsernameUtente.Should().NotBe(newUsername);
            u.PasswordUtente.Should().NotBe(newPassword);

        }

        [Theory]
        [InlineData("Luca", "333343", null, "fffr")]
        [InlineData("peppe1", "333343", "frfr", "4444")]
        public async void Changing_UserCredential_Allowed(string username, string passwordUsername, string newUsername, string newPassword)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.GetUtente(1)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IUtenteService utenteService = new UtenteService(mock.Object);

            await utenteService.ChangeUtente(1,newUsername,newPassword);

            var u=await utenteService.GetUtente(1);
            u.UsernameUtente.Should().Be(newUsername??username);
            u.PasswordUtente.Should().Be(newPassword??passwordUsername);
        }
        [Theory]
        [InlineData("peppe", "1g2")]
        [InlineData("luca", "333343")]

        public async void Creation_DuplicatedUser_NotAllowed(string username, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtente(username, password)).ReturnsAsync(Utente.Create(username, password));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IUtenteService utenteService = new UtenteService(mock.Object);

            (await utenteService.NewUtente(username, password)).Should().Be(false);

        }
    }
}