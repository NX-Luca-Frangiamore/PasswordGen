namespace PasswordGen.Service.Credenziali
{
    public class CheckCredenziali : ICheckCredenziali
    {
        private delegate bool _Check(string? s);
        private List<_Check> CheckList;
        public CheckCredenziali()
        {
            CheckList = new List<_Check>();
        }
        public bool Check(string? s)
        {
            foreach(_Check c in CheckList)
            {
                if(!c(s))
                    return false;
            }
            return true;
        }

        public ICheckCredenziali NotEmpty()
        {
            CheckList.Add((string? s) => { return s is not ""; }) ;
            return this;
        }

        public ICheckCredenziali NotLessThan(int n)
        {
            CheckList.Add((string? s) => { return s?.Length > n; });
            return this;
        }

        public ICheckCredenziali NotMoreThan(int n)
        {
            CheckList.Add((string? s) => { return s?.Length < n; });
            return this;
        }
    }
}
