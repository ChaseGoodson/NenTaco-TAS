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
        public bool ButtonStartIsPressed { get; set; }
        public bool ButtonSelectIsPressed { get; set; }

        public static ButtonState DoNothing =>
            new ButtonState();

        public static ButtonState Start =>
            new ButtonState() { ButtonStartIsPressed = true };

        public static ButtonState Right =>
            new ButtonState() { ButtonRightIsPressed = true };

        public static ButtonState Left =>
            new ButtonState() { ButtonLeftIsPressed = true };

        public static ButtonState Down =>
            new ButtonState() { ButtonDownIsPressed = true };

        public static ButtonState Jump =>
            new ButtonState() { ButtonAIsPressed = true };

        public static ButtonState RightJump =>
            new ButtonState() { ButtonRightIsPressed = true,
                                ButtonAIsPressed = true};

        public static ButtonState LeftJump =>
            new ButtonState() { ButtonLeftIsPressed = true,
                                ButtonAIsPressed = true};

        public static ButtonState Run =>
            new ButtonState() { ButtonRightIsPressed = true,
                                ButtonBIsPressed = true};


    }
}
