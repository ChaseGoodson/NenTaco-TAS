using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot
{
    public class ButtonState
    {
        public bool ButtonLeftIsPressed { get; set; }
        public bool ButtonRightIsPressed { get; set; }
        public bool ButtonUpIsPressed { get; set; }
        public bool ButtonDownIsPressed { get; set; }
        public bool ButtonAIsPressed { get; set; }
        public bool ButtonBIsPressed { get; set; }

        public static ButtonState MovingRight =>
            new ButtonState() { ButtonRightIsPressed = true };
        public static ButtonState Jumping =>
            new ButtonState() { ButtonAIsPressed = true };
        public static ButtonState MovingRightAndJumping =>
            new ButtonState() { ButtonRightIsPressed = true,
                                ButtonAIsPressed = true};
    }
}
