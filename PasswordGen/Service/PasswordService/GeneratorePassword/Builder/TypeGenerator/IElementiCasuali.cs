
using System;
using System.Collections.ObjectModel;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    public abstract class IElementiCasuali:BuilderPassword
    {
        protected readonly Random Random = new Random();
        private readonly Dictionary<string, int> Range=new Dictionary<string, int>();
        protected readonly int MCharacter;
        /**
         * <summary>Viene invocato alla creazione dei sotto moduli</summary>
         * <param name="startRange">Indica l'inizio del range degli elementi generati in tabella ascii</param>
         * <param name="endRange">Indica la fine del range degli elementi generati in tabella ascii</param>
         * <param name="m">numero di elementi da generare</param>
         * <param name="root">root del builder</param>
         */
        protected IElementiCasuali(BuilderPassword root, int startRange, int endRange,int m) :base(root)
        {
            
            Range["start"] = startRange;
            Range["end"] = endRange;
            MCharacter = m;
        }
        /**
         * <summary>Viene invocato alla creazione del builder</summary>
         * <param name="startRange">Indica l'inizio del range degli elementi generati in tabella ascii</param>
         * <param name="endRange">Indica la fine del range degli elementi generati in tabella ascii</param>
         * <param name="m">numero di elementi da generare</param>
         */
        protected IElementiCasuali(int startRange, int endRange, int m) 
        {
            Range["start"] = startRange;
            Range["end"] = endRange;
            MCharacter = m;
        }
        public override string Generate()
        {
            string password = "";
            for (int i = 0; i < MCharacter; i++)
                password += ((char)Random.Next(Range["start"], Range["end"]) + "");
            return password;
        }
    }
}
