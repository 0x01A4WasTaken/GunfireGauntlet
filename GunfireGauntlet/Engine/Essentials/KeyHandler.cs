using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GunfireGauntlet.Engine.Essentials
{
    internal class KeyHandler
    {
        public bool w { get; private set; }         // up
        public bool allowW = true;
        public bool a { get; private set; }         // left
        public bool allowA = true;
        public bool s { get; private set; }         // down
        public bool allowS = true;
        public bool d { get; private set; }         // right
        public bool allowD = true;
        public bool esc { get; private set; }       // escape
        public bool allowEsc = true;
        public bool space { get; private set; }     // space
        public bool allowSpace = true;
        public bool shift { get; private set; }     // shift
        public bool allowShift = true;
        public bool one { get; private set; }       // 1
        public bool allowOne = true;
        public bool two { get; private set; }       // 2
        public bool allowTwo = true;

        public void KeyDetection()
        {
            w = ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0 & allowW) ? true : false;
            a = ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0 & allowA) ? true : false;
            s = ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0 & allowS) ? true : false;
            d = ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0 & allowD) ? true : false;
            esc = ((Keyboard.GetKeyStates(Key.Escape) & KeyStates.Down) > 0 & allowEsc) ? true : false;
            space = ((Keyboard.GetKeyStates(Key.Space) & KeyStates.Down) > 0 & allowSpace) ? true : false;
            shift = ((Keyboard.GetKeyStates(Key.LeftShift) & KeyStates.Down) > 0 & allowShift) ? true : false;
            one = ((Keyboard.GetKeyStates(Key.D1) & KeyStates.Down) > 0 & allowOne) ? true : false;
            two = ((Keyboard.GetKeyStates(Key.D2) & KeyStates.Down) > 0 & allowTwo) ? true : false;
        }
    }
}
