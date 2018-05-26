using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace FooBar {
    public class RuleCollection<T>: IEnumerable<IRule<T>> {
        public List<IRule<T>> Rules { get; }

        public RuleCollection(IEnumerable<IRule<T>> rules) {
            Rules = new List<IRule<T>>();
            Rules.AddRange(rules);
        }

        public IEnumerable<IRule<T>> TestAgainst(T obj) {
            return Rules.Where(x => x.Test(obj));
        }

        public IEnumerator<IRule<T>> GetEnumerator() {
            return Rules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Rules.GetEnumerator();
        }
    }
}
