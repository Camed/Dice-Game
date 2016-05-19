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

namespace Dice_Game
{
    /// <summary>
    /// Interaction logic for pvp.xaml
    /// </summary>
    public partial class pvp : Window
    {

        private Random r = new Random();

        int _totalPointsP1 = 0;
        int _totalPointsP2 = 0;

        public pvp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p1roll.IsEnabled = false;
            p2roll.IsEnabled = true;

            int randomValue = r.Next(1, 7);

            p1label.Content = randomValue.ToString();

            if(randomValue == 1)
            {
                _totalPointsP1 += 0;
                MessageBox.Show("Player 1 thrown 1! No points added!");
            }
            else
            {
                _totalPointsP1 += randomValue;
                if(_totalPointsP1 >= 100)
                {
                    MessageBox.Show("Player 1 won!");
                    this.Close();
                }
                else p1total.Content = string.Format("Player 1 total points: {0}", _totalPointsP1);
                
            }
            
        }

        private void p2roll_Click(object sender, RoutedEventArgs e)
        {
            p1roll.IsEnabled = true;
            p2roll.IsEnabled = false;

            int randomValue = r.Next(1, 7);

            p2label.Content = randomValue.ToString();

            if (randomValue == 1)
            {
                _totalPointsP2 += 0;
                MessageBox.Show("Player 2 thrown 1! No points added!");
            }
            else
            {
                _totalPointsP2 += randomValue;

                if(_totalPointsP2 >= 100)
                {
                    MessageBox.Show("Player2 won!");
                    this.Close();
                }
                else p2total.Content = string.Format("Player 2 total points: {0}", _totalPointsP2);

            }
        }

        
    }
}
