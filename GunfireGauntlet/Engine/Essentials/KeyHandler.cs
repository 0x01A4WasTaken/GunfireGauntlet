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
        public bool a { get; private set; }         // left
        public bool s { get; private set; }         // down
        public bool d { get; private set; }         // right
        public bool esc { get; private set; }       // escape
        public bool space { get; private set; }     // space
        public bool shift { get; private set; }     // shift
        public bool one { get; private set; }       // 1
        public bool two { get; private set; }       // 2

        public void KeyDetection()
        {
            w = ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0) ? true : false;
            a = ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0) ? true : false;
            s = ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0) ? true : false;
            d = ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0) ? true : false;
            esc = ((Keyboard.GetKeyStates(Key.Escape) & KeyStates.Down) > 0) ? true : false;
            space = ((Keyboard.GetKeyStates(Key.Space) & KeyStates.Down) > 0) ? true : false;
            shift = ((Keyboard.GetKeyStates(Key.LeftShift) & KeyStates.Down) > 0) ? true : false;
            one = ((Keyboard.GetKeyStates(Key.D1) & KeyStates.Down) > 0) ? true : false;
            two = ((Keyboard.GetKeyStates(Key.D2) & KeyStates.Down) > 0) ? true : false;
        }

    }
}
