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

            foreach(var run in runResults)
            {
                if (run.MaximumHorizontalDistance >= 450)
                    runAchievements.Add(Achievements.PipeJumper);

                
                if (run.MaximumHorizontalDistance >= 3000)
                    runAchievements.Add(Achievements.Marathoner);

                if (run.StepWhereRunEnded >= 10)
                    runAchievements.Add(Achievements.SteppingOut);

                if (run.StepWhereRunEnded >= 200)
                    runAchievements.Add(Achievements.HighStepper);
            
            }
                        
            return runAchievements;
        }
         
    }
    
}
