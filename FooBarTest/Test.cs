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
    }
}
