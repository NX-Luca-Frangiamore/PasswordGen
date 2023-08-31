using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;






namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder
{


    public class BuilderPassword
    {
        private List<IElementiCasuali> Components;
        
        public string Done()
        {
            string s = "";
            foreach(IElementiCasuali component in Components)
                s += component.Generate();
            return s;
        }
        public BuilderPassword()
        {
            Components=new List<IElementiCasuali>();
        }
        public BuilderPassword AddGenerazioneMauCaratteriCasuali(int m)
        {
            Components.Add(new CaratteriCasualiMau(m));
            return this;
        }
        public BuilderPassword AddGenerazioneMinCaratteriCasuali(int m)
        {
            Components.Add(new CaratteriCasualiMin(m));
            return this;
        }

        public BuilderPassword AddGenerazioneMCaratteriSpecialiCasuali(int m)
        {
            Components.Add(new CaratteriSpecialiCasuali(m));
            return this;
        }

        public BuilderPassword AddGenerazioneMNumeriCasuali(int m)
        {
            Components.Add(new NumeriCasuali(m));
            return this;
        }
    }
}
