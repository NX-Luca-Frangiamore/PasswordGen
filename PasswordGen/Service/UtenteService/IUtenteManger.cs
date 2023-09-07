using Microsoft.AspNetCore.Identity;
using PasswordGen.Model;

namespace PasswordGen.Service.UtenteService
{
    public interface IUtenteService

    {   
        abstract public Task<bool> NewUtente(string? username,string? password);
        abstract public Task<bool> DeleteUtente(int? idUtente);
        abstract public Task<bool> ChangeUtente(int? idUtente, string? usernameNew, string? passwordNew);
        abstract public Task<Utente?> GetUtente(int? idUtente);

    }
}
