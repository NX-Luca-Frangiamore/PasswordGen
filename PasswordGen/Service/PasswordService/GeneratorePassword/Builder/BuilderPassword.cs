using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;






namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder
{


    public abstract class BuilderPassword
    {
        private BuilderPassword? component;
        public BuilderPassword Root;
        
        public string? Done()
        {
            return (Generate()+component?.Done())??"";
        }
        public BuilderPassword(BuilderPassword root)
        {
            Root = root;
        }

        public BuilderPassword()//Utilizzato per inizializzare la catena di IBuilder
        {
            Root = this;
        }
        public abstract string? Generate();
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
