using Labirynt.Model.Classes.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model
{
    public class Player : Figure
    {
        private Point location;
        private List<Key> keys;
        public Player(Point p)
        {
            this.location = p;
            keys = new List<Key>();
        }

        public void Draw(Pen p, Graphics g)
        {
            g.DrawEllipse(p, location.X, location.Y, 3,3);
        }

        public Point EndPoint()
        {
            throw new NotImplementedException();
        }

        public void MovePlayer(Move motion)
        {
            switch(motion)
            {
                case Move.Up:
                    location.Y -= 10;
                    break;
                case Move.Down:
                    location.Y += 10;
                    break;
                case Move.Right:
                    location.X += 10;
                    break;
                case Move.Left:
                    location.X -= 10;
                    break;
            }
        }

        public Point playerPosition()
        {
            return this.location;
        }

        public Point StartPoint()
        {
            return this.location;// throw new NotImplementedException();
        }

        public void GetKey(Key k)
        {
            keys.Add(k);          
        }

        public int KeyCounter()
        {
            return keys.Count();
        }

    


    }
}
