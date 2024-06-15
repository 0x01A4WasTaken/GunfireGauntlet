using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GunfireGauntlet.Engine.Essentials
{
    public static class KeyHandler
    {
        public static bool w { get; private set; }         // up
        public static bool allowW = true;
        public static bool a { get; private set; }         // left
        public static bool allowA = true;
        public static bool s { get; private set; }         // down
        public static bool allowS = true;
        public static bool d { get; private set; }         // right
        public static bool allowD = true;
        public static bool esc { get; private set; }       // escape
        public static bool allowEsc = true;
        public static bool space { get; private set; }     // space
        public static bool allowSpace = true;
        public static bool shift { get; private set; }     // shift
        public static bool allowShift = true;
        public static bool one { get; private set; }       // 1
        public static bool allowOne = true;
        public static bool two { get; private set; }       // 2
        public static bool allowTwo = true;

        public static void KeyDetectionDown(KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W) & allowW)
                w = true;
            if ((e.KeyCode == Keys.A) & allowA)
                a = true;
            if ((e.KeyCode == Keys.S) & allowS)
                s = true;
            if ((e.KeyCode == Keys.D) & allowD)
                d = true;
            if ((e.KeyCode == Keys.Escape) & allowEsc)
                esc = true;
            if ((e.KeyCode == Keys.Space) & allowSpace)
                space = true;
            if ((e.KeyCode == Keys.LShiftKey) & allowShift)
                shift = true;
            if ((e.KeyCode == Keys.D1) & allowOne)
                one = true;
            if ((e.KeyCode == Keys.D2) & allowTwo)
                two = true;
        }

        public static void KeyDetectionUp(KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W) & allowW)
                w = false;
            if ((e.KeyCode == Keys.A) & allowA)
                a = false;
            if ((e.KeyCode == Keys.S) & allowS)
                s = false;
            if ((e.KeyCode == Keys.D) & allowD)
                d = false;
            if ((e.KeyCode == Keys.Escape) & allowEsc)
                esc = false;
            if ((e.KeyCode == Keys.Space) & allowSpace)
                space = false;
            if ((e.KeyCode == Keys.LShiftKey) & allowShift)
                shift = false;
            if ((e.KeyCode == Keys.D1) & allowOne)
                one = false;
            if ((e.KeyCode == Keys.D2) & allowTwo)
                two = false;
        }
    }
}
