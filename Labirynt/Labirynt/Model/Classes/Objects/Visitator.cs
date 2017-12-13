using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirynt.Model.Classes.Objects
{
    public class Visitator
    {
        public static string Visit(Player p, Key k, ref bool isPlayerInRoom, List<Figure> figureList)
        {
            p.GetKey(k);
            figureList.Remove(k);
            MessageBox.Show("Znalazłeś klucz! Twoja liczba kluczy to: " + p.KeyCounter());
            return "";
        }

        public static void Visit(Player p, Corritage k, ref bool isPlayerInRoom, List<Figure> figureList)
        {
            
        }

        public static string Visit(Player p, YellowCorritage k, ref bool isPlayerInRoom, List<Figure> figureList)
        {
            return "";
        }

        public static string Visit(Player p, RedRoom r, ref bool isPlayerInRoom, List<Figure> figureList)
        {
            dynamic x = r;
            LeaveOrEnterRoom(x, ref isPlayerInRoom);
            return "";
        }

        public static string Visit(Player p, Room r, ref bool isPlayerInRoom, List<Figure> figureList)
        {
            dynamic x = r;
            LeaveOrEnterRoom(x, ref isPlayerInRoom);
            return "";
        }

        public static string Visit(Player p, MagicRoom r, ref bool isPlayerInRoom, List<Figure> figureList)
        {

            dynamic x = r;
            //LeaveOrEnterRoom(x, ref isPlayerInRoom);
            SpellForm form = new SpellForm();
            form.ShowDialog();
            bool value = form.ReturnResult();
            return "ColorMap";
        }


        private static void LeaveOrEnterRoom(StandardRoom room, ref bool isPlayerInRoom)
        {

            if (isPlayerInRoom == false)
            {
                room.enterPlayer();
                isPlayerInRoom = true;
            }
            else
            {
                room.leavePlayer();
                isPlayerInRoom = false;
            }
        }

        private static void LeaveOrEnterRoom(RedRoom room, ref bool isPlayerInRoom)
        {
            if (isPlayerInRoom == false)
            {
                room.enterPlayer();
                isPlayerInRoom = true;
            }
            else
            {
                room.leavePlayer();
                isPlayerInRoom = false;
            }
        }
    }
}
