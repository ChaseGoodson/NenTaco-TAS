using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot
{

    public class ControlSequence : List<ButtonState>
    {
        public ButtonState DoNothing { get; }
        public ButtonState Start { get; }
        public ButtonState Right { get; }
        public ButtonState Left { get; }
        public ButtonState Down { get; }
        public ButtonState Jump { get; }
        public ButtonState RightJump { get; }
        public ButtonState LeftJump { get; }
        public ButtonState Run { get; }
        
        public ControlSequence RunOne()
        {
            var one = new ControlSequence

            {

                ButtonState.DoNothing,
                ButtonState.Start,
                ButtonState.DoNothing,
                ButtonState.Right,
                ButtonState.Right,
                ButtonState.Right,
                ButtonState.RightJump,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Left,
                ButtonState.DoNothing,
                ButtonState.Jump,
                ButtonState.Right,
                ButtonState.RightJump,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Run,
                ButtonState.Jump,
                ButtonState.DoNothing,
                ButtonState.Jump,
                ButtonState.Right,
                ButtonState.DoNothing,
                ButtonState.Run,
                ButtonState.Jump,
                ButtonState.Run,
                ButtonState.Run,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.DoNothing,
                ButtonState.RightJump,
                ButtonState.LeftJump,
                ButtonState.Right,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Run,
                ButtonState.RightJump,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Right,      //into hole
                ButtonState.Left,
                ButtonState.RightJump,  //out of hole
                ButtonState.Right,
                ButtonState.RightJump,
                ButtonState.RightJump,
                ButtonState.RightJump,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Run,
                ButtonState.Jump,
                ButtonState.Left,
                ButtonState.LeftJump, //back to Start of stairs
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Run,
                ButtonState.Jump     //top of dumb stairs
            
           };

            return one; 
        }
        public ControlSequence RunTwo()
        {
            var two = new ControlSequence
            {
                ButtonState.DoNothing,
                ButtonState.Start,
                ButtonState.DoNothing,
                ButtonState.Right,
                ButtonState.Right,
                ButtonState.Right,
                ButtonState.RightJump,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Left,
                ButtonState.DoNothing,
                ButtonState.Jump,
                ButtonState.Right,
                ButtonState.RightJump,
                ButtonState.Right,
                ButtonState.Jump,
                ButtonState.Right,
                ButtonState.Left,
                ButtonState.LeftJump,
                ButtonState.Down,
            };
            return two;
        }
    }
}
