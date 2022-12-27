using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Projet
{
    class ListGraphique : ComboBox
    {
        private Saison saison;
        private ListCheck listSaison;
        public ListGraphique(string valeur, ListCheck m)
        {
            saison = new Saison(valeur);
            Text = saison.Valeur;
            this.listSaison = m;
        }

    }
}
