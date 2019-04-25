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
        private List<ControlSequence> _runs;
        private List<RunResult> _runResults = new List<RunResult>();

        public List<RunResult> Play(List<ControlSequence> runs)
        {
            _runs = runs;
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

            return _runResults;
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
            maxHorizontalPosition = 0;
            lastButtonChangeFrame = _api.GetFrameCount();
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
        private int maxNumberOfLives = 2;
        private bool gameHasStarted = false;

        private int GetPrimaryMode() => _api.ReadCPU(0x0770); //  (0=title screen, 1=game, 2=victory, 3=game over)
        private int GetSecondaryMode() => _api.ReadCPU(0x0772); 
        private int GetNumberOfLives() => _api.ReadCPU(0x075A);
        private bool IsGamePlayInteruppted() => GetPrimaryMode() == 1 && GetSecondaryMode() == 1;
        private bool IsGamePlayHasStarted() => GetPrimaryMode() == 1 && GetSecondaryMode() == 3;
        private int GetCurrentHorizontalPagePosition() => _api.ReadCPU(0x0086);
        private int GetCurrentPageLocation() => _api.ReadCPU(0x006D);
        private int GetCurrentHorizontalPosition() => GetCurrentHorizontalPagePosition() + (GetCurrentPageLocation() * 255);
        private int GetPlayerSize() => _api.ReadCPU(0x0754); // player's size (0=big, 1=small)
        private int GetPlayerStatus() => _api.ReadCPU(0x0756); //  player status (0=small, 1=super, 2=fiery)
        private int GetWorldNumber() => _api.ReadCPU(0x075f);
        private int GetWorldAreaNumber() => _api.ReadCPU(0x075c);

        private int GetScore()
        {
            int hundredKPosition = _api.ReadCPU(0x07DE);
            int tenKPosition = _api.ReadCPU(0x07DF);
            int oneKPosition = _api.ReadCPU(0x07E0);
            int hundredPosition = _api.ReadCPU(0x07E1);
            int tenPosition = _api.ReadCPU(0x07E2);
            int onePosition = _api.ReadCPU(0x07E3);

            return
                hundredKPosition * 100_000
                + tenKPosition * 10_000
                + oneKPosition * 1_000
                + hundredPosition * 100
                + tenPosition * 10
                + onePosition;
        }

        private int GetCoins()
        {

            int tenPosition = _api.ReadCPU(0x07ED);
            int onePosition = _api.ReadCPU(0x07EE);

            return
                tenPosition * 10
                + onePosition;
        }


        // TODO: 
        // Get the score
        // Get max vertical position


        private void RenderFinished()
        {
            int currentFrame = _api.GetFrameCount();
            int currentStateDuration = currentFrame - lastButtonChangeFrame;
            if(currentStateDuration > buttonPressDuration)
            {
                currentButtonInRun++;
                System.Diagnostics.Debug.WriteLine(currentButtonInRun);
                lastButtonChangeFrame = currentFrame;
                //Console.WriteLine("Changed");
            }

            var buttonsInRun = _runs[currentRunNumber];

            if (currentButtonInRun < buttonsInRun.Count)
            {
                var button = buttonsInRun[currentButtonInRun];
                //Console.WriteLine($"state transition: start: {button.ButtonStartIsPressed}");
                PushButtons(button);
            }

            int currentHorizontalPosition = GetCurrentHorizontalPosition();

            if (currentHorizontalPosition > maxHorizontalPosition && currentButtonInRun > 0)
            {
                maxHorizontalPosition = currentHorizontalPosition;
                //Console.WriteLine(maxHorizontalPosition);
            }

            gameHasStarted |= IsGamePlayHasStarted();


            int currentNumberOfLives = GetNumberOfLives();
            if(currentNumberOfLives > maxNumberOfLives)
            {
                maxNumberOfLives = currentNumberOfLives;
            }
            else if (gameHasStarted && currentNumberOfLives < maxNumberOfLives)
            //if (primaryMode == 1 && secondaryMode == 1 && maxHorizontalPosition > 50 && currentButtonInRun > 4)
            {
                _runResults.Add(new RunResult() {
                    MaximumHorizontalDistance = maxHorizontalPosition,
                    StepWhereRunEnded = currentButtonInRun,
                    Score = GetScore(),
                    Coins = GetCoins()
                });

                _api.Reset();
                currentRunNumber++;
                currentButtonInRun = 0;
                maxHorizontalPosition = 0;
                gameHasStarted = false;
                
                if (currentRunNumber >= _runs.Count)
                {
                    throw new Exception();
                }
                Console.WriteLine($"Starting run {currentRunNumber}");
            }

            //Console.WriteLine(GetCoins());

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
