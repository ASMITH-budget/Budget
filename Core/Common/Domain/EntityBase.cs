using System;

namespace Budget.Core
{
#nullable disable
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public EntityState EntityState {get; protected set; } = EntityState.None;

        //what if 'object' is nullable??? like this    public override bool Equals(object? obj)
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, this)) return false;
            return Id.Equals(compareTo.Id);
        }
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
        public override string ToString()
        {
            return GetType().Name + "[Id=" + Id + " ]";
        }
    }
}