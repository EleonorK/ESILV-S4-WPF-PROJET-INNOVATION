using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Projet
{
    public class BoutonSerie : Button
    {
        // attribut
        private MesSeries serie;
        private MesFilms film;

        //constructeur
        public BoutonSerie()
        {
            Click += ActionOn_Click;
        }
        public BoutonSerie(string valeurCarte, MesSeries serie)
        {
            Click += ActionOn_Click;
            Content = valeurCarte;
            // connaissance du plateau de jeu
            this.serie = serie;
        }
        public BoutonSerie(string valeurCarte, MesFilms film)
        {
            Click += ActionOn_Click;
            Content = valeurCarte;
            // connaissance du plateau de jeu
            this.film = film;
        }

        private void ActionOn_Click(object sender, RoutedEventArgs e)
        {
            if(this.serie != null)
            {
                serie.MiseAJour(this);
            }
            else
            {
                film.MiseAJour(this);
            }
            
            // méthode associée à un clic bouton
        }
    }
}
