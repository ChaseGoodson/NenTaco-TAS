using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot
{
    class SequencePrinter
    {
		public void Print(ControlSequence sequence)
        {
			foreach(ButtonState item in sequence)
            {
				Console.WriteLine($"Right: {item.ButtonRightIsPressed}, Left: {item.ButtonLeftIsPressed}, Up: {item.ButtonUpIsPressed}, Down: {item.ButtonDownIsPressed}, A: {item.ButtonAIsPressed}, B: {item.ButtonBIsPressed}");
			}
        }
    }
}
