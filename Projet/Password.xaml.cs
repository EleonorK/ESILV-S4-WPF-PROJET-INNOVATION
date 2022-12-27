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
    /// Logique d'interaction pour Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
        }
        private void Inscription(TextBox user, PasswordBox password, PasswordBox confirmer)
        {
            if (user.Text == "" && password.Password == "" && confirmer.Password == "")
            {
                MessageBox.Show("vous n'avez rien saisi !");
            }
            else
            {
                if (user.Text == "" || password.Password == "" || confirmer.Password == "")
                {
                    if (user.Text == "")
                    {
                        MessageBox.Show("Nom invalide");
                    }
                    if (password.Password == "")
                    {
                        MessageBox.Show("Mot de passe invalide");
                    }
                    if (password.Password != "" && confirmer.Password == "")
                    {
                        MessageBox.Show("Confirmer le mot de passe");
                    }
                }
            }
            if (user.Text != "" && password.Password != "" && confirmer.Password != "")
            {
                if (Utilisateur.pseudoExiste("repertoire.txt", user.Text) == true)
                {
                    MessageBox.Show("Ce pseudo existe déjà !");
                }
                else
                {
                    if (password.Password == confirmer.Password)
                    {
                        StreamWriter sw = new StreamWriter("repertoire.txt", true);
                        sw.WriteLine(user.Text + ";" + password.Password);
                        sw.Close();
                        MessageBox.Show("Connexion réussie ");
                    }
                    else
                    {
                        MessageBox.Show("Les 2 mdp ne correspondent pas");
                    }
                }               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inscription(labelNom, mdp, mdpConfirmer);
        }
    }
}
