using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Game
{
    public partial class Form1 : Form
    {

        GameBoard gb;

        public Form1()
        {
            InitializeComponent();

            gb = new GameBoard();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {  
         gb.draw_board(this);
         
        }

        private void Form1_Move(object sender, EventArgs e)
        {
      
        }

        private void Form1_MouseMove(object sender,MouseEventArgs e)
        { 

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Sprite selected = gb.get_selected(e.X, e.Y);

            Sprite arriba_izquierda = gb.get_selected(e.X, e.Y + 2);
            Sprite arriba_derecha = gb.get_selected(e.X + 1, e.Y + 2);

            Sprite abajo_izquierda = gb.get_selected(e.X - 1, e.Y - 2);
            Sprite abajo_derecha = gb.get_selected(e.X - 1, e.Y - 2);

            Sprite izquierda_arriba = gb.get_selected(e.X - 2, e.Y + 1);
            Sprite izquierda_abajo = gb.get_selected(e.X - 2, e.Y - 1);

            Sprite derecha_arriba = gb.get_selected(e.X + 2, e.Y + 1);
            Sprite derecha_abajo = gb.get_selected(e.X + 2, e.Y - 1);


            if (selected == null || selected.current == Sprite.Type.marked)
            {
              this.label1.Text = "Invalido";
              this.label4.Text = "Intente otro";
            }

   if (selected.current==Sprite.Type.black||selected.current==Sprite.Type.white)
            {
                this.label1.Text = selected.i.ToString();
                this.label4.Text = selected.j.ToString();
                gb.update();
                gb.draw_board(this);
                selected.current = selected.anterior;
            } 
               
       }
          
             private void label4_Click(object sender, EventArgs e)
        {

        }

    }
    }

