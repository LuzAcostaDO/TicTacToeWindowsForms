using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeProject
{
    public partial class SinglePlayer : Form
    {
        public SinglePlayer()
        {
            InitializeComponent();
            ResetBoard();
        }

        int user = 0;
        int AI = 0;
        List<Button> cells;
        Random random = new Random();

        private void playerMove(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Text = "X";
            cells.Remove(button);
            bool val = Check();
            if (!val) { AImove(); }
        }

        private void AImove()
        {
            if (cells.Count > 0)
            {
                int index = random.Next(cells.Count);
                cells[index].Text = "O";
                cells.RemoveAt(index);
                Check();
            }
        }

        private void ResetBoard()
        {
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Text = "";
                }
            }
            LoadBtn();
        }

        private void LoadBtn()
        {
            cells = new List<Button> { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };
        }

        public bool Check()
        {
            Boolean value = false;
            if (Button1.Text == "X" && Button2.Text == "X" && Button3.Text == "X"
               || Button4.Text == "X" && Button5.Text == "X" && Button6.Text == "X"
               || Button7.Text == "X" && Button9.Text == "X" && Button8.Text == "X"
               || Button1.Text == "X" && Button4.Text == "X" && Button7.Text == "X"
               || Button2.Text == "X" && Button5.Text == "X" && Button8.Text == "X"
               || Button3.Text == "X" && Button6.Text == "X" && Button9.Text == "X"
               || Button1.Text == "X" && Button5.Text == "X" && Button9.Text == "X"
               || Button3.Text == "X" && Button5.Text == "X" && Button7.Text == "X")
            {
                MessageBox.Show("Ganaste!");
                user++;
                label1.Text = "Usted - " + user;
                ResetBoard();
                value = true;
            }
            else if (Button1.Text == "O" && Button2.Text == "O" && Button3.Text == "O"
            || Button4.Text == "O" && Button5.Text == "O" && Button6.Text == "O"
            || Button7.Text == "O" && Button9.Text == "O" && Button8.Text == "O"
            || Button1.Text == "O" && Button4.Text == "O" && Button7.Text == "O"
            || Button2.Text == "O" && Button5.Text == "O" && Button8.Text == "O"
            || Button3.Text == "O" && Button6.Text == "O" && Button9.Text == "O"
            || Button1.Text == "O" && Button5.Text == "O" && Button9.Text == "O"
            || Button3.Text == "O" && Button5.Text == "O" && Button7.Text == "O")
            {
                MessageBox.Show("Ganó el AI");
                AI++;
                label2.Text = "AI - " + AI;
                ResetBoard();
                value = true;
            }
            else if (Button1.Text != "" && Button2.Text != "" && Button3.Text != ""
                && Button4.Text != "" && Button5.Text != "" && Button6.Text != ""
                && Button7.Text != "" && Button8.Text != "" && Button9.Text != "")
            {
                MessageBox.Show("Empataron");
                ResetBoard();
                value = true;
            }
            return value;
        }
    }
}
