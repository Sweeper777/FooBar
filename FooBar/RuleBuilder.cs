using System;
namespace FooBar {
    public class RuleBuilder {
        RuleBuilder(string output) { this.output = output; }

        string output;

        public static RuleBuilder Output(object obj) => new RuleBuilder(obj.ToString());

        public IRule<T> IfAndOnlyIf<T>(Predicate<T> predicate) => new PredicateRule<T>(output, true, predicate);

        public IRule<T> If<T>(Predicate<T> predicate) => new PredicateRule<T>(output, false, predicate);
    }
}
