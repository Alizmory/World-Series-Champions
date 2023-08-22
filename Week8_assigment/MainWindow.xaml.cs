using System;
using System.Collections.Generic;
using System.IO;//import to read from a file
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

namespace Week8_assigment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()//class constructor
        {
            InitializeComponent();
            string[] teams = readingFromFile();//array that take values from method readingFromFile
            lstTeams.ItemsSource = teams;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
           string[] winners = File.ReadAllLines("WorldSeriesWinners.txt");//save a array winners
           lstResult.ItemsSource = null;
           List<int> index = new List<int>();//save the index and is a int value
           String team = (string)lstTeams.SelectedItem;//team save the selected name in the listBox lsTeam
           int i = 0;//This is a iterator thah show to the position of the match
            while(i <winners.Length)//Avoid having exception out of index
            {
                if (team==winners[i])//when match team with winners!
                {
                    index.Add(i);//when there is a match, save the position in index through the Add method 
                }
                i++;//increment so no match to get to the positions
            }
            if(index.Count >0)//from position 1, 1903 is not added but 1904 because it was not played in that year
            {
               for(int z = 0; z <index.Count;z++)
               {
                    if(index[0]==0)//team win in 1903 add 1903
                    {
                        index[0] = 1902;//the number of years necessary to transform the value that Index continues in that position in its respective year is added
                    }
                    else //From position 1, 1904 is added because that year was not played to adjust it to the corresponding year
                    {
                        index[z] += 1903;
                    }
                  
               }

               for(int j = 0; j < index.Count; j++)//this for cycle is to find the data from the year 1994 because that year was not played
                {
                    if(index[j] >= 90)
                    {
                        index[j]++;
                    }
                }
                lstResult.ItemsSource = index;//lstResul es el list box que muestra los resultados
            }
        }
        private string[] readingFromFile()//returns a string array
        {
            string[] teams = File.ReadAllLines("Teams.txt");//a string array us declared that will take its values from the teams.txt file
            return teams;//return an array string with the lines of the read file, for this whis use the 'ReadAllLines' method      
        }
    }
}
