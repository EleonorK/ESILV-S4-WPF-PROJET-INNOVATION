using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class ImageVal
    {
        private string valeur;
        public ImageVal(string valeur)
        {
            this.valeur = valeur;
        }
        public string Valeur
        {
            get { return this.valeur; }
        }
    }
}
