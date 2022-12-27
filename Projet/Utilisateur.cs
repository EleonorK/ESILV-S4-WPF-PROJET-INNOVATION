using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Projet
{
    class Utilisateur // changer le nom par utilisateur/admin et supprimer la classe Admin.cs
    {
        //attributs
        private string fileName;
        private TextBox nom;
        private PasswordBox mdp;

        // constructeurs
        public Utilisateur(string fileName, TextBox nom, PasswordBox mdp)
        {
            this.fileName = fileName;
            this.nom = nom;
            this.mdp = mdp;
        }

        //propriétés
        public string FileName
        {
            get { return this.fileName; }
        }
        public TextBox Nom
        {
            get { return this.nom; }
        }
        public PasswordBox Mdp
        {
            get { return this.mdp; }
        }

        //méthodes
        public static bool Login(string fileName, TextBox nom, PasswordBox mdp) // se connecter à son compte 
        {
            bool exist = false;
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string ligne = "";
                string[] temp = null;
                while (sr.Peek() > 0 && exist == false)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split(';');
                    if (temp[0].ToLower() == nom.Text.ToLower() && temp[1] == mdp.Password)
                    {
                        exist = true;
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return exist;
        }

        public static bool PseudoExiste(string fileName, TextBox pseudo) // vérifie si le pseudo existe déjà
        {
            bool exist = false;
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string ligne = "";
                string[] tab = null;
                while (sr.Peek() > 0 && exist == false)
                {   
                    ligne = sr.ReadLine();
                    tab = ligne.Split(';');
                    if (tab[0].ToLower() == pseudo.Text.ToLower())
                    {
                        exist = true;
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return exist;
        }

        public static bool QuestionSecurite(string fileName, TextBox pseudo, TextBox question1, TextBox question2) // vérification en cas d'oubli mdp 
        {
            bool exist = false;
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string ligne = "";
                string[] temp = null;
                while (sr.Peek() > 0 && exist == false)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split(';');
                    
                    if (temp[0].ToLower()==pseudo.Text.ToLower() && temp[2].ToLower() == question1.Text.ToLower() && temp[3].ToLower() == question2.Text.ToLower())
                    {
                        exist = true;
                    }                    
                }
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return exist;
        }
        public static string MotdePasse(string fileName, TextBox pseudo, TextBox question1, TextBox question2) // donner accès au mdp si question sécu correcte 
        {
            bool exist = false;
            string mdp = "";
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string ligne = "";
                string[] temp = null;
                while (sr.Peek() > 0 && exist == false)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split(';');

                    if (temp[0].ToLower() == pseudo.Text.ToLower() && temp[2].ToLower() == question1.Text.ToLower() && temp[3].ToLower() == question2.Text.ToLower())
                    {
                        exist = true;
                        mdp = temp[1];
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return mdp;
        }

        
    }
}
