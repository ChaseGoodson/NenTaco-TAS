using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NesBot;
using NesBot.Achievements;

namespace NesBotUnitTests.Achievements
{
    [TestClass]
    public class DistanceAchievementEvaluatorUnitTest
    {
        [TestMethod]
        public void WillReturnPipeJumper()
        {
            var pipeJumpingRunResult = new RunResult();
            pipeJumpingRunResult.MaximumHorizontalDistance = 450;

            var runResults = new List<RunResult>();
            runResults.Add(pipeJumpingRunResult);

            var eval = new DistanceAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(1, ach.Count);

        }

        [TestMethod]
        public void WillReturnMarathoner()
        {
            var marathonerRunResult = new RunResult();
            marathonerRunResult.MaximumHorizontalDistance = 3000;

            var runResults = new List<RunResult>();
            runResults.Add(marathonerRunResult);

            var eval = new DistanceAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(2, ach.Count);

        }

        [TestMethod]
        public void WillReturnSteppingOut()
        {
            var SteppingOutRunResult = new RunResult();
            SteppingOutRunResult.StepWhereRunEnded = 10;

            var runResults = new List<RunResult>();
            runResults.Add(SteppingOutRunResult);

            var eval = new DistanceAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);
           
            Assert.AreEqual(1, ach.Count);

        }

        [TestMethod]
        public void WillReturnHighStepper()
        {
            var highStepperRunResult = new RunResult();
            highStepperRunResult.StepWhereRunEnded = 200;

            var runResults = new List<RunResult>();
            runResults.Add(highStepperRunResult);

            var eval = new DistanceAchievementEvaluator();

            var ach = eval.GetAchievements(runResults);

            Assert.AreEqual(2, ach.Count);

        }
    }
}
