using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;






namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder
{


    public class BuilderPassword:IBuilderPassword
    {
        private Random Random = new Random();
        private BuilderPassword? component;
        public BuilderPassword Root;
        protected int mCharacter;
        protected string Generate(int m, int initRange, int endRange)
        {
            string password = "";
            for (int i = 0; i < m; i++)
                password += ((char)Random.Next(initRange, endRange) + "");
            return password;
        }
        public string? Done()
        {
            return (component?.Generate()+component?.Done())??"";
        }
        protected BuilderPassword(BuilderPassword? root)
        {
            Root = root??this;//set root
        }
        public static BuilderPassword Create()
        {
            return new BuilderPassword(null);//prima creazione
        }
        public virtual string? Generate() { return ""; }
        public BuilderPassword AddGenerazioneMauCaratteriCasuali(int m)
        {
            component = new CaratteriCasualiMau(m,Root);
            return component;
        }
        public BuilderPassword AddGenerazioneMinCaratteriCasuali(int m)
        {
            component=new CaratteriCasualiMin(m, Root);
            return component;
        }

        public BuilderPassword AddGenerazioneMCaratteriSpecialiCasuali(int m)
        {
            component=new CaratteriSpecialiCasuali(m, Root);
            return component;
        }

        public BuilderPassword AddGenerazioneMNumeriCasuali(int m)
        {
            component=new NumeriCasuali(m, Root);
            return component;
        }
    }
}
