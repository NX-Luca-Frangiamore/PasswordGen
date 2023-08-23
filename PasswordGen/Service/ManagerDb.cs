using Microsoft.EntityFrameworkCore;
using PasswordGen.Model;

namespace PasswordGen.Service
{
    public class ManagerDb : IManagerDb
    {
        public ManagerDb(Context db) : base(db)
        {
        }

        public override bool changePassword(int _idUtente, string _name, string _newPassword)
        {
            var r=db.utente.Find(_idUtente).passwords.Where(x => x.name == _name).FirstOrDefault();
            if (r == null) return false;
            r.password = _newPassword;
            db.SaveChanges();

            return true;
        }

        public override bool changeUtente(string _username, string _password, string _newUsername,string _newPassword)
        {
            var r=db.utente.Where(x => x.username == _username && x.password == _password).FirstOrDefault();
            if (r == null) return false;
            if(_newPassword!="")
               r.password = _newPassword;
            if (_newUsername != "")
                r.username = _newUsername;
            db.SaveChanges();
            return true;
        }

        public override bool deletePassword(int _idUtente, string _nome)
        {
            var r = db.passwords.Where(x => x.utenteId == _idUtente && x.name == _nome).FirstOrDefault();
            var rUtenti = db.utente.Where(x=>x.id==_idUtente).Include(x => x.passwords).FirstOrDefault().passwords;
            if(rUtenti.Count == 0) return false;
               rUtenti.Remove(rUtenti.Where(x => x.name == _nome).First());
            if (r == null) return false;
            db.passwords.Remove(r);
            db.SaveChanges();
            return true;
        }
        public override bool deleteUtente(int _idUtente)
        {
            var r = db.utente.Where(x=>x.id==_idUtente).FirstOrDefault();
            var rPasswords = db.passwords.Where(x => x.utenteId == _idUtente);
            foreach (Password p in rPasswords)
                db.passwords.Remove(p);
            if(r == null) return false;
            db.utente.Remove(r);
            db.SaveChanges();
            return true;
        }

        public override int getId(string _username, string _password)
        {
            return db.utente.Where(x=>x.username==_username && x.password==_password).Select(x=>x.id).FirstOrDefault();
        }

        public override Password? getPassword(int _idUtente, string _name)
        {
            Password r=null;
            if(getPassword(_idUtente) is List<Password>listPassword)
                 r=listPassword.Where(x => x.name == _name).FirstOrDefault();
            return r; 
        }

        public override List<Password>? getPassword(int _idUtente)
        {
            var r=db.utente.Include(x => x.passwords).Where(x => x.id == _idUtente).Select(x => x.passwords).FirstOrDefault();
            if (r == null) return null;
            return r;
        }

        public override bool newPassword(int _idUtente, Password _password)
        {   
            var utente = db.utente.Find(_idUtente);
          
            _password.utenteId = _idUtente;
            db.passwords.Add(_password);
            if ( utente== null) return false;
            utente.passwords.Add(_password);
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
