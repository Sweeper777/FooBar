﻿using System;
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
                var rulesSatisfied = ruleCollection.TestAgainst(i).ToList();

                if (rulesSatisfied.Count == 0) {
                    Console.WriteLine(i);
                    continue;
                }

                var highestRank = rulesSatisfied.Min(x => x.Rank);
                var highestRankRules = rulesSatisfied.Where(x => x.Rank == highestRank);
                var possibleOutputs = highestRankRules.Select(x => x.Output);
                if (possibleOutputs.Count() > 1) {
                    throw new ContradictingRulesException<int>(highestRankRules);
                }
                Console.WriteLine(possibleOutputs.First());
            }
        }
    }
}
