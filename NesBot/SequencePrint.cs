using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot
{
    class SequncePrint
    {
        private object item;

        private void Print(ControlSequence sequnce)
        {
            Foreach(ButtonState, current, in mySequence);
            {
                Console.WriteLine($"Right: {current.ButtonRightIsPressed}, Up: {current.ButtonUpIsPressed}");
            }
        }
    }
}
