using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Genre
    {
        string valeur;
        bool etat;
        public Genre(string valeur)
        {
            this.valeur = valeur;
            this.etat = false;
        }
        public string Valeur
        {
            get { return this.valeur; }
        }
        public bool Etat
        {
            get { return this.etat; }
        }
        //changement d'état
        public void Cocher()
        {
            etat = !etat;
        }
    }
}
