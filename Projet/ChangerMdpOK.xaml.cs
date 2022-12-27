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
    /// Logique d'interaction pour ChangerMdpOK.xaml
    /// </summary>
    public partial class ChangerMdpOK : Window
    {
        private string utilisateurActuel;
        public ChangerMdpOK(string nom)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.utilisateurActuel = nom;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            Profil p = new Profil(this.utilisateurActuel);
            p.Show();
        }
    }
}
