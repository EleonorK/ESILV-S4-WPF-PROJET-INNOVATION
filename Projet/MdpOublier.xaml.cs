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
    /// Logique d'interaction pour MdpOublier.xaml
    /// </summary>
    public partial class MdpOublier : Window
    {
        public MdpOublier()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private int nbessaiRestant = 5; // 5 essais max pour se connecter sinon compte supprimé
        private void QuestionSecu(TextBox user, TextBox question1, TextBox question2, string User_Or_Admin)
        {
            string filename = "";
            if (User_Or_Admin == "user")
            {
                filename = "repertoire.txt";
            }
            if (User_Or_Admin == "admin")
            {
                filename = "admin.txt";
            }
            if (question1.Text == "" && question2.Text == "")
            {
                MessageBox.Show("vous n'avez rien saisi !", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (question1.Text == "" || question2.Text == "")
                {
                    MessageBox.Show("Répondez aux questions ", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (question1.Text != "" && question2.Text != "")
            {
                if (Utilisateur.QuestionSecurite(filename, user, question1, question2) == true)
                {
                    string mdp = Utilisateur.MotdePasse(filename, user, question1, question2);
                    MessageBox.Show("Connexion réussie, votre mot de passe est : " + mdp, "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if(Utilisateur.PseudoExiste(filename,nom)==false)
                    {
                        MessageBox.Show("Si votre pseudo est incorrect, vous ne pourrez pas récupérer votre mot de passe", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        nbessaiRestant--;
                        if (nbessaiRestant < 1)
                        {                           
                            string texte =File.ReadAllText(filename);
                            texte = texte.Replace(nom.Text, "");
                            File.WriteAllText(filename, texte);                            
                            MessageBox.Show("Votre compte a été supprimé ", "", MessageBoxButton.OK, MessageBoxImage.Error);
                            this.Hide();
                            MainWindow m = new MainWindow();
                            m.Show();
                        }
                        else
                        {
                            MessageBox.Show("Réponses incorrectes, vous avez encore " + nbessaiRestant + " essais", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }                                        
                }
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            QuestionSecu(nom, question1, question2, "user");
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow accueil = new MainWindow();
            accueil.Show();
        }
    }
}
