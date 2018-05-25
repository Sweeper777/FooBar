using static FooBar.FluentInterface;
using static FooBar.RuleBuilder;

namespace FooBar {
    class MainClass {
        public static void Main(string[] args) {
            RunFooBar(from: 1, to: 100).ApplyRules(
                Output("Foo").IfAndOnlyIf(TheThing.IsDivisibleBy(3)),
                Output("Bar").IfAndOnlyIf(TheThing.IsDivisibleBy(4)),
                Output("FooBar").If(TheThing.IsDivisibleBy(3).And(TheThing.IsDivisibleBy(4)))
            );
        }
    }
}
