using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {
        private string UtilisateurActuel;
        public Profil(string nom)
        {
            InitializeComponent();
            this.UtilisateurActuel = nom;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Parametre_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Parametre p = new Parametre(this.UtilisateurActuel);
            p.Show();
        }

        private void MesSeries_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MesSeries m = new MesSeries(this.UtilisateurActuel);
            m.Show();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Show();            
        }

        private void MesFilms_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MesFilms m = new MesFilms(this.UtilisateurActuel);
            m.Show();
        }
    }
}
