using Microsoft.AspNetCore.Identity;
using PasswordGen.Model;
using PasswordGen.Service.Db;

namespace PasswordGen.Service.Business.BusinessPassword
{
    public interface IManagerPassword

    {
       
        abstract public bool NewPassword(string username, string passwordUtente,string nomePassword,string password);
        abstract public bool DeletePassword(string username, string passwordUtente, string nomePassword);
        abstract public bool ChangePassword(string username, string passwordUtente, string nomePassword, string newPassword);
        abstract public PasswordModel? GetPassword(string username, string passwordUtente,string nomePassword);
        abstract public List<PasswordModel>? GetPassword(string username, string passwordUtente);

    }
}
