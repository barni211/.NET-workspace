using Labirynt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirynt
{
    public partial class frmLabirynt : Form
    {
        private int imageWidth;
        private int imageLength;
        private Graphics g;
        private List<Figure> figureList;
        private Pen pencil;
        private Pen playerPencil;
        private Player player;
        private bool isPlayerInRoom;
        private bool isMagicTypeOn;
        
        public frmLabirynt()
        {
            InitializeComponent();
            CreateMap();
            //AddElements();
            DrawMap();

        }

        public void DrawMap()
        {
            g.Clear(Color.Azure);
            foreach(Figure item in figureList)
            {
                if (item.GetType() == typeof(Player))
                {
                    item.Draw(playerPencil, g);
                }
                else
                {
                    item.Draw(pencil, g);
                }                          
            }
            imageView.Refresh();
        }

        public void CreateMap()
        {
            imageView.BackColor = Color.Azure;
            imageWidth = imageView.Width;
            imageLength = imageView.Height;
            imageView.Image = new Bitmap(imageLength, imageWidth);
            g = Graphics.FromImage(imageView.Image);
            figureList = new List<Figure>();
            pencil = new Pen(Color.Black);
            pencil.Width = 5;
            playerPencil = new Pen(Color.Red);
            playerPencil.Width = 8;
        }

        public void CreatePlayer()
        {
            Point x = new Point(100, 300);
            player = new Player(x);
            figureList.Add(player);
        }

        public void AddMagicElements()
        {

        }

        public void AddElements()
        {
            isMagicTypeOn = false;

            g.Clear(Color.Azure);
            figureList.Clear();

            Point x = new Point(100, 300);
            Point y = new Point(300, 300);
            Corritage coritOne = new Corritage(x, y);

            Point x1 = new Point(300, 300);
            Point y1 = new Point(300, 250);
            Corritage coritTwo = new Corritage(x1, y1);

            Point x2 = new Point(300, 250);
            Point y2 = new Point(350, 250);
            Corritage coritThree = new Corritage(x2, y2);

            Point x3 = new Point(350, 250);
            Point y3 = new Point(350, 100);
            Corritage coritFour = new Corritage(x3, y3);

            Point x4 = new Point(350, 100);
            Point y4 = new Point(100, 100);
            Corritage coritFive = new Corritage(x4, y4);

            Point x5 = new Point(100, 100);
            Point y5 = new Point(100, 150);
            Corritage coritSix = new Corritage(x5, y5);

            Point x6 = new Point(100, 150);
            Point y6 = new Point(300, 150);
            Corritage coritSeven = new Corritage(x6, y6);

            Point x7 = new Point(170, 100);
            Point y7 = new Point(170, 50);
            Corritage coritEight = new Corritage(x7, y7);

            Point x8 = new Point(170, 50);
            Point y8 = new Point(170, 20);
            Corritage coritNine = new Corritage(x8, y8);

            Point x9 = new Point(170, 20);
            Point y9 = new Point(40, 20);
            Corritage coritTen = new Corritage(x9, y9);

            Point x10 = new Point(40, 20);
            Point y10 = new Point(40, 300);
            Corritage coritEleven = new Corritage(x10, y10);

            Point x11 = new Point(40, 300);
            Point y11 = new Point(70, 300);
            Corritage coritTwelve = new Corritage(x11, y11);




            Room firstRoom = new Room(y6, 30, 30);
            Room secondRoom = new Room(y7, 70, 30);

            figureList.Add(coritOne);
            figureList.Add(coritTwo);
            figureList.Add(coritThree);
            figureList.Add(coritFour);
            figureList.Add(coritFive);
            figureList.Add(coritSix);
            figureList.Add(coritSeven);
            figureList.Add(coritEight);
            figureList.Add(coritNine);
            figureList.Add(coritTen);
            figureList.Add(coritEleven);
            figureList.Add(coritTwelve);
            figureList.Add(firstRoom);
            figureList.Add(secondRoom);
            CreatePlayer();

        }

        private void frmLabirynt_KeyDown(object sender, KeyEventArgs e)
        {
            Move motion;
            switch(e.KeyCode)
            {
                case Keys.Up:
                    motion = Model.Move.Up;
                    if (checkMove(motion))
                    {
                        player.MovePlayer(motion);
                    }
                    break;
                case Keys.Down:
                    motion = Model.Move.Down;
                    if (checkMove(motion))
                    {
                        player.MovePlayer(motion);
                    }
                    break;
                case Keys.Right:
                    motion = Model.Move.Right;
                    if (checkMove(motion))
                    {
                        player.MovePlayer(motion);
                    }
                    break;
                case Keys.Left:
                    motion = Model.Move.Left;
                    if (checkMove(motion))
                    {
                        player.MovePlayer(motion);
                    }
                    break;
                case Keys.Enter:
                    enterTheRoom();
                    break;
                case Keys.D1:
                    AddElements();
                    break;
                case Keys.D2:
                    AddMagicElements();
                    break;
                case Keys.M:
                    startMagicType();
                    break;               
            }
            DrawMap();     
        }

        public void enterTheRoom()
        {
            Point playerLoc = player.playerPosition();
            foreach (Figure item in figureList)
            {
                if(item.GetType() == typeof(Room))
                {
                    if (playerLoc.X == item.StartPoint().X && playerLoc.Y == item.StartPoint().Y)
                    {
                        Room r1 = (Room)item;
                        if(r1.playerInside())
                        {
                            r1.leavePlayer();
                            isPlayerInRoom = false;
                        }
                        else
                        {
                            r1.enterPlayer();
                            isPlayerInRoom = true;
                        }
                    }
                }
            }
        }

        public bool checkMove(Move motion)
        {
            if(isPlayerInRoom==true)
            {
                return false;
            }
            if(isMagicTypeOn)
            {
                return true;
            }

            Point playerPosition = player.playerPosition();
            foreach (Figure item in figureList)
            {
                if (item.GetType() == typeof(Player))
                {
                    continue;
                }
                switch(motion)
                {
                    case Model.Move.Up:
                        if ((item.StartPoint().X <= playerPosition.X && playerPosition.X <= item.EndPoint().X ) && (item.StartPoint().Y >= playerPosition.Y - 10 && playerPosition.Y - 10  >= item.EndPoint().Y))
                        {
                            return true;
                        }
                        if ((item.StartPoint().X <= playerPosition.X && playerPosition.X <= item.EndPoint().X) && (item.StartPoint().Y <= playerPosition.Y - 10 && playerPosition.Y - 10 <= item.EndPoint().Y))
                        {
                            return true;
                        }
                        break;
                    case Model.Move.Down:
                        if ((item.StartPoint().X <= playerPosition.X && playerPosition.X <= item.EndPoint().X) && (item.StartPoint().Y >= playerPosition.Y + 10 && playerPosition.Y + 10 >= item.EndPoint().Y))
                        {
                            return true;
                        }
                        if ((item.StartPoint().X <= playerPosition.X && playerPosition.X <= item.EndPoint().X) && (item.StartPoint().Y <= playerPosition.Y + 10 && playerPosition.Y + 10 <= item.EndPoint().Y))
                        {
                            return true;
                        }
                        break;
                    case Model.Move.Left:
                        if ((item.StartPoint().X <= playerPosition.X - 10 && playerPosition.X - 10 <= item.EndPoint().X) && (item.StartPoint().Y >= playerPosition.Y && playerPosition.Y >= item.EndPoint().Y))
                        {
                            return true;
                        }
                        if ((item.StartPoint().X >= playerPosition.X - 10 && playerPosition.X - 10 >= item.EndPoint().X) && (item.StartPoint().Y >= playerPosition.Y && playerPosition.Y >= item.EndPoint().Y))
                        {
                            return true;
                        }
                        break;
                    case Model.Move.Right:
                        if ((item.StartPoint().X <= playerPosition.X + 10 && playerPosition.X + 10 <= item.EndPoint().X) && (item.StartPoint().Y >= playerPosition.Y && playerPosition.Y >= item.EndPoint().Y))
                        {
                            return true;
                        }
                        if ((item.StartPoint().X >= playerPosition.X + 10 && playerPosition.X + 10 >= item.EndPoint().X) && (item.StartPoint().Y >= playerPosition.Y && playerPosition.Y >= item.EndPoint().Y))
                        {
                            return true;
                        }
                        break;
                }        
            }
            return false;
        }

        public void startMagicType()
        {
            if(isMagicTypeOn==false)
            {
                isMagicTypeOn = true;
            }
            else
            {
                isMagicTypeOn = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
