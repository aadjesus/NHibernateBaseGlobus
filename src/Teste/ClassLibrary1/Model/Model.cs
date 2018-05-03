using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public abstract class Model : IModel, IEquatable<Model>
    {
        public virtual int Id { get; set; }

        public virtual bool Equals(Model other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals((Model)obj);
        }

        public override int GetHashCode()
        {
            return (Id.GetHashCode() * 397) ^ GetType().GetHashCode();
        }

        public static bool operator ==(Model left, Model right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Model left, Model right)
        {
            return !Equals(left, right);
        }
    }
}
