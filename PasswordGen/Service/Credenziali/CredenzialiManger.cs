namespace PasswordGen.Service.Credenziali
{
    public class CredenzialiManger
    {
        private static ICheckCredenziali _CheckUsername;
        private static ICheckCredenziali _CheckPassword;

        static CredenzialiManger()
        {
           
            _CheckUsername = new CheckCredenziali()
                                              .NotLessThan(2)
                                              .NotEmpty()
                                              .NotMoreThan(10);
            _CheckPassword = new CheckCredenziali()
                                             .NotLessThan(3)
                                             .NotEmpty()
                                             .NotMoreThan(20);
        }
        public static bool VerificaUsername(string? username)
        {
            return _CheckUsername.Check(username);
        }
        public static bool VerificaPassword(string? password)
        {
            return _CheckPassword.Check(password);
        }
        public static bool Verifica(string? username, string? password)
        {
            if (!VerificaUsername(username)) return false;
            if (!VerificaPassword(password)) return false;
            return true;
        }
    }
}
