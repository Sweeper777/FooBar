using System;
namespace FooBar {
    public interface IRule<in TInput> {
        string Output { get; }
        bool IfAndOnlyIf { get; }

        bool Test(TInput number);
    }

}
