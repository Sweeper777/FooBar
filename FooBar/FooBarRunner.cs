using System;
using System.Linq;
namespace FooBar {
    public class FooBarRunner {
        public int From { get; }
        public int To { get; }
        public int Step { get; }

        public FooBarRunner(int from, int to, int step) {
            From = from;
            To = to;
            Step = step;
        }

        public void ApplyRules(params IRule<int>[] rules) {
            var ruleCollection = new RuleCollection<int>(rules);
            for (int i = From; i <= To; i += Step) {
                var output = string.Join("", ruleCollection.TestAgainst(i).Select(x => x.Output));
                Console.WriteLine(output == string.Empty ? i.ToString(): output);
            }
        }
    }
}
