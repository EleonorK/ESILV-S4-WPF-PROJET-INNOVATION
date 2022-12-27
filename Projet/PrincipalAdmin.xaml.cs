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
using System.IO;

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour PrincipalAdmin.xaml
    /// </summary>
    public partial class PrincipalAdmin : Window
    {
        public PrincipalAdmin()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void OuvrirRepertoire_Click(object sender, RoutedEventArgs e)
        {
            string filename = "repertoire.txt";
            fichier.Text = File.ReadAllText(filename);
        }

        private void FermerRepertoire_Click(object sender, RoutedEventArgs e)
        {
            fichier.Text = "";
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login_Admin l = new Login_Admin();
            l.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string filename = "repertoire.txt";
            string texte = File.ReadAllText(filename);
            texte = texte.Replace(texte, fichier.Text);
            File.WriteAllText(filename, texte);
        }
    }
}
