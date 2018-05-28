using System;
using System.Collections.Generic;
using System.Linq;
namespace FooBar {
    public class ContradictingRulesException<T>: Exception {
        IEnumerable<IRule<T>> rules;

        public ContradictingRulesException(IEnumerable<IRule<T>> rules) {
            this.rules = rules;
        }

    }
}
