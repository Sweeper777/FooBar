using System;
namespace FooBar {
    public static class PredicateExtensions {
        public static Predicate<T> And<T>(this Predicate<T> left, Predicate<T> right) => x => left(x) && right(x);

        public static Predicate<T> Or<T>(this Predicate<T> left, Predicate<T> right) => x => left(x) || right(x);

        public static Predicate<T> IsNotTrue<T>(this Predicate<T> predicate) => x => !predicate(x);
    }

}
