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
    /// Logique d'interaction pour ListCheck.xaml
    /// </summary>
    public partial class ListCheck : Window
    {
        string phrase;
        private string utilisateurActuel;
        private string serieActuelle;
        private List<CheckBox> liste; // liste qui contient TOUS les épisodes de chaque saison de la série
        private List<CheckBox> listeEpisodeVu;
        private string fileName;

        private string fichier = "SerieSuivie.txt";
        public string Phrase { get { return this.phrase; } }
        public string UtilisateurActuel { get { return this.utilisateurActuel; } }
        public string SerieActuelle { get { return this.serieActuelle; } }
        public List<CheckBox> Liste { get { return this.liste; } }
        public ListCheck(string nom, string type, string utilisateuractuel)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.utilisateurActuel = utilisateuractuel;
            this.serieActuelle = nom;
            //AfficherPhoto(nom, type);
            CreationComboBox(nom, type);

        }
        #region Affichage
        public void CreationComboBox(string nom, string type)
        {
            int nbLignes = 0, nbColones = 0, n = 0, a = 0, x = 0;
            List<CheckBox> nb = new List<CheckBox>();
            List<CheckBox> aff = new List<CheckBox>();
            this.fileName = type[0].ToString().ToUpper() + type.Substring(1).ToLower();
            this.fileName += ".txt";
            MessageBox.Show("le nom fichier "+ this.fileName);
            int[] tab = PriseDansFichier(this.fileName, nom);
            n = tab.Length;
            while (n % 2 != 0) { n++; }

            //List<CheckBox> contenu = CreationListe(tab.Length, 0, 1); 

            List<string> contenu = new List<string>();
            for (int i = 0; i < tab.Length; i++)
            {
                contenu.Add("Saison " + (i + 1));
            }

            //création de la grille
            if (tab.Length == 1) { nbLignes = 1; nbColones = 1; }
            else
            {
                a = n / 2;
                nbLignes = a;
                nbColones = 2;
            }
            MessageBox.Show("lignes : " + nbLignes + " colonnes :" + nbColones);
            //creation des lignes et colonnes dans notre grille
            for (int i = 0; i < nbLignes; i++)
            {
                RowDefinition ligne = new RowDefinition();
                grille.RowDefinitions.Add(ligne);
            }
            for (int i = 0; i < nbColones; i++)
            {
                ColumnDefinition colonne = new ColumnDefinition();
                grille.ColumnDefinitions.Add(colonne);
            }
            
            //grille de n cases
            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColones; j++)
                {
                    if (x < contenu.Count)
                    {
                        ListGraphique eg = new ListGraphique(contenu[x], this);
                        //CheckSaison cs = new CheckSaison(contenu.Count + 1);
                        //FAIRE LA CHECKBOX DANS LE COMBOBOX PRINCIPAL
                        eg.Height = 30;
                        nb = CreationListe(tab[x], x, 0);
                        eg.ItemsSource = nb;
                        eg.IsEditable = true;
                        
                        //suite 
                        x++;
                        Grid.SetRow(eg, i);//positionnement de la combo sur la bonne ligne
                        Grid.SetColumn(eg, j);//positionnement de la combo sur la colonne
                        grille.Children.Add(eg);//ajouter la Combo sur la grille

                        /*Grid.SetRow(cs, i);//positionnement de la Check sur la bonne ligne
                        Grid.SetColumn(cs, j);//positionnement de la Check sur la colonne
                        grille.Children.Add(cs);//ajouter la Check sur la grille*/
                    }
                }
            }

        }
        #endregion
        #region methodes
        /// <summary>
        /// prise du nombre d'épisodes par saison ( et du nombre de saison)
        /// </summary>
        /// <param name="fileName"></param> nom fichier
        /// <param name="nom"></param> nom du contenu
        /// <returns></returns> un tableau qui contient le nb dépisodes par saisons
        public int[] PriseDansFichier(string fileName, string nom)
        {
            int[] tab = null;
            string ph = null;
            try
            {
                string ligne = "";
                string[] temp = null;
                StreamReader sr = new StreamReader(fileName);
                while (sr.EndOfStream == false)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split('+');
                    if (nom.ToUpper() == temp[0])
                    {
                        ph = temp[5];
                    }
                }
                string[] temp1 = ph.Split(';');
                tab = new int[temp1.Length];
                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = Convert.ToInt32(temp1[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tab;
        }
        public List<CheckBox> CreationListe(int n, int x, int autre) // IMPORTANT
        {
            GenreGraphique gg = null;
            //List<CheckBox> liste = new List<CheckBox>();
            this.liste = new List<CheckBox>();
            if (autre == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    gg = new GenreGraphique("Ep" + (i + 1) + " S" + (x + 1), this);
                    gg.FontFamily = new FontFamily("Javanese");
                    this.liste.Add(gg);
                }
                Cocher();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    gg = new GenreGraphique("Saison " + (i + 1), this);
                    this.liste.Add(gg);
                }
            }
            return this.liste;
        }
        public string MiseAJourEpi(GenreGraphique g)
        {
            string nouveau = "";
            string ancien = "";
            string ancienneligne = "";
            string nouvelleligne = "";
            string texte = File.ReadAllText(fichier);
            bool trouve = false;

            if (ExistePseudo() == false)
            {
                StreamWriter sw = new StreamWriter("SerieSuivie.txt", true);
                sw.Write("\n" + this.utilisateurActuel + "+" + this.serieActuelle + ";");
                sw.Close();
                AjouterSerie();
            }
            else
            {
                try
                {
                    StreamReader sr = new StreamReader(this.fichier);
                    string ligne = "";
                    string[] temp = null;
                    string[] temp2 = null; // pour splité une 2ème fois

                    while (sr.Peek() > 0)
                    {
                        ligne = sr.ReadLine();
                        temp = ligne.Split('+');
                        if (temp[0].ToLower() == this.utilisateurActuel.ToLower())
                        {
                            ancienneligne = ligne;
                            for (int i = 1; i < temp.Length; i++)
                            {
                                temp2 = temp[i].Split(';');
                                if (temp2[0].ToLower() == this.serieActuelle.ToLower())
                                {
                                    if (ExisteEpisode(g.ValeurGenre) == true)
                                    {
                                        MessageBox.Show("valeur a enlever : " + g.ValeurGenre);
                                        for(int k = 1; k < temp2[i].Length; k++)
                                        {
                                            if(temp2[k].ToLower() == g.ValeurGenre.ToLower())
                                            {
                                                trouve = true;
                                                ancien = temp2[k];
                                                nouveau = "";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        trouve = true;
                                        ancien = temp2[0];
                                        nouveau = ancien + ";"+g.ValeurGenre;
                                    }                                    
                                }
                            }

                            if (ligne.Contains(ancien))
                            {
                                nouvelleligne = ligne.Replace(ancien, nouveau);
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

                if (texte.Contains(ancienneligne) && trouve == true)
                {
                    texte = texte.Replace(ancienneligne, nouvelleligne);
                    try
                    {
                        File.WriteAllText("SerieSuivie.txt", texte);
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return this.phrase;
        }
        public bool ExisteEpisode(string epiCheck)
        {
            MessageBox.Show("rentré dans ExisteEpisode");
            bool exist = false;
            try
            {
                StreamReader sr = new StreamReader(fichier);
                MessageBox.Show(fichier);
                string ligne = "";
                string[] temp = null;
                string[] temp2 = null;                
                while (sr.Peek() > 0)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split('+');
                    if (temp[0].ToLower() == this.utilisateurActuel.ToLower())
                    {
                        for (int i = 1; i < temp.Length; i++)
                        {
                            temp2 = temp[i].Split(';');
                            if (temp2[0].ToLower() == this.serieActuelle.ToLower())
                            {
                                for (int j = 0; j < temp2.Length; j++)
                                {
                                    if (temp2[j].ToLower()==epiCheck.ToLower())
                                    {
                                        MessageBox.Show("OKKKKK LOUUURD");
                                        exist = true;
                                    }
                                }                                                             
                            }
                        }
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
            /*
            int k = 0;
            string[] readText = File.ReadAllLines("SerieSuivie.txt"), temp = null, temp1 = null;
            MessageBox.Show("valeur de la box : " + epiCheck);
            for (int i = 0; i < readText.Length; i++)
            {                
                temp = readText[i].Split('+');
                if (this.utilisateurActuel.ToUpper() == temp[0].ToUpper())
                {
                    MessageBox.Show("nom : " + temp[0]);
                    MessageBox.Show("this s a : " + this.serieActuelle);
                    temp1 = temp[i].Split(';');
                    for(int l = 0; l < temp1.Length;l++)
                    {
                        MessageBox.Show("nom serie : " + temp1[l]);
                        if (temp1[l].ToUpper() == this.SerieActuelle.ToUpper())
                        {
                            
                            for (int j = 1; j < temp1.Length; j++)
                            {
                                if (temp1[j] == epiCheck) { k++; }
                                MessageBox.Show("temp1 j : " + temp1[j]);
                            }
                        }

                    }
                    
                }
                
            }
            if(k != 0) { verif = true; MessageBox.Show("il existe"); }
            return verif;
            */
            return exist;
        }
        public string ReEcriture(string n)
        {
            Char[] b = new char[n.Length];
            string p1 = null, ph = null;
            for (int i = 0; i < n.Length; i++)
            {
                if (i == n.Length - 1) { b[i] = '+'; }
                else { b[i] = n[i]; }
                p1 += b[i];
            }
            ph = p1;
            if (p1.Contains('0'))
            {
                string p2 = null;
                p2 = p1;
                Char[] c = new char[p2.Length];
                p2 = null;
                for (int i = 0; i < n.Length; i++)
                {
                    if (i != n.Length - 2 && i != n.Length - 3)
                    {
                        if (i == n.Length - 1) { b[i] = '+'; }
                        else { b[i] = n[i]; }
                        p2 += b[i];
                    }
                }
                ph = p2;
            }
            return ph;
        }

        #endregion


        #region  adi
        public List<string> CocherCheckBox2() // mettre une liste en paramètres contenant toutes les cases cochées
        {
            List<string> listeEpisodeVu = new List<string>();
            try
            {
                StreamReader sr = new StreamReader("SerieSuivie.txt");
                string ligne = "";
                string[] temp = null;
                string[] temp2 = null; // pour splité une 2ème fois

                while (sr.Peek() > 0)
                {
                    ligne = sr.ReadLine();
                    temp = ligne.Split('+');
                    if (temp[0].ToLower() == this.utilisateurActuel.ToLower()) // vérif nomUtilisateur
                    {
                        for (int i = 1; i < temp.Length; i++)
                        {
                            temp2 = temp[i].Split(';');
                            if (temp2[0].ToLower() == this.serieActuelle.ToLower()) // vérif de la bonne série
                            {
                                for (int index = 1; index < temp2.Length; index++)
                                {
                                    listeEpisodeVu.Add(temp2[index]); // ajout des épisodes en fonction de la série                                   
                                }
                            }
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
            return listeEpisodeVu;
        }
        public void Cocher()
        {
            //InformationsSerie i = new InformationsSerie(this.serieActuelle, this.utilisateurActuel);
            //List<string> listeEpisodeVu = i.ListeEpisodeVu;
            List<string> listeEpisodeVu = CocherCheckBox2();
            for (int index = 0; index < this.liste.Count; index++)
            {
                for (int j = 0; j < listeEpisodeVu.Count; j++)
                {
                    if (listeEpisodeVu[j] == this.liste[index].Content.ToString())
                    {
                        this.liste[index].IsChecked = true;
                    }
                }
            }
        }


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

        public void AjouterSerie() //OK, ajouter une série pour un user
        {
            string nouveau = "";
            string ancien = "";
            string texte = File.ReadAllText(this.fileName);
            bool existeDeja = false;

            if (ExistePseudo() == false)
            {
                StreamWriter sw = new StreamWriter("SerieSuivie.txt", true);
                sw.WriteLine("");
                sw.Write(this.utilisateurActuel + "+" + this.serieActuelle);
                sw.Close();
            }
            else
            {
                try
                {
                    StreamReader sr = new StreamReader(this.fileName);
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
                                if (temp2[0].ToLower() == this.serieActuelle.ToLower())
                                {
                                    existeDeja = true;
                                }
                            }
                            if (existeDeja == false)
                            {
                                ancien = ligne;
                                nouveau = ligne + "+" + this.serieActuelle + ";";
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
                    File.WriteAllText(this.fileName, texte);
                }
            }
        }

        /*
        public void AjouterEpisodeVus(string phrase, string nom, string serie) // mettre une liste en paramètres contenant toutes les cases cochées
        {
            // nom = utilisateurActuel
            // serie= serieActuel
            MessageBox.Show("phrassse" + phrase);
            if (nom != null)
            {
                this.utilisateurActuel = nom;
                this.serieActuelle = serie;
            }
            string nouveau = "";
            string ancien = "";
            string ancienneligne = "";
            string nouvelleligne = "";
            string texte = File.ReadAllText(this.fileName);
            bool trouve = false;

            if (ExistePseudo() == false)
            {
                StreamWriter sw = new StreamWriter("SerieSuivie.txt", true);
                sw.Write("\n" + this.utilisateurActuel + "+" + this.serieActuelle + ";");
                sw.Close();
                AjouterSerie();
            }
            else
            {
                try
                {
                    StreamReader sr = new StreamReader(this.fileName);
                    string ligne = "";
                    string[] temp = null;
                    string[] temp2 = null; // pour splité une 2ème fois

                    while (sr.Peek() > 0)
                    {
                        ligne = sr.ReadLine();
                        temp = ligne.Split('+');
                        if (temp[0].ToLower() == this.utilisateurActuel.ToLower())
                        {
                            ancienneligne = ligne;
                            for (int i = 1; i < temp.Length; i++)
                            {
                                temp2 = temp[i].Split(';');
                                if (temp2[0].ToLower() == this.serieActuelle.ToLower())
                                {
                                    trouve = true;
                                    ancien = temp2[0];
                                    nouveau = ancien + ";" + phrase;
                                }
                            }

                            if (ligne.Contains(ancien))
                            {
                                nouvelleligne = ligne.Replace(ancien, nouveau);
                            }
                            if (trouve == false)
                            {
                                MessageBox.Show("épisode déjà vu !");
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

                if (texte.Contains(ancienneligne))
                {
                    texte = texte.Replace(ancienneligne, nouvelleligne);
                    try
                    {
                        File.WriteAllText("SerieSuivie.txt", texte);
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        */

        #endregion 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.phrase != null)
            {
                //string h = ReEcriture(this.phrase);
                
                //this.phrase = h;
                MessageBox.Show(this.phrase);
                /*
                InformationsSerie i = new InformationsSerie(this.serieActuelle, "");
                i.AjouterEpisodeVus(this.phrase, this.utilisateurActuel, this.serieActuelle);
                */
                //Cocher();
            }
        }
    }
}
