using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NesBot.Achievements;


namespace NesBot
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ControlSequence mySequence = new ControlSequence();

            ControlSequence run = new ControlSequence();
            run = run.RunOne();
            //run = run.RunTwo();
            
            var listOfRuns = new List<ControlSequence>();
            listOfRuns.Add(run);

            //SequencePrinter printer = new SequencePrinter();
			//printer.Print(run);

            var player = new GamePlayer();
            player.Play(listOfRuns);

           

            var results = player.Play(listOfRuns);
            Console.WriteLine(results.Max(r => r.MaximumHorizontalDistance));

            var stepResults = player.Play(listOfRuns);
            Console.WriteLine(results.Max(r => r.StepWhereRunEnded));

            var eval = new DistanceAchievementEvaluator();
            var achievement = eval.GetAchievements(results);
            foreach (var a in achievement)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }
    }
}
