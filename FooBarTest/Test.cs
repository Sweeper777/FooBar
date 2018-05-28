using System;
using FooBar;
using NUnit.Framework;
using System.IO;
namespace FooBar.Test {
    [TestFixture]
    public class FooBarTest {
        [Test]
        public void TestPredicateRule() {
            var predicateRule = new PredicateRule<int>(1, "output", x => x == 0);
            Assert.AreEqual(predicateRule.Rank, 1);
            Assert.AreEqual(predicateRule.Output, "output");
            Assert.IsTrue(predicateRule.Test(0));
            Assert.IsFalse(predicateRule.Test(1));
        }

        [Test]
        public void TestRuleBuilder() {
            var builder = new RuleBuilder();
            var rule = builder.SetOutput("output").SetRank(1).If<int>(x => x == 0);
            Assert.AreEqual(rule.Rank, 1);
            Assert.AreEqual(rule.Output, "output");
            Assert.IsTrue(rule.Test(0));
            Assert.IsFalse(rule.Test(1));
        }

        [Test]
        public void TestTheThing() {
            var predicate = TheThing.IsDivisibleBy(2);
            Assert.IsTrue(predicate(4));
            Assert.IsFalse(predicate(3));
            predicate = TheThing.IsPositive();
            Assert.IsTrue(predicate(1));
            Assert.IsFalse(predicate(0));
            Assert.IsFalse(predicate(-1));
            predicate = TheThing.IsNegative();
            Assert.IsFalse(predicate(1));
            Assert.IsFalse(predicate(0));
            Assert.IsTrue(predicate(-1));
            predicate = TheThing.IsBetween(10, 20);
            Assert.IsTrue(predicate(10));
            Assert.IsTrue(predicate(15));
            Assert.IsTrue(predicate(20));
            Assert.IsFalse(predicate(9));
            Assert.IsFalse(predicate(21));
            predicate = TheThing.IsGreaterThan(5);
            Assert.IsFalse(predicate(4));
            Assert.IsFalse(predicate(5));
            Assert.IsTrue(predicate(6));
            predicate = TheThing.IsGreaterThanOrEqualTo(5);
            Assert.IsFalse(predicate(4));
            Assert.IsTrue(predicate(5));
            Assert.IsTrue(predicate(6));
            predicate = TheThing.IsLessThan(5);
            Assert.IsTrue(predicate(4));
            Assert.IsFalse(predicate(5));
            Assert.IsFalse(predicate(6));
            predicate = TheThing.IsLessThanOrEqualTo(5);
            Assert.IsTrue(predicate(4));
            Assert.IsTrue(predicate(5));
            Assert.IsFalse(predicate(6));

            var stringPredicate = TheThing.Is("Hello");
            Assert.IsTrue(stringPredicate("Hello"));
            Assert.IsFalse(stringPredicate("hello"));
            stringPredicate = TheThing.IsNot("Hello");
            Assert.IsFalse(stringPredicate("Hello"));
            Assert.IsTrue(stringPredicate("hello"));
        }

        [Test]
        public void TestPredicateExtensions() {
            var predicate = PredicateExtensions.And<int>(x => x > 10, x => x > 20);
            Assert.IsTrue(predicate(21));
            Assert.IsFalse(predicate(15));
            Assert.IsFalse(predicate(5));

            predicate = PredicateExtensions.Or<int>(x => x > 10, x => x < 0);
            Assert.IsTrue(predicate(15));
            Assert.IsTrue(predicate(-15));
            Assert.IsFalse(predicate(5));

            predicate = PredicateExtensions.IsNotTrue<int>(x => x == 0);
            Assert.IsTrue(predicate(-1));
            Assert.IsFalse(predicate(0));
        }

        [Test]
        public void TestFooBarRunner() {
            var writer = new StringWriter();
            Console.SetOut(writer);
            new FooBarRunner(1, 20, 1).ApplyRules(
                1. Output("ab").If(TheThing.IsDivisibleBy(2).And(TheThing.IsDivisibleBy(3))),
                2. Output("a").If(TheThing.IsDivisibleBy(2)),
                3. Output("b").If(TheThing.IsDivisibleBy(3))
            );
            string result = @"1
a
b
a
5
ab
7
a
b
a
11
ab
13
a
b
a
17
ab
19
a
";
            Assert.AreEqual(writer.ToString(), result);
        }

        [Test]
        public void TestContradictingRules() {

            var writer = new StringWriter();
            Console.SetOut(writer);
            Assert.Throws<ContradictingRulesException<int>>(() => {
                new FooBarRunner(1, 20, 1).ApplyRules(
                1.Output("a").If(TheThing.IsDivisibleBy(2)),
                1.Output("b").If(TheThing.IsDivisibleBy(3))
            );
            });
        }
    }
}
