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
    /// Logique d'interaction pour Register_User.xaml
    /// </summary>
    public partial class Register_User : Window
    {
        public Register_User()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void Inscription(TextBox user, PasswordBox password, PasswordBox confirmer, TextBox question1, TextBox question2, string User_Or_Admin)
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
            //Utilisateur user1 = new Utilisateur(filename, user, password);

            if (user.Text == "" && password.Password == "" && confirmer.Password == "" && question1.Text == "" && question2.Text == "")
            {
                MessageBox.Show("Pseudo ou mot de passe incorrect ", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (user.Text == "" || password.Password == "" || confirmer.Password == "")
                {
                    if (user.Text == "")
                    {
                        MessageBox.Show("Nom invalide", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (password.Password == "")
                    {
                        MessageBox.Show("Mot de passe invalide", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (password.Password != "" && confirmer.Password == "")
                    {
                        MessageBox.Show("Confirmer le mot de passe", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                if (Utilisateur.PseudoExiste(filename, user) == true)
                {
                    MessageBox.Show("Ce pseudo existe déjà !", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (user.Text != "" && password.Password != "" && confirmer.Password != "")
                {
                    if (question1.Text == "" || question2.Text == "" || (question1.Text == "" && question2.Text == ""))
                    {
                        MessageBox.Show("Répondez aux questions de sécu", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (password.Password == confirmer.Password)
                        {
                            StreamWriter sw = new StreamWriter("repertoire.txt", true);
                            sw.WriteLine();
                            sw.WriteLine(user.Text + ";" + password.Password + ";" + question1.Text + ";" + question2.Text);
                            sw.Close();
                            MessageBox.Show("Bienvenue " + user.Text);
                        }
                        else
                        {
                            MessageBox.Show("Les 2 mots de passe ne correspondent pas", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Inscription(labelNom, mdp, mdpConfirmer, question1, question2, "user");
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow accueil = new MainWindow();
            accueil.Show();
        }
    }
}
