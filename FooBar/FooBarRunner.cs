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

    }
}
