namespace PasswordGen
{
    public static class CredenzialiManger
    {
        public static bool VerificaUserName(string? username)
        {
            if (username is null) return false;
            if (string.IsNullOrEmpty(username)) return false;
            return true;
        }
        public static bool VerificaPassword(string? password) {
            if (password is null) return false;
            if (string.IsNullOrEmpty(password)) return false;
            if (password.Length < 3) return false;
            if (password.Length > 10) return false;
            return true;
        }
        public static bool Verifica(string? username, string? password)
        {
            if (!VerificaUserName(username)) return false;
            if(!VerificaPassword(password)) return false;
            return true;
        }
    }
}
