using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class CentrerLeTexte
    {
        private string texte;
        private int nbEspaces = 0;

        public CentrerLeTexte()
        {//initialisation par défaut de chacun des attributs
            this.texte = "";
            this.nbEspaces = 0;
        }
        public CentrerLeTexte(string texte, int nbEspaces)
        {
            this.texte = texte;
            this.nbEspaces = (Console.WindowWidth - this.texte.Length) / 2;
        }

        public string Texte
        {
            get { return this.texte; }
        }
        public int NbEspaces
        {
            get { return this.nbEspaces; }
        }

        public static void centrerLeTexte(string texte)
        {
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.WriteLine(texte);
        }

        public static void centrerLeTexteL(string texte)
        {
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.Write(texte);
        }
    }
}
