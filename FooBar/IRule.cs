using System;
namespace FooBar {
    public interface IRule<in TInput> {
        string Output { get; }
        bool IfAndOnlyIf { get; }

        bool Test(TInput number);
    }

    public class PredicateRule<TInput>: IRule<TInput> {
        public string Output { get; }
        public bool IfAndOnlyIf { get; }
        Predicate<TInput> predicate;

        public bool Test(TInput input) => predicate(input);

        public PredicateRule(string output, bool iff, Predicate<TInput> predicate) {
            Output = output;
            IfAndOnlyIf = iff;
            this.predicate = predicate;
        }
    }
}
