using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.UI
{
    public static class UIManager
    {
        private static Image[] heartImages = new Image[3];

        public static void SetHearts()
        {
            switch (GameWindow.player.Health)
            {
                case 0:
                    heartImages[0] = Properties.Resources.ui_heart_empty;
                    heartImages[1] = Properties.Resources.ui_heart_empty;
                    heartImages[2] = Properties.Resources.ui_heart_empty;
                    break;
                case 1:
                    heartImages[0] = Properties.Resources.ui_heart_half;
                    heartImages[1] = Properties.Resources.ui_heart_empty;
                    heartImages[2] = Properties.Resources.ui_heart_empty;
                    break;
                case 2:
                    heartImages[0] = Properties.Resources.ui_heart_full;
                    heartImages[1] = Properties.Resources.ui_heart_empty;
                    heartImages[2] = Properties.Resources.ui_heart_empty;
                    break;
                case 3:
                    heartImages[0] = Properties.Resources.ui_heart_full;
                    heartImages[1] = Properties.Resources.ui_heart_half;
                    heartImages[2] = Properties.Resources.ui_heart_empty;
                    break;
                case 4:
                    heartImages[0] = Properties.Resources.ui_heart_full;
                    heartImages[1] = Properties.Resources.ui_heart_full;
                    heartImages[2] = Properties.Resources.ui_heart_empty;
                    break;
                case 5:
                    heartImages[0] = Properties.Resources.ui_heart_full;
                    heartImages[1] = Properties.Resources.ui_heart_full;
                    heartImages[2] = Properties.Resources.ui_heart_half;
                    break;
                case 6:
                    heartImages[0] = Properties.Resources.ui_heart_full;
                    heartImages[1] = Properties.Resources.ui_heart_full;
                    heartImages[2] = Properties.Resources.ui_heart_full;
                    break;
            }
        }

        public static void Draw(Graphics g)
        {
            try
            {
                g.DrawImage(heartImages[0], new Rectangle(10, 10, 65, 60));
                g.DrawImage(heartImages[1], new Rectangle(85, 10, 65, 60));
                g.DrawImage(heartImages[2], new Rectangle(160, 10, 65, 60));
            }
            catch { }
        }
    }
}
