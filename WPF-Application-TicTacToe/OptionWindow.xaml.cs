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

namespace WPF_Application_TicTacToe
{
    /// <summary>
    /// Interaction logic for OptionWindow.xaml
    /// </summary>
    public partial class OptionWindow : Window
    {
        public OptionWindow()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            bool Mark = cbPlayer1.Text == "X" ? true : false;
            GameWindow gameWindow = new GameWindow(Mark);
            gameWindow.Show();
            this.Close();
        }


        private void ComboBoxPlayer1_DropDownClosed(object sender, EventArgs e)
        {
            cbPlayer2.Text = cbPlayer1.Text == "X" ? "O" : "X";
        }

        private void ComboBoxPlayer2_DropDownClosed(object sender, EventArgs e)
        {
            cbPlayer1.Text = cbPlayer2.Text == "X" ? "O" : "X";
        }
    }
}
