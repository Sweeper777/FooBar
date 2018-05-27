using System;
namespace FooBar {
    public static class PredicateExtensions {
        public static Predicate<T> And<T>(this Predicate<T> left, Predicate<T> right) => x => left(x) && right(x);

        public static Predicate<T> Or<T>(this Predicate<T> left, Predicate<T> right) => x => left(x) || right(x);

        public static Predicate<T> IsNotTrue<T>(this Predicate<T> predicate) => x => !predicate(x);
    }

    public static class TheThing {
        public static Predicate<int> IsDivisibleBy(int number) => x => x % number == 0;

        public static Predicate<int> IsPositive() => x => x > 0;

        public static Predicate<int> IsNegative() => x => x < 0;

        public static Predicate<T> Is<T>(T obj) where T : IEquatable<T> => x => x.Equals(obj);

        public static Predicate<T> IsNot<T>(T obj) where T : IEquatable<T> => Is(obj).IsNotTrue();

        public static Predicate<T> IsGreaterThan<T>(T obj) where T : IComparable<T> => x => x.CompareTo(obj) > 0;

        public static Predicate<T> IsLessThan<T>(T obj) where T : IComparable<T> => x => x.CompareTo(obj) < 0;

        public static Predicate<T> IsGreaterThanOrEqualTo<T>(T obj) where T : IComparable<T> => x => x.CompareTo(obj) >= 0;

        public static Predicate<T> IsLessThanOrEqualTo<T>(T obj) where T : IComparable<T> => x => x.CompareTo(obj) <= 0;

        public static Predicate<T> IsBetween<T>(T min, T max) where T : IComparable<T> => IsLessThanOrEqualTo(max).And(IsGreaterThanOrEqualTo(min));
    }
}
