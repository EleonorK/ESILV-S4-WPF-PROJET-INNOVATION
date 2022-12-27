using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Projet
{
    public class GenreGraphique : CheckBox
    {
        private Genre leGenre;
        private ListCheck liste;

        public GenreGraphique(string valeureGenre, ListCheck m)
        {
            leGenre = new Genre(valeureGenre);
            Content = leGenre.Valeur;
            Click += Action_Click;
            this.liste = m;
        }
        public string ValeurGenre
        {
            get { return leGenre.Valeur; }
        }
        //methodes
        public void CheckGenre()
        {
            //1. changer l'etat du genre
            leGenre.Cocher();
        }
        private void Action_Click(object sender, RoutedEventArgs e)
        {
            //methode associer a un click box
            //1.se coche
            CheckGenre();
            liste.MiseAJourEpi(this);
            //2.lien avec le plateau
            //if (autre != null) { autre.MiseAjourAutre(this); }
        }
        public bool Test1()
        {
            return leGenre.Etat;
        }
    }

}
