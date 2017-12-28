using Labirynt.Model.Classes.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model
{
    public class RedRoom :Room, Figure, RoomFace
    {
        private Point location;
        private int width;
        private int length;
        private bool isPlayerInRoom = false;

        public RedRoom(Point p, int width, int length)
        {
            this.location = p;
            this.width = width;
            this.length = length;
        }

        public void Draw(Pen p, Graphics g)
        {
            if (isPlayerInRoom == true)
            {
                g.FillRectangle(new SolidBrush(Color.Black), location.X, location.Y, width, length);
            }
            p.Color = Color.Red;
            g.DrawRectangle(p, location.X, location.Y, width, length);
            p.Color = Color.Black;
        }

        public Point StartPoint()
        {
            return location;
        }

        public Point EndPoint()
        {
            return location;
        }

        public void enterPlayer()
        {
            this.isPlayerInRoom = true;
        }

        public void leavePlayer()
        {
            this.isPlayerInRoom = false;
        }

        public bool playerInside()
        {
            return isPlayerInRoom;
        }
    }
}
