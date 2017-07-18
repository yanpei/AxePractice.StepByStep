using System;
using System.Collections.Generic;
using System.Linq;

namespace Manualfac
{
    public class ComponentContext : IComponentContext
    {

        #region Please modify the following code to pass the test

        /*
         * A ComponentContext is used to resolve a component. Since the component
         * is created by the ContainerBuilder, it brings all the registration
         * information. 
         * 
         * You can add non-public member functions or member variables as you like.
         */
        readonly IList<Delegate> registrationInformations;

        public ComponentContext(IList<Delegate> registrationInformations)
        {
            this.registrationInformations = registrationInformations;
        }

        public object ResolveComponent(Type type)
        {
            Delegate resolveFunc = registrationInformations.LastOrDefault(r => r.Method.ReturnType == type);
            if(resolveFunc == null) throw new DependencyResolutionException();
            return resolveFunc.DynamicInvoke(this);
        }

        #endregion
    }
}