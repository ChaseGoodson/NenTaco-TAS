using Nintaco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot
{
    public class GamePlayer
    {
        private RemoteAPI _api;
        private List<ControlSequence> _Runs;
        private List<RunResult> _RunResults = new List<RunResult>();

        public List<RunResult> Play(List<ControlSequence> Runs)
        {
            _Runs = Runs;
            ApiSource.initRemoteAPI("localhost", 9999);

            _api = ApiSource.API;


            _api.AddActivateListener(ApiEnabled);
            _api.AddFrameListener(RenderFinished);
            _api.AddDeactivateListener(Deactivate);
            //_api.AddStatusListener(StatusChanged);

            try
            {
                _api.Run();
            }
            catch(Exception ex)
            {
                //Console.WriteLine("caught");
            }

            return _RunResults;
        }

        private void Deactivate()
        {
            //Console.WriteLine("Deactivate");
            throw new Exception();
        }

        private void ApiEnabled()
        {
            Console.WriteLine("API enabled");
            
            _api.Reset(); // Uncomment this to reset the console
            lastButtonChangeFrame = _api.GetFrameCount();
        }
        
        internal void Play()
        {
            //throw new NotImplementedException();
        }

        private void StatusChanged(string message)
        {
            Console.WriteLine($"Status Changed: {message}");
        }

        private int currentRunNumber = 0;
        private int currentButtonInRun = 0;
        private int lastButtonChangeFrame = 0;
        private int buttonPressDuration = 60;
        private int maxHorizontalPosition = 0;

        private void RenderFinished()
        {
            int currentFrame = _api.GetFrameCount();
            int currentStateDuration = currentFrame - lastButtonChangeFrame;
            if(currentStateDuration > buttonPressDuration)
            {
                currentButtonInRun++;
                lastButtonChangeFrame = currentFrame;
                //Console.WriteLine("Changed");
            }

            var buttonsInRun = _Runs[currentRunNumber];

            if (currentButtonInRun < buttonsInRun.Count)
            {
                var button = buttonsInRun[currentButtonInRun];
                //Console.WriteLine($"state transition: Start: {button.ButtonStartIsPressed}");
                PushButtons(button);
            }

            int currentHorizontalPagePosition = _api.ReadCPU(0x0086);
            int currentPageLocation = _api.ReadCPU(0x006D);
            int currentHorizontalPosition = currentHorizontalPagePosition + (currentPageLocation * 255);

            if (currentHorizontalPosition > maxHorizontalPosition)
            {
                maxHorizontalPosition = currentHorizontalPosition;
                Console.WriteLine(maxHorizontalPosition);
            }

            int primaryMode = _api.ReadCPU(0x0770);
            int secondaryMode = _api.ReadCPU(0x0772);

            if (primaryMode == 1 && secondaryMode == 1 && maxHorizontalPosition > 50 && currentButtonInRun > 4)
            {
                _RunResults.Add(new RunResult() { MaximumHorizontalDistance = maxHorizontalPosition, StepWhereRunEnded = currentButtonInRun });

                _api.Reset();
                currentRunNumber++;
                currentButtonInRun = 0;
                maxHorizontalPosition = 0;
                
                if (currentRunNumber >= _Runs.Count)
                {
                    throw new Exception();
                }
            }

        }

        private void PushButtons(ButtonState buttons)
        {
            ApiSource.API.WriteGamepad(0, GamepadButtons.Right, buttons.ButtonRightIsPressed);
            ApiSource.API.WriteGamepad(0, GamepadButtons.Left, buttons.ButtonLeftIsPressed);
            ApiSource.API.WriteGamepad(0, GamepadButtons.Up, buttons.ButtonUpIsPressed);
            ApiSource.API.WriteGamepad(0, GamepadButtons.Down, buttons.ButtonDownIsPressed);
            ApiSource.API.WriteGamepad(0, GamepadButtons.A, buttons.ButtonAIsPressed);
            ApiSource.API.WriteGamepad(0, GamepadButtons.B, buttons.ButtonBIsPressed);
            ApiSource.API.WriteGamepad(0, GamepadButtons.Start, buttons.ButtonStartIsPressed);
            ApiSource.API.WriteGamepad(0, GamepadButtons.Select, buttons.ButtonSelectIsPressed);
        }
    }
}
