namespace Budget.Core
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract bool EqualsCore(T other);
        protected abstract int GetHashCodeCore();

        public override bool Equals(object obj)
        {
            var ValueObject = obj as T;
            return !ReferenceEquals(ValueObject, null) && EqualsCore(ValueObject);
        }
        public override int GetHashCode()
        {
            return GetHashCode();
        }
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }

}