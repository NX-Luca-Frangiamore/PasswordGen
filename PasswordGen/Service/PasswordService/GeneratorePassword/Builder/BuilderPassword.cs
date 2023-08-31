using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;






namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder
{


    public class BuilderPassword : IBuilderPassword
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
        public IBuilderPassword AddGenerazioneMauCaratteriCasuali(int m)
        {
            Components.Add(new CaratteriCasualiMau(m));
            return this;
        }
        public IBuilderPassword AddGenerazioneMinCaratteriCasuali(int m)
        {
            Components.Add(new CaratteriCasualiMin(m));
            return this;
        }

        public IBuilderPassword AddGenerazioneMCaratteriSpecialiCasuali(int m)
        {
            Components.Add(new CaratteriSpecialiCasuali(m));
            return this;
        }

        public IBuilderPassword AddGenerazioneMNumeriCasuali(int m)
        {
            Components.Add(new NumeriCasuali(m));
            return this;
        }
    }
}
