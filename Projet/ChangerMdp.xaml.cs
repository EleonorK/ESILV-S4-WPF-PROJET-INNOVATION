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
    /// Logique d'interaction pour ChangerMdp.xaml
    /// </summary>
    public partial class ChangerMdp : Window
    {
        private string utilisateurActuel;
        public ChangerMdp(string nom)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.utilisateurActuel = nom;
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string filename = "repertoire.txt";
            string texte = File.ReadAllText(filename);
            if (nom.Text == "" || oldPassword.Password == "" || newPassword.Password == "")
            {
                if (nom.Text == "")
                {
                    MessageBox.Show("Indiquez votre ancien nom d'utilisateur ", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (oldPassword.Password == "" || newPassword.Password == "")
                {
                    MessageBox.Show("Vérifiez si toutes les cases sont remplies ", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                string chaine = nom.Text + ";" + oldPassword.Password;
                if(texte.Contains(chaine))
                {
                    texte = texte.Replace(nom.Text + ";" + oldPassword.Password, nom.Text + ";" + newPassword.Password);
                    File.WriteAllText(filename, texte);
                    this.Hide();
                    ChangerMdpOK c = new ChangerMdpOK(this.utilisateurActuel);
                    c.Show();
                }
                else
                {
                    MessageBox.Show("Nom ou ancien mot de passe incorrect", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Parametre p = new Parametre(this.utilisateurActuel);
            p.Show();
        }

        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Show();
        }
    }
}
