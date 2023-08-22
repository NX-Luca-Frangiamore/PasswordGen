using Microsoft.EntityFrameworkCore;
using PasswordGen.Model;

namespace PasswordGen.Service
{
    public class ManagerDb : IManagerDb
    {
        public ManagerDb(Context db) : base(db)
        {
        }

        public override int getId(string _username, string _password)
        {
            return db.utente.Where(x=>x.username==_username && x.password==_password).Select(x=>x.id).FirstOrDefault();
        }

        public override Password? getPassword(int _idUtente, string _name)
        {
            var r=db.utente.Include(x => x.passwords).Where(x => x.id == _idUtente).Select(x => x.passwords.Where(x => x.name == _name)).FirstOrDefault();
            if(r==null) return null;
            return r.FirstOrDefault();
           
        }

        public override bool newPassword(int _idUtente, Password _password)
        {   
            var utente = db.utente.Find(_idUtente);
            if ( utente== null) return false;
            utente.passwords.Append(_password);
            db.SaveChanges();
            return true;
            
        }

        public override bool newUtente(string _username, string _password)
        {
            if (db.utente.Where(x => x.username == _username).FirstOrDefault() != null) return false;
            db.utente.Add(new Utente { username = _username, password = _password });
            db.SaveChanges();
            return true;
        }
    }
}
