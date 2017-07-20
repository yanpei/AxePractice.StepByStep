using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Manualfac.Services;

namespace Manualfac.Activators
{
    class ReflectiveActivator : IInstanceActivator
    {
        readonly Type serviceType;

        public ReflectiveActivator(Type serviceType)
        {
            this.serviceType = serviceType;
        }

        #region Please modify the following code to pass the test

        /*
         * This method create instance via reflection. Try evaluating its parameters and
         * inject them using componentContext.
         * 
         * No public members are allowed to add.
         */

        public object Activate(IComponentContext componentContext)
        {
            var constructorInfos = serviceType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            if(constructorInfos.Length != 1) throw new DependencyResolutionException();
            var constructor = constructorInfos.Single();
            var parameters = new List<object>();
            foreach (var i in constructor.GetParameters())
            {
                Type paramtype = i.ParameterType;
                var instance = componentContext.ResolveComponent(new TypedService(paramtype));
                parameters.Add(instance);
            }
            return constructor.Invoke(parameters.ToArray());
        }

        #endregion
    }
}