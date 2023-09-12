using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace PasswordGen.Service.Credenziali
{
    public interface ICheckCredenziali
    {
        public ICheckCredenziali NotEmpty();
        public ICheckCredenziali NotLessThan(int n);
        public ICheckCredenziali NotMoreThan(int n);
        public bool Check(string? s);
    }
}
