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
            var runAchievements = new List<Achievements>();

            foreach(var result in runResults)
            {
                if (result.MaximumHorizontalDistance >= 450)
                    runAchievements.Add(Achievements.PipeJumper);

                
                if (result.MaximumHorizontalDistance >= 3000)
                    runAchievements.Add(Achievements.Marathoner);
                            
            }
                        
            return runAchievements;
        }
         
    }
    
}
