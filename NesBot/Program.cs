using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NesBot.Achievements;
using System.IO;



namespace NesBot
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ControlSequence mySequence = new ControlSequence();

            ControlSequence run = new ControlSequence();
            run = run.RunOne();
            
            var listOfRuns = new List<ControlSequence>();
            listOfRuns.Add(run);
            
            var player = new GamePlayer();
            var results = player.Play(listOfRuns);

            var eval = new DistanceAchievementEvaluator();
            var achievement = eval.GetAchievements(results);

            Console.WriteLine(results.Max(r => r.MaximumHorizontalDistance));
            Console.WriteLine(results.Max(r => r.StepWhereRunEnded));

            Console.WriteLine("Do you want the achievements to print to screen or to text file?");
            Console.WriteLine("1) Screen");
            Console.WriteLine("2) Text");
            Console.WriteLine("Press 1 or 2");
            int userPick = Convert.ToInt32(Console.ReadLine());
            if (userPick == 1)
            {
                foreach (var a in achievement)
                {
                    Console.WriteLine(a);
                }
            }
            else if (userPick == 2)
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\cheez\Desktop\Achievements.txt"))
                    foreach (var a in achievement)
                    {
                        file.WriteLine(a);
                    }
            }
            else
            {
                Console.WriteLine("Invalid choice. Your achievements are deleted.");
            }

            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }
    }
}
