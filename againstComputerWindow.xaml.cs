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
using System.Threading;
namespace Dice_Game
{

    public partial class againstComputerWindow : Window
    {
        private Random r = new Random();

        public againstComputerWindow()
        {
            InitializeComponent();
        }

            
        int _totalUserPoints     = 0;
        int _totalComputerPoints = 0;   


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int randomValue = r.Next(1, 7);

            if(randomValue == 1)
            {
                _totalUserPoints += 0;
                throw_value_user.Content = "1";
                MessageBox.Show("You've thrown 1! No points!");
                ComputerTurn();
            }
            else
            {
                _totalUserPoints += randomValue;
                throw_value_user.Content = randomValue.ToString();
                new Thread(new ThreadStart(() => Thread.Sleep(1000))).Start();
                if (_totalUserPoints >= 100)
                { 
                    MessageBox.Show("You won!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Computer's turn");
                    userPoints.Content = _totalUserPoints.ToString();
                    ComputerTurn();
                }
                
            }

        }


        public void ComputerTurn()
        {

          int randomValue = r.Next(1, 7);

          if(randomValue == 1)
          {
                throw_value_computer.Content = "1";
          }
          else
          {
                _totalComputerPoints += randomValue;
                throw_value_computer.Content = randomValue.ToString();
                computerPoints.Content = _totalComputerPoints.ToString();
                new Thread(new ThreadStart(() => Thread.Sleep(1000))).Start();     // wait one second until next throw and don't block GUI
                if (_totalComputerPoints >= 100) { MessageBox.Show("Computer won!"); this.Close(); }
          }
        }

    }
}
