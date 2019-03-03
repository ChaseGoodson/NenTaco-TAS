using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot.Achievements
{
    public class DistanceAchievementEvaluator : IAchievementEvaluator
    {
        public List<Achievements> GetAchievements(List<RunResult> runResults)
        {
            List<Achievements> runAchievements = new List<Achievements>();

            // if one of the runs makes it past 450, return the pipe jumper achievement
            foreach(var run in runResults)
            {
                if (run.MaximumHorizontalDistance >= 450)
                    runAchievements.Add(Achievements.PipeJumper);

                // TODO: check for Marathoner. It happens at 3000.
                if (run.MaximumHorizontalDistance >= 3000)
                    runAchievements.Add(Achievements.Marathoner);
            }
                        
            return runAchievements;
        }          
    }
}
