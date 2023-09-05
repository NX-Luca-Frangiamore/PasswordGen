using Microsoft.AspNetCore.Identity;
using PasswordGen.Model;

namespace PasswordGen.Service.UtenteService
{
    public interface IUtenteService

    {   
        abstract public Task<bool> NewUtente(string? username, string? password);
        abstract public Task<bool> DeleteUtente(string? username, string? password);
        abstract public Task<bool> ChangeUtente(string? username, string? password, string? usernameNew, string? passwordNew);
        abstract public Task<Utente?> GetUtente(string? username, string? password);

    }
}
