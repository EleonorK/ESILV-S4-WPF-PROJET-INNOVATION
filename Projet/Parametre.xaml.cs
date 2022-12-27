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
    /// Logique d'interaction pour Parametre.xaml
    /// </summary>
    public partial class Parametre : Window
    {
        private string utilisateurActuel;
        public Parametre(string nom)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.utilisateurActuel = nom;
        }
        private void ChangeName_Click(object sender, RoutedEventArgs e)
        {
            string filename = "repertoire.txt";
            string texte = File.ReadAllText(filename);
            
            if(oldName.Text==""|| newName.Text=="")
            {
                MessageBox.Show("Informations manquantes sur votre nom d'utilisateur ", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if(Utilisateur.PseudoExiste(filename,oldName)==true)
                {
                    if(Utilisateur.PseudoExiste(filename,newName)==true)
                    {
                        MessageBox.Show("Ce pseudo existe déja", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        texte = texte.Replace(oldName.Text, newName.Text);
                        File.WriteAllText(filename, texte);
                        this.Hide();
                        ChangerNomOK c = new ChangerNomOK(this.utilisateurActuel);
                        c.Show();
                    }                    
                }
                else
                {
                    MessageBox.Show("Ce pseudo n'existe pas", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }                
            }           
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Profil p = new Profil(this.utilisateurActuel);
            p.Show();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChangerMdp c = new ChangerMdp(this.utilisateurActuel);
            c.Show();
        }

        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Show();
        }
    }
}
