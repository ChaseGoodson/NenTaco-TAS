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
            ControlSequence mySequence = new ControlSequence();

            ButtonState buttonStateOne = new ButtonState();
            buttonStateOne.ButtonRightIsPressed = true;
            mySequence.Add(buttonStateOne);

            ButtonState buttonStateTwo = new ButtonState();
            buttonStateTwo.ButtonLeftIsPressed = true;
            mySequence.Add(buttonStateTwo);

			ButtonState buttonStateThree = new ButtonState();
			buttonStateThree.ButtonUpIsPressed = true;
			mySequence.Add(buttonStateThree);

			ButtonState buttonStateFour = new ButtonState();
			buttonStateFour.ButtonDownIsPressed = true;
			mySequence.Add(buttonStateFour);

			ButtonState buttonStateFive = new ButtonState();
			buttonStateFive.ButtonAIsPressed = true;
			mySequence.Add(buttonStateFive);

			ButtonState buttonStateSix = new ButtonState();
			buttonStateSix.ButtonBIsPressed = true;
			mySequence.Add(buttonStateSix);


			SequencePrinter printer = new SequencePrinter();
			printer.Print(mySequence);
			
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }
    }
}
