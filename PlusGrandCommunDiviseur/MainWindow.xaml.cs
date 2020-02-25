using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace PlusGrandCommunDiviseur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Faire le  calcul du PGCD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculer_PGCD_Click(object sender, RoutedEventArgs e)
        {
            int premierNombre;
            int secondNombre;
            int troisiemeNombre;
            int quatriemeNombre;
            int cinquiemeNombre;

            if (!LireEntierPositifZoneTexte(entier1, out premierNombre)) return;
            if (!LireEntierPositifZoneTexte(entier2, out secondNombre)) return;
            if (!LireEntierPositifZoneTexte(entier3, out troisiemeNombre)) return;
            if (!LireEntierPositifZoneTexte(entier4, out quatriemeNombre)) return;
            if (!LireEntierPositifZoneTexte(entier5, out cinquiemeNombre)) return;


            // Afficher les résultats 
            if (sender == trouverPGCD) // Euclide pour 2 entiers
            {
                // TODO Exercise 1, Task 3
                // Appeler la méthode TrouverPGCD  et afficher le résultat
            }


        }

        /// <summary>
        /// Lire un entier postif  à partir d'une zone de texte
        /// Affiche une boite de message avec les données si le texte ne peut pas être parsé.
        /// </summary>
        /// <param name="zoneTexte">Textzone de texte à lire</param>
        /// <param name="i">entier Postif  (paramètre out)</param>
        /// <returns>True si succès, false sinon</returns>
        private bool LireEntierPositifZoneTexte(TextBox zoneTexte, out int i)
        {
            i = -1;
            if (int.TryParse(zoneTexte.Text, out i))
            {
                if (i >= 0) return true;
            }
            MessageBox.Show("Ceci n'est Pas une valeur entière positive: " + zoneTexte.Text);
            return false;
        }

        private void TrouverPGCD_Click(object sender, RoutedEventArgs e)
        {
            long dureeEclide, dureeStein;
            if (sender == trouverPGCD)
            {
                resultatEuclide.Content = "Euclide:  " + AlgorithmePGCD.TrouverPGCD(Convert.ToInt32(entier1.Text), Convert.ToInt32(entier2.Text), out dureeEclide) + ", Durée (en ticks) : " + dureeEclide;
                resultatStein.Content = "Stein : " + AlgorithmePGCD.TrouverPGCDStein(Convert.ToInt32(entier1.Text), Convert.ToInt32(entier2.Text), out dureeStein) + ", Durée (en ticks) : " + dureeStein;
                DessinerGraphe(dureeEclide, dureeStein, chartOrientation.SelectedItem, euclidColor.SelectedItem, steinColor.SelectedItem);
                
            }
            /* else if (sender == trouverPGCD3)
             {
                 resultatEuclide.Content = "Euclide:  " + AlgorithmePGCD.TrouverPGCD3(Convert.ToInt32(entier1.Text), Convert.ToInt32(entier2.Text), Convert.ToInt32(entier3.Text));
                 entier1.Text = "";
                 entier2.Text = "";
                 entier3.Text = "";
             }
             else if (sender == trouverPGCD4) {
                 resultatEuclide.Content = "Euclide:  " + AlgorithmePGCD.TrouverPGCD4(Convert.ToInt32(entier1.Text), Convert.ToInt32(entier2.Text), Convert.ToInt32(entier3.Text),Convert.ToInt32(entier4.Text));
                 entier1.Text = "";
                 entier2.Text = "";
                 entier3.Text = "";
             }
             else if (sender == trouverPGCD5) {
                 resultatEuclide.Content = "Euclide:  " + AlgorithmePGCD.TrouverPGCD5(Convert.ToInt32(entier1.Text), Convert.ToInt32(entier2.Text), Convert.ToInt32(entier3.Text),Convert.ToInt32(entier4.Text), Convert.ToInt32(entier5.Text));
                 entier1.Text = "";
                 entier2.Text = "";
                 entier3.Text = "";
             }*/
            else { }

        }

        private void DessinerGraphe(long dureeEclide, long dureeStein, object selectedItem1, object selectedItem2, object selectedItem3)
        {
           
        }

       
    }
}
