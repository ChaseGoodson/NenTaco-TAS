using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot.Achievements
{
    public class ScoreAchievementEvaluator : IAchievementEvaluator
    {
        public List<Achievements> GetAchievements(List<RunResult> runResults)
        {
            var ScoreAchievements = new List<Achievements>();

            foreach (var result in runResults)
            {
                if (result.Score >= 100)
                    ScoreAchievements.Add(Achievements.Century);

                if (result.Score >= 1000)
                    ScoreAchievements.Add(Achievements.Millennium);
            }
            return ScoreAchievements;
        }
    }
}
