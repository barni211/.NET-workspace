using Labirynt.Model;
using Labirynt.Model.Classes;
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

        public void AddElements(int value)
        {
            MazeFactory factoryObject = new MazeFactory();
            figureList.Clear();
            if (value==1)
            {
                figureList = factoryObject.CreateMaze(@"E:\StandardFactory.txt");
            }
            else if(value==2)
            {
                figureList = factoryObject.CreateMaze(@"E:\MagicFactory.txt");
            }
            CreatePlayer();
            DrawMap();
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
                    AddElements(1);
                    break;
                case Keys.D2:
                    AddElements(2);
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
                if(item.GetType() == typeof(Room) || item.GetType()== typeof(RedRoom))
                {
                    if (playerLoc.X == item.StartPoint().X && playerLoc.Y == item.StartPoint().Y)
                    {
                        RoomFace r1 = (RoomFace)item;
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
