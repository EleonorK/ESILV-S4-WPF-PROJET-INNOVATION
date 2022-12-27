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
    /// Logique d'interaction pour InfoFilm.xaml
    /// </summary>
    public partial class InfoFilm : Window
    {
        #region attributs

        private string utilisateurActuel;
        public string filmActuel;
        private string filename = "SerieSuivie.txt";
        private List<string> listeEpisodeVu; // liste des épisodes présents dans le fichier
        private string typeActuel;

        #endregion attributs

        #region constructeurs

        public InfoFilm(string nomFilm, string nom)
        {
            InitializeComponent();
            this.filmActuel = nomFilm;
            this.utilisateurActuel = nom;
            AffichageImage("ContenuTotal.txt", nomFilm);
            this.typeActuel = RechercheType()[0].ToString().ToUpper() + RechercheType().Substring(1).ToLower();
            MessageBox.Show("type " + this.typeActuel);
            MessageBox.Show("test 100");
            Informations(nomFilm, this.typeActuel+".txt");
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public string RechercheType()
        {
            string type = "";
            try
            {
                StreamReader sr = new StreamReader("Film.txt");
                string ligne = "";
                string[] temp = null;
                while (sr.Peek() > 0)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split('+');

                    if (temp[0].ToLower() == this.filmActuel.ToLower())
                    {
                        type = temp[1];
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
            return type;
        }

        public InfoFilm(List<string> listeEpisodeVu)
        {
            this.listeEpisodeVu = listeEpisodeVu;
        }

        #endregion constructeurs

        #region propriétés
        public string UtilisateurActuel
        {
            get { return this.utilisateurActuel; }
        }
        public List<string> ListeEpisodeVu
        {
            get { return this.listeEpisodeVu; }
        }

        #endregion propriétés

        #region méthodes
        public void AffichageImage(string fileName, string nom)
        {
            BitmapImage b = new BitmapImage();
            string[] temp = null;
            string[] temp2 = null;
            int m = 0;
            try
            {
                string[] readText = File.ReadAllLines(fileName);
                for (int i = 0; i < readText.Length; i++)
                {
                    temp = readText[i].Split('+');
                    if (nom.ToUpper() == temp[0].ToUpper())
                    {
                        temp2 = temp[2].Split(';');
                        Random r = new Random();
                        int a = r.Next(1, 3);
                        switch (a)
                        {
                            case 1:
                                MessageBox.Show(temp2[2]);
                                image.Source = LienPhoto(temp2[2]);
                                break;
                            case 2:
                                MessageBox.Show(temp2[3]);
                                image.Source = LienPhoto(temp2[3]);
                                break;
                        }
                        System.Threading.Thread.Sleep(15);
                        m++;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public BitmapImage LienPhoto(string nom)
        {
            string lien = @"C:\Users\lmage\OneDrive\Documents\Prepa2\Informatique\Projet 4\Projet\photo projet\" + nom + ".jpg";
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(lien);
            b.EndInit();
            return b;
        }
        private void Informations(string nom, string filename)
        {
            MessageBox.Show("info " + nom + filename);
            List<string> listeGenre = new List<string>();
            List<string> listeLien = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(filename);
                string ligne = "";
                string[] temp = null;
                string[] temp1 = null; // type
                string[] temp2 = null; // genre
                string[] temp4 = null; // durée
                string[] temp5 = null; // lien plateforme
                string[] temp6 = null; // année 
                string[] temp7 = null; // résumé
                while (sr.Peek() > 0)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split('+');
                    if (temp[0].ToLower() == nom.ToLower())
                    {
                        this.filmActuel = temp[0];
                        temp1 = temp[1].Split(';');
                        temp2 = temp[2].Split(';');
                        temp4 = temp[4].Split(':');
                        temp5 = temp[5].Split(';');
                        temp6 = temp[6].Split(':');
                        temp7 = temp[7].Split(';');

                        type.Text = temp[1][0].ToString().ToUpper() + temp[1].Substring(1).ToLower(); //ok
                        annee.Text = temp[6];
                        string[] resumebis = temp7[0].Split(' ');
                        for (int i = 0; i < resumebis.Length; i++)
                        {
                            resume.Content += resumebis[i] + " ";
                            if (i % 5 == 0 && i != 0) // aller à la lignes tous les 5 mots
                            {
                                resume.Content = resume.Content + "\n";
                            }
                        }
                        for (int i = 0; i < temp2.Length; i++)
                        {
                            listeGenre.Add(temp2[i][0].ToString().ToUpper() + temp2[i].Substring(1).ToLower());
                        }
                        treeGenre.ItemsSource = listeGenre;
                        duree.Text = temp4[0] + "h" + temp4[1] + "min";

                        for (int i = 0; i < temp5.Length; i++)
                        {
                            listeLien.Add(temp5[i]);
                        }
                        treeLien.ItemsSource = listeLien;
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
        } // remplissage du tree

        private bool ExistePseudo()
        {
            MessageBox.Show("existe pseudo" + this.utilisateurActuel);
            string filename = "SerieSuivie.txt";
            bool exist = false;
            try
            {
                StreamReader sr = new StreamReader(filename);
                string ligne = "";
                string[] temp = null;
                while (sr.Peek() > 0 && exist == false)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split('+');
                    if (temp[0].ToLower() == this.utilisateurActuel.ToLower())
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
        } // OK,  vérifie si la personne a déjà suivi une série ou pas

        public void AjouterFilm() //OK, ajouter une série pour un user
        {
            string nouveau = "";
            string ancien = "";
            string texte = File.ReadAllText(this.filename);
            bool existeDeja = false;

            if (ExistePseudo() == false)
            {
                StreamWriter sw = new StreamWriter("SerieSuivie.txt", true);
                sw.WriteLine("");
                sw.Write(this.utilisateurActuel + "+" + this.filmActuel + ";");
                sw.Close();
            }
            else
            {
                try
                {
                    StreamReader sr = new StreamReader(this.filename);
                    string ligne = "";
                    string[] temp = null;
                    string[] temp2 = null; // pour splité une 2ème fois

                    while (sr.Peek() > 0)
                    {
                        ligne = sr.ReadLine();
                        temp = ligne.Split('+');
                        if (temp[0].ToLower() == this.utilisateurActuel.ToLower())
                        {
                            for (int i = 1; i < temp.Length; i++)
                            {
                                temp2 = temp[i].Split(';');
                                if (temp2[0].ToLower() == this.filmActuel.ToLower())
                                {
                                    existeDeja = true;
                                }
                            }
                            if (existeDeja == false)
                            {
                                ancien = ligne;
                                nouveau = ligne + "+" + this.filmActuel + ";";
                            }
                            else
                            {
                                MessageBox.Show("existe déjà");
                            }
                        }
                    }
                    sr.Close();
                }
                catch (FileNotFoundException ee)
                {
                    MessageBox.Show(ee.Message);
                }
                catch (IOException ee)
                {
                    Console.WriteLine(ee.Message);
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                }

                if (texte.Contains(ancien) && existeDeja == false)
                {
                    texte = texte.Replace(ancien, nouveau);
                    File.WriteAllText(this.filename, texte);
                }
            }
        }



        #endregion méthodes
        private void Suivre_Click(object sender, RoutedEventArgs e)
        {
            AjouterFilm();
        }
    }
}
