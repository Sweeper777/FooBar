using System;
using System.Collections.Generic;
using System.Linq;
namespace FooBar {
    public class ContradictingRulesException<T>: Exception {
        IEnumerable<IRule<T>> rules;

        public ContradictingRulesException(IEnumerable<IRule<T>> rules) {
            this.rules = rules;
        }

        public override string Message {
            get {
                var rulesString = string.Join(", ", rules.Select(x => x.ToString()));
                return $"{rules} contradict each other";
            }
        }
    }
}
