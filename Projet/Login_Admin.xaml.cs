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
    /// Logique d'interaction pour Login1.xaml
    /// </summary>
    public partial class Login_Admin : Window
    {
        public Login_Admin()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void Connexion(TextBox user, PasswordBox password, string User_Or_Admin)
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

            Utilisateur user1 = new Utilisateur(filename, user, password);

            if (user.Text == "" && password.Password == "")
            {
                MessageBox.Show("vous n'avez rien saisi !");
            }
            else
            {
                if (user.Text == "" || password.Password == "")
                {
                    if (user.Text == "")
                    {
                        MessageBox.Show("Nom invalide");
                    }
                    if (password.Password == "")
                    {
                        MessageBox.Show("Mot de passe invalide");
                    }
                }
            }
            if (user.Text != "" && password.Password != "")
            {
                if (Utilisateur.Login(filename, user1.Nom, user1.Mdp) == true)
                {
                    this.Hide();
                    PrincipalAdmin p = new PrincipalAdmin();
                    p.Show();
                }
                else
                {
                    MessageBox.Show("Pseudo ou mot de passe incorrect ");
                }
            }
        }

        private void SeConnecter_Click(object sender, RoutedEventArgs e)
        {
            Connexion(nom, mdp, "admin");
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Show();
        }
    }
}
