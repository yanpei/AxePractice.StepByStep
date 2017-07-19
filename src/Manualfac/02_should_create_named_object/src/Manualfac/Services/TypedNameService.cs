using System;

namespace Manualfac.Services
{
    class TypedNameService : Service, IEquatable<TypedNameService>
    {
        #region Please modify the following code to pass the test

        /*
         * This class is used as a key for registration by both type and name.
         */

        public string Name { get;}

        public Type ServiceType { get;}

        public TypedNameService(Type serviceType, string name)
        {
            ServiceType = serviceType;
            Name = name;
        }

        public bool Equals(TypedNameService other)
        {
            if (null == other) return false;
            if (ReferenceEquals(this, other)) return true;
            return ServiceType == other.ServiceType && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (null == obj) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TypedNameService)obj);
        }

        public override int GetHashCode() { return ServiceType.GetHashCode() ^ Name.GetHashCode(); }

        #endregion
    }
}