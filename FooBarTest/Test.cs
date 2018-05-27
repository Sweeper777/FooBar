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
        }
    }
}
