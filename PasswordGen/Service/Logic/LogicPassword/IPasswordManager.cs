using Microsoft.AspNetCore.Identity;
using PasswordGen.Model;
using PasswordGen.Service.Db;

namespace PasswordGen.Service.Logic.LogicPassword
{
    public interface IPasswordManager

    {
       
        abstract public Task<bool> NewPassword(string username, string passwordUtente,string nomePassword,string password);
        abstract public Task<bool> DeletePassword(string username, string passwordUtente, string nomePassword);
        abstract public Task<bool> ChangePassword(string username, string passwordUtente, string nomePassword, string newPassword);
        abstract public Task<PasswordModel?> GetPassword(string username, string passwordUtente,string nomePassword);
        abstract public Task<List<PasswordModel>?> GetPassword(string username, string passwordUtente);

    }
}
