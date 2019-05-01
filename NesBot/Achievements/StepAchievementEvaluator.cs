using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot.Achievements
{
    public class StepAchievementEvaluator : IAchievementEvaluator
    {
        public List<Achievements> GetAchievements(List<RunResult> runResults)
        {
            var stepAchievements = new List<Achievements>();

            foreach (var result in runResults)
            {

                if (result.StepWhereRunEnded >= 10)
                    stepAchievements.Add(Achievements.SteppingOut);

                if (result.StepWhereRunEnded >= 200)
                    stepAchievements.Add(Achievements.HighStepper);
            }
            return stepAchievements;
        }
    }
}
