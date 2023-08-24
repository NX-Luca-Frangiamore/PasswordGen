using Microsoft.AspNetCore.Identity;
using PasswordGen.Model;
using PasswordGen.Service.Db;

namespace PasswordGen.Service.Business.BusinessUtente
{
    public interface IManagerUtente

    {   
        abstract public bool NewUtente(string username, string password);
        abstract public bool DeleteUtente(string username, string password);
        abstract public bool ChangeUtente(string username, string password, string usernameNew, string passwordNew);
        abstract public Utente? GetUtente(string username, string password);

    }
}
