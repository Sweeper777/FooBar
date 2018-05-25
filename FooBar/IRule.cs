using System;
namespace FooBar {
    public interface IRule<in TInput> {
        string Output { get; }
        int Rank { get; }

        bool Test(TInput number);
    }

    public class PredicateRule<TInput>: IRule<TInput> {
        public string Output { get; }

        public int Rank { get; }

        Predicate<TInput> predicate;

        public bool Test(TInput input) => predicate(input);

        public PredicateRule(int rank, string output, Predicate<TInput> predicate) {
            Output = output;
            Rank = rank;
            this.predicate = predicate;
        }
    }
}
