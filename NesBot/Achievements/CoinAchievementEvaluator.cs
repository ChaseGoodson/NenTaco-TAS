using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot.Achievements
{
    public class CoinAchievementEvaluator : IAchievementEvaluator
    {
        public List<Achievements> GetAchievements(List<RunResult> runResults)
        {
            var CoinAchievements = new List<Achievements>();

            foreach (var result in runResults)
            {
                if (result.Coins >= 1)
                   CoinAchievements.Add(Achievements.Penny);

                if (result.Coins >= 5)
                   CoinAchievements.Add(Achievements.Nickel);

            }
            return CoinAchievements;
        }
    }
}
