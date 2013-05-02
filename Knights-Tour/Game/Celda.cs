using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class GameBoard
    {
        public List<List<Sprite>> board;
        public enum State { puting, updating, gameover }
        public GameBoard.State current_state;

        private Sprite selected;
        public Sprite anterior;

        public Sprite next;

        public GameBoard()
        {
            board = new List<List<Sprite>>();
            initialize_board();
            current_state = State.puting;
         }

        public void initialize_board()
        {
          
          int contador = 2;
          
            try
            {

             for (int i = 0; i < 8; i++)
                {
                 List<Sprite> sublist = new List<Sprite>(); 
                 

                   
                 contador++;

                 for (int j = 0; j < 8; j++)
                    {
                        if (contador % 2 == 0)
                        { 
                            sublist.Add(new Sprite(i, j, Sprite.Type.white)) ; 
                        }

                        if (contador % 2 != 0)
                        { 
                            sublist.Add(new Sprite(i, j, Sprite.Type.black)); 
                        }
                        contador++;
                       
                      }
                 
                 board.Add(sublist); 
                 }
            
       
            
            }
          
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
  
        
      
        public void draw_board(Form f)
        {
        
          foreach (var sublist in board)
          { 
              
               foreach (Sprite value in sublist)
                {
                  value.Draw(f);
                }

            }
        }
  
        
        
        
      
      
        public Sprite get_selected(int x, int y)
        {
            foreach (var sublist in board)
            {
                foreach (Sprite value in sublist)
                {
                    if (value.overlaps(x, y))
                    {
                        this.selected = (Sprite)value;
                        return value;
                    }
                }

            }

            return null;
        }

       
      public void update()
        {   
            List<Sprite> knight = new List<Sprite>();
            List<Sprite> marcado = new List<Sprite>();
            
       
           
            
            int i = selected.i;
            int j = selected.j;



            if (board[i][j].current==Sprite.Type.white||board[i][j].current==Sprite.Type.black)
            
          
            {   
              marcado.Add(board[i][j]);
              knight.Add(board[i][j]); 
            }

            

            foreach (Sprite val in knight)
            {
                val.current = Sprite.Type.knight;
            }

            foreach (Sprite val in marcado)
            {
                if (board[i][j].current == Sprite.Type.knight)
                    val.anterior = Sprite.Type.marked;
            }
        
        }
    }
}

  public abstract class GameObject
    {
     //   public abstract void Update( );
        public abstract void Draw(Form F);
    }

    public class Sprite: GameObject
    {
        public enum Type {knight,black,white,marked}
        public int size = 64;
        public int i, j;
        public int x;
        public int y;

        public Sprite.Type current;
        public Sprite.Type anterior;


        public List<Bitmap> _frames = new List<Bitmap>();

        public Sprite(int i, int j, Sprite.Type current)
        {

            this.current = current;
            this.i = i;
            this.j = j;
            x = i * size;
            y = j * size;
            _frames.Add(new Bitmap(@"F:\Knights-Tour\Game\images\horse.png"));
            _frames.Add(new Bitmap(@"F:\Knights-Tour\Game\images\marbleb.png"));
            _frames.Add(new Bitmap(@"F:\Knights-Tour\Game\images\marblew.png"));
            _frames.Add(new Bitmap(@"F:\Knights-Tour\Game\images\marked.png"));

        }

        public Sprite(double i,double j,Sprite.Type anterior)
        {
            this.anterior = anterior;
 
            var x = i * size;
            var y = j * size;
           
            _frames.Add(new Bitmap(@"F:\Knights-Tour\Game\images\horse.png"));
            _frames.Add(new Bitmap(@"F:\Knights-Tour\Game\images\marked.png"));

        } 

 public override void Draw(Form f)
        {
            Graphics graphics = f.CreateGraphics();
            try
                {
                    graphics.DrawImage( _frames[(int) this.current], size * i, size * j, size, size);
                }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message + ex.Source);
            }
        }

        public bool overlaps(int x, int y)
        {
            return this.x < x && this.x + size > x && this.y < y && this.y + size > y;

        }
    }

