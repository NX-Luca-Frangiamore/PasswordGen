
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using PasswordGen.Data;
using PasswordGen.Model;
using PasswordGen.Repository;
using PasswordGen.Service.PasswordService;
using PasswordGen.Service.PasswordService.GeneratorePassword.Factory;
using PasswordGen.Service.UtenteService;
using static PasswordGen.Service.PasswordService.GeneratorePassword.Factory.FactoryBuilder;

namespace User
{
    public class UnitTestUser
    {
        [Theory]
        [InlineData("", "12")]
        [InlineData("peppe1", "")]
        public async void Creation_InvalidUser_NotAllowed(string username, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            mock.Setup(x => x.GetUtente(username, password)).ReturnsAsync(default(Utente));
            mock.Setup(x => x.NewUtente(It.IsAny<Utente>())).ReturnsAsync(true);
            IUtenteService utenteService = new UtenteService(mock.Object);
        
            (await utenteService.NewUtente(username, password)).Should().Be(false);
           
        }
        [Theory]
        [InlineData("luca", "12356")]
        [InlineData("peppe1", "fg7f")]
        public async void Creation_ValidUser_Allowed(string username, string password)
        {
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
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
            Mock<IManagerDb> mock = new Mock<IManagerDb>(null!);
            mock.Setup(x => x.GetUtente(username, passwordUsername)).ReturnsAsync(Utente.Create(username, passwordUsername));
            mock.Setup(x => x.Save()).ReturnsAsync(true);
            IUtenteService utenteService = new UtenteService(mock.Object);
            
            (await (utenteService.ChangeUtente(1,newUsername,newPassword))).Should().Be(false);
      
        }
       
       
    }
}