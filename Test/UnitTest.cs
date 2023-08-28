
using FluentAssertions;
using PasswordGen.Model;

namespace UnitTest
{
    public class UnitTest
    {
        [Theory]
        [InlineData("", "12356")]
        [InlineData("peppe1", "")]
        public void Creazione_Utente_NonAvvenuta(string username, string password)
        {
            Utente.Create(username, password).Should().BeNull();
        }
        [Theory]
        [InlineData("luca123", "12356","")]
        [InlineData("peppe1", "333343","fff")]
        public void Cambio_CredenzialiUtente_NonAvvenuto(string username, string password,string newPassword)
        {

            Utente? u=Utente.Create(username, password);

            u.ChangeCredenziali("", newPassword);
           
            u.UsernameUtente.Should().Be(username);
            u.PasswordUtente.Should().NotBe(newPassword);
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
    }
}