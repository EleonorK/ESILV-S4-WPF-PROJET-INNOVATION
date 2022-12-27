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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string utilisateurActuel;
        public MainWindow(string nom)
        {
            this.utilisateurActuel = nom;
        }
        
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        public void Connexion(TextBox user, PasswordBox password, string User_Or_Admin)
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
                MessageBox.Show("vous n'avez rien saisi !", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (user.Text == "" || password.Password == "")
                {
                    if (user.Text == "")
                    {
                        MessageBox.Show("Nom invalide", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (password.Password == "")
                    {
                        MessageBox.Show("Mot de passe invalide", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            if (user.Text != "" && password.Password != "")
            {
                if ((Utilisateur.Login(filename, user1.Nom, user1.Mdp)) == true)
                {
                    this.Hide();
                    Profil p = new Profil(nom.Text);
                    p.Show();
                    //this.utilisateurActuel = nom.Text;
                }
                else
                {
                    MessageBox.Show("Pseudo ou mot de passe incorrect ", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public string UtilisateurActuel
        {
            get { return this.utilisateurActuel; }
        }
        
        private void Login_Click(object sender, RoutedEventArgs e) 
        {
            Connexion(nom, mdp, "user");
        }

        private void Admin_Click(object sender, RoutedEventArgs e) 
        {
            this.Hide();

            Login_Admin connexion = new Login_Admin();  
            connexion.Show();
        }

        private void MdpOubli_Click(object sender, RoutedEventArgs e) 
        {
            this.Hide();
            MdpOublier mdp = new MdpOublier();
            mdp.Show();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Register_User connexion = new Register_User();
            connexion.Show();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrincipalAdmin p = new PrincipalAdmin();
            p.Show();
        }

        /*
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InformationsSerie i = new InformationsSerie(empire.Content.ToString(), nom.Text);
            i.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InfoFilm i = new InfoFilm("soul", nom.Text);
            i.Show();
        }
        */
    }
}
