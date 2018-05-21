using System.Collections.Generic;
using System.Linq;
namespace FooBar {
    public class RuleCollection<T> {
        public List<IRule<T>> Rules { get; }

        public RuleCollection(IEnumerable<IRule<T>> rules) {
            Rules = new List<IRule<T>>();
            Rules.AddRange(rules);
        }

        public IEnumerable<IRule<T>> TestAgainst(T obj) {
            var rulesSatisfied = Rules.Where(x => x.Test(obj));
            if (rulesSatisfied.Count() != 1) {
                return rulesSatisfied.Where(x => !x.IfAndOnlyIf);
            }
            return rulesSatisfied;
        }
    }
}
