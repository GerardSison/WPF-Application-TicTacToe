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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        TileMark[] Gameboard;
        bool Gameend;
        bool PlayerTurn;

        // true = x ; false = o
        bool PlayerMark;

        public GameWindow(bool Mark)
        {
            InitializeComponent();
            PlayerMark = Mark;
            NewGame();
        }

        private void NewGame()
        {
            Gameboard = new TileMark[9];

            Gameend = false;
            PlayerTurn = true;

            foreach (int i in Gameboard)
                Gameboard[i] = TileMark.Blank;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var viewBox = (Viewbox)button.Content;
            var textBlock = (TextBlock)viewBox.Child;
            button.IsEnabled = false;

            var column = (Grid.GetColumn(button));
            var row = Grid.GetRow(button) - 1;
            var index = column + (row * 3);


            Gameboard[index] = PlayerTurn == true ? (PlayerMark == true ? TileMark.X : TileMark.O) : (PlayerMark == true ? TileMark.X : TileMark.O);

            textBlock.Text = PlayerTurn == true ? (PlayerMark == true ? "X" : "O") : (PlayerMark == true ? "X" : "O");

            CheckWinner();

            if (Gameend == false)
            {
                PlayerTurn = !PlayerTurn;
                PlayerMark = !PlayerMark;
                tbPlayerTurn.Text = PlayerTurn == true ? "Player 1 Turn" : "Player 2 Turn";
            }
            else
            {
                MessageBox.Show("gg");
            }


        }

        private void CheckWinner()
        {
            //horizontal

            if (Gameboard[0] != TileMark.Blank && Gameboard[0] == (Gameboard[0] & Gameboard[1] & Gameboard[2]))
                Gameend = true;

            else if (Gameboard[3] != TileMark.Blank && Gameboard[3] == (Gameboard[3] & Gameboard[4] & Gameboard[5]))
                Gameend = true;

            else if (Gameboard[6] != TileMark.Blank && Gameboard[6] == (Gameboard[6] & Gameboard[7] & Gameboard[8]))
                Gameend = true;

            //vertical

            else if (Gameboard[0] != TileMark.Blank && Gameboard[0] == (Gameboard[0] & Gameboard[3] & Gameboard[6]))
                Gameend = true;

            else if (Gameboard[1] != TileMark.Blank && Gameboard[1] == (Gameboard[1] & Gameboard[4] & Gameboard[7]))
                Gameend = true;

            else if (Gameboard[2] != TileMark.Blank && Gameboard[2] == (Gameboard[2] & Gameboard[5] & Gameboard[8]))
                Gameend = true;

            //Diagonal

            else if (Gameboard[0] != TileMark.Blank && Gameboard[0] == (Gameboard[0] & Gameboard[4] & Gameboard[8]))
                Gameend = true;

            else if (Gameboard[2] != TileMark.Blank && Gameboard[2] == (Gameboard[2] & Gameboard[4] & Gameboard[6]))
                Gameend = true;

            //Tie
        }

    }


    public enum TileMark
    {
        Blank,
        X,
        O
     
    }
}
