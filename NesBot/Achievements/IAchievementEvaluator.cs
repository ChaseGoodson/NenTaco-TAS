using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot.Achievements
{
    public interface IAchievementEvaluator
    {
        List<Achievements> GetAchievements(List<RunResult> runResults);
    }
}
