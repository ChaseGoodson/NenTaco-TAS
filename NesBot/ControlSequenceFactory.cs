using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot
{
    public class ControlSequenceFactory
    {
        private ButtonState _doNothing = new ButtonState();
        private ButtonState _pressStart = new ButtonState() { ButtonStartIsPressed = true };
        private ButtonState _moveRight = new ButtonState() { ButtonRightIsPressed = true };

        private ButtonState _moveRightAndJump = new ButtonState()
        {
            ButtonAIsPressed = true,
            ButtonRightIsPressed = true
        };

        public ControlSequence KamikamikazeRunRight()
        {
            ControlSequence mySecondSequence = new ControlSequence();
            mySecondSequence.Add(_doNothing);
            mySecondSequence.Add(_doNothing);
            mySecondSequence.Add(_pressStart);
            mySecondSequence.Add(_doNothing);
            mySecondSequence.Add(_doNothing);
            mySecondSequence.Add(_moveRight);
            mySecondSequence.Add(_moveRight);
            mySecondSequence.Add(_moveRight);
            mySecondSequence.Add(_moveRight);
            mySecondSequence.Add(_moveRight);
            mySecondSequence.Add(_moveRight);
            mySecondSequence.Add(_moveRight);

            return mySecondSequence;
        }

        public ControlSequence RunAndJump()
        {
            ControlSequence myFirstSequence = new ControlSequence();
            myFirstSequence.Add(_doNothing);
            myFirstSequence.Add(_doNothing);
            myFirstSequence.Add(_pressStart);
            myFirstSequence.Add(_doNothing);
            myFirstSequence.Add(_doNothing);
            myFirstSequence.Add(_moveRight);
            myFirstSequence.Add(_moveRightAndJump);
            myFirstSequence.Add(_moveRight);
            myFirstSequence.Add(_moveRightAndJump);
            myFirstSequence.Add(_moveRight);
            myFirstSequence.Add(_moveRightAndJump);
            myFirstSequence.Add(_moveRight);
            myFirstSequence.Add(_moveRightAndJump);

            return myFirstSequence;
        }
    }
}
