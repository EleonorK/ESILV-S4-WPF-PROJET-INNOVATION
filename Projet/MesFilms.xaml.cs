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
    /// Logique d'interaction pour MesFilms.xaml
    /// </summary>
    public partial class MesFilms : Window
    {
        private string utilisateurActuel;
        private string phrase;
        public MesFilms(string nom)
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.utilisateurActuel = nom;
            List<string> listeSeries = ListeSeries();
            string[] tab = RecupNomPhoto(0, "ContenuTotal.txt", listeSeries.Count, listeSeries);
            string filename = "SerieSuivie.txt";
            string[] temp = File.ReadAllLines(filename);


            //création de la grille
            int nbLignes = 0;
            if (temp.Length % 2 == 0)
            {
                nbLignes = temp.Length / 2;
            }
            else
            {
                nbLignes = (temp.Length + 1) / 2;
            }

            int nbColonnes = 2;

            //création des lignes de notre grille
            for (int i = 0; i < nbLignes; i++)
            {
                RowDefinition ligne = new RowDefinition(); // créer ligne
                //associer la ligne à la grille
                grille.RowDefinitions.Add(ligne);
            }

            //créer les colonnes de notre grille
            for (int c = 0; c < nbColonnes; c++)
            {
                ColumnDefinition colonne = new ColumnDefinition();
                //associer la colonne à la grille
                grille.ColumnDefinitions.Add(colonne);
            }
            grille.Background = null;

            BoutonSerie cg = new BoutonSerie();
            int x = 0;
            //jusqu'ici on a une grille avec 10 cases
            for (int i = 0; i < nbLignes; i++)
            {
                for (int c = 0; c < nbColonnes; c++)
                {
                    if (x < tab.Length)
                    {
                        cg = new BoutonSerie(tab[x], this);
                        var brush = new ImageBrush();
                        //MessageBox.Show(Convert.ToString(cg.Content));
                        brush.ImageSource = LienPhoto(Convert.ToString(cg.Content));
                        cg.Background = brush;
                        cg.Foreground = null;
                        cg.Height = 200;
                        cg.Width = 200;

                        x++;
                        //intégrer le bouton au niveau de la grille
                        Grid.SetRow(cg, i);
                        Grid.SetColumn(cg, c);
                        grille.Children.Add(cg);
                    }
                }
            }
        }

        public void MiseAJour(BoutonSerie b)
        {
            this.phrase = ContenuClique("ContenuTotal.txt", Convert.ToString(b.Content));
            MessageBox.Show(this.utilisateurActuel);
            InfoFilm f = new InfoFilm(this.phrase, this.utilisateurActuel);
            f.Show();
        }
        public string ContenuClique(string fileName, string n)
        {
            string[] tab = new string[2];
            string ph = null;
            try
            {
                string[] temp = null, temp2 = null;
                string[] readText = File.ReadAllLines(fileName);
                for (int i = 0; i < readText.Length; i++)
                {
                    temp = readText[i].Split('+');
                    temp2 = temp[2].Split(';');
                    if (temp2[0] == n || temp2[1] == n)
                    {
                        ph = temp[0];
                    }
                } // a
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            return ph;
        }
        public List<string> ListeSeries()
        {
            List<string> l = new List<string>(); // liste qui va contenir toutes les séries de la personne
            try
            {
                StreamReader sr = new StreamReader("SerieSuivie.txt");
                string ligne = "";
                string[] temp = null;
                string[] temp2 = null;

                while (sr.Peek() > 0)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split('+');
                    if (temp[0].ToLower() == this.utilisateurActuel.ToLower()) // == this.utilisateurActuel
                    {
                        for (int i = 1; i < temp.Length; i++)
                        {
                            temp2 = temp[i].Split(';');
                            l.Add(temp2[0]);
                            MessageBox.Show(temp2[0]);
                        }
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException ee)
            {
                Console.WriteLine(ee.Message);
            }
            catch (IOException ee)
            {
                Console.WriteLine(ee.Message);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            //MessageBox.Show(l[0] + " " + l[1]);
            return l;
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

        public string[] RecupNomPhoto(int n, string filename, int taille, List<string> listeSerie)
        {
            string[] tab = new string[taille];
            string[] temp = null;
            string[] temp2 = null;
            int m = 0;
            try
            {
                string[] readText = File.ReadAllLines(filename);
                if (n == 0) // pour série
                {
                    for (int i = 0; i < readText.Length; i++)
                    {
                        temp = readText[i].Split('+');
                        if (listeSerie.Contains(temp[0]))
                        {
                            //MessageBox.Show(temp[0]);
                            temp2 = temp[2].Split(';');
                            Random r = new Random();
                            int a = r.Next(1, 3);
                            switch (a)
                            {
                                case 1:
                                    tab[m] = temp2[0];
                                    break;
                                case 2:
                                    tab[m] = temp2[1];
                                    break;
                            }
                            System.Threading.Thread.Sleep(15);
                            m++;
                        }
                    }
                }
                else // pour film
                {

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return tab;
        }
    }
}
