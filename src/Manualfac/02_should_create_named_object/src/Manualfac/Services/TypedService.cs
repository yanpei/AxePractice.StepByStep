using System;

namespace Manualfac.Services
{
    class TypedService : Service, IEquatable<TypedService>
    {
        #region Please modify the following code to pass the test

        /*
         * This class is used as a key for registration by type.
         */
        public Type ServiceType { get; }

        public TypedService(Type serviceType) {
            ServiceType = serviceType;
        }

        public bool Equals(TypedService other)
        {
            if (null ==  other) return false;
            if (ReferenceEquals(this, other)) return true;
            return ServiceType == other.ServiceType;
        }

        public override bool Equals(object obj)
        {
            if (null == obj) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TypedService) obj);
        }

        public override int GetHashCode() {
            return (ServiceType != null ? ServiceType.GetHashCode() : 0);
        }

        #endregion
    }
}