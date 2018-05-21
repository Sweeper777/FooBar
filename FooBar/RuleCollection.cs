using System.Collections.Generic;
using System.Linq;
namespace FooBar {
    public class RuleCollection<T> {
        public List<IRule<T>> Rules { get; }

        public RuleCollection(IEnumerable<IRule<T>> rules) {
            Rules = new List<IRule<T>>();
            Rules.AddRange(rules);
        }
    }
}
