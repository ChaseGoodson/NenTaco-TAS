using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlSequence mySequnce = new ControlSequence();

            ButtonState buttonStateOne = new ButtonState();
            buttonStateOne.ButtonRightIsPressed = true;
            mySequnce.Add(buttonStateOne);

            ButtonState buttonStateTwo = new ButtonState();
            buttonStateTwo.ButtonUpIsPressed = true;
            mySequnce.Add(buttonStateTwo);

            // TODO - print the button sequence out to the console.

            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }
    }
}
