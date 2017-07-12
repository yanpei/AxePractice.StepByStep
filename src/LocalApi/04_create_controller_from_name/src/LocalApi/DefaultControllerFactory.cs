using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LocalApi
{
    class DefaultControllerFactory : IControllerFactory
    {
        public HttpController CreateController(
            string controllerName,
            ICollection<Type> controllerTypes,
            IDependencyResolver resolver)
        {
            #region Please modify the following code to pass the test.

            /*
             * The controller factory will create controller by its name. It will search
             * form the controllerTypes collection to get the correct controller type,
             * then create instance from resolver.
             */
            var candidateTypes = controllerTypes.Where(t => string.Equals(t.Name, controllerName, StringComparison.CurrentCultureIgnoreCase)).ToArray();
            if (candidateTypes.Length > 1)
            {
                throw new ArgumentException();
            }

            Type controllerType = candidateTypes.SingleOrDefault();
            return controllerTypes.Contains(controllerType) ? (HttpController)resolver.GetService(controllerType) : null;

            #endregion
        }
    }
}