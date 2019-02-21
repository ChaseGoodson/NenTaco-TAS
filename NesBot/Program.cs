using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlSequence mySequence = new ControlSequence();
            

            var listOfRuns = new List<ControlSequence>();
            listOfRuns.Add(mySequence);

            var player = new GamePlayer();
            player.Play(listOfRuns);


            ControlSequence run = new ControlSequence();
            run.RunOne();
            
            var results = player.Play(listOfRuns);
            Console.WriteLine(results.Max(r => r.MaximumHorizontalDistance));

            var stepResults = player.Play(listOfRuns);
            Console.WriteLine(results.Max(r => r.StepWhereRunEnded));
            
            SequencePrinter printer = new SequencePrinter();
			printer.Print(mySequence);
			
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }
    }
}
