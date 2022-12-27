using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Projet
{
    class ImageGraphique
    {
        private ImageVal im;
        //private RechercheContenu_Util tabIm;

        /*
        public ImageGraphique(string valeur, RechercheContenu_Util m)
        {
            im = new ImageVal(valeur);
            Content = im.Valeur;
            Click += ActionOn_Click;
            this.tabIm = m;
        }
        */
        public string ValeurImage
        {
            get { return im.Valeur; }
        }
        private void ActionOn_Click(object sender, RoutedEventArgs e)
        {
            //tabIm.MiseAJourSerie(this);
        }
    }
}
