using Nest;
using PasswordGen.Model;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;






namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder
{


    public class BuilderPassword : IBuilderPassword
    {
        private readonly Random Random;
        private delegate string Generator();
        private readonly List<Generator> GeneratonList;
        public string Done()
        {
            string s = "";
            foreach (Generator component in GeneratonList)
                s += component();
            return s;
        }
        
        public BuilderPassword()
        {
            Random = new Random();
            GeneratonList = new List<Generator>();

        }
        public IBuilderPassword AddGenerazioneMauCaratteriCasuali(int m)

        {
            GeneratonList.Add(() => { return Generate(65, 91, m); });
            return this;
        }
        public IBuilderPassword AddGenerazioneMinCaratteriCasuali(int m)
        {
            GeneratonList.Add(()=> { return Generate(97, 123, m); });
            return this;
        }

        public IBuilderPassword AddGenerazioneMCaratteriSpecialiCasuali(int m)
        {
            GeneratonList.Add(() => { return Generate(33, 48, m); });
            return this;
        }

        public IBuilderPassword AddGenerazioneMNumeriCasuali(int m)
        {
            GeneratonList.Add(() => { string r = "";
                                      for (int i = 0; i < m; i++)
                                         r += Random.Next(10);
                                      return r;
                                     });
            return this;
        }
        /**
         *<param name="startRange">Inizio range caratteri ascii interessati</param>
         *<param name="startRange">Fine range caratteri ascii interessati</param>
         *<param name="m">Numero di elementi richiesti</param>
         */
        private string Generate(int startRange, int endRange, int m)
        {
            string password = "";
            for (int i = 0; i < m; i++)
                password += ((char)Random.Next(startRange, endRange) + "");
            return password;
        }
    }
}
