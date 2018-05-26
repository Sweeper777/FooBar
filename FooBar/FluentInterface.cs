using System;
namespace FooBar {
    public static class FluentInterface {
        public static FooBarRunner RunFooBar(int from, int to, int step = 1) => new FooBarRunner(from, to, step);

        public static RuleBuilder Output(this int rank, object obj) {
            var builder = new RuleBuilder();
            builder.SetOutput(obj);
            builder.SetRank(rank);
            return builder;
        }
    }
}
