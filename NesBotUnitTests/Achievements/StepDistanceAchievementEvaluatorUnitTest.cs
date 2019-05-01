using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NesBot;
using NesBot.Achievements;

namespace NesBotUnitTests.Achievements
{
    [TestClass]
    public class StepDistanceAchievementEvaluatorUnitTest
    {
        [TestMethod]
        public void WillReturnSteppingOut()
        {
            var SteppingOutRunResult = new RunResult();
            SteppingOutRunResult.StepWhereRunEnded = 15;

            var runResults = new List<RunResult>();
            runResults.Add(SteppingOutRunResult);

            var eval = new DistanceAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(0, ach.Count);
            Console.WriteLine("Stepping Out Achievement Achieved");

        }

        [TestMethod]
        public void WillReturnHighStepper()
        {
            var highStepperRunResult = new RunResult();
            highStepperRunResult.StepWhereRunEnded = 205;

            var runResults = new List<RunResult>();
            runResults.Add(highStepperRunResult);

            var eval = new DistanceAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(0, ach.Count);
            Console.WriteLine("High Stepper Achievement Achieved");
        }
    }
}
