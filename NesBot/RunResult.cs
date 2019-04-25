using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesBot
{
    [DebuggerDisplay("Distance: {MaximumHorizontalDistance}")]
    public class RunResult
    {
        public int MaximumHorizontalDistance { get; set; }
        public int StepWhereRunEnded { get; set; }

        public int Score { get; set; }
        public int Coins { get; set; }
    }
}
