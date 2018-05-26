using static FooBar.FluentInterface;

namespace FooBar {
    class MainClass {
        public static void Main(string[] args) {
            RunFooBar(from: 1, to: 100).ApplyRules(
                1. Output("FooBar").If(TheThing.IsDivisibleBy(3).And(TheThing.IsDivisibleBy(4))),
                2. Output("Foo").If(TheThing.IsDivisibleBy(3)),
                3. Output("Bar").If(TheThing.IsDivisibleBy(4))
            );
        }
    }
}
