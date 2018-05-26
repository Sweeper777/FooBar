using System;
namespace FooBar {
    public class RuleBuilder {
        string output;
        int rank;

        public RuleBuilder SetOutput(object obj) {
            output = obj.ToString();
            return this;
        }

        public RuleBuilder SetRank(int rank) {
            this.rank = rank;
            return this;
        }

        public IRule<T> If<T>(Predicate<T> predicate) => new PredicateRule<T>(rank, output, predicate);
    }
}
