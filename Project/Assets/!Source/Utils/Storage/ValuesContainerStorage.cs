using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace GameCore
{

    public class ValuesContainerStorage
    {

        private BaseParametersFactory factory;
        private Dictionary<string, ValueStorage> containers = new Dictionary<string, ValueStorage>();

        public ValuesContainerStorage(BaseParametersFactory factory)
        {
            this.factory = factory;
        }

        public ResultType Fetch<ResultType>(string identifier)
        {
            if (containers.ContainsKey(identifier) == false)
            {
                containers[identifier] = factory.Make(identifier);
            }
            IValueContainer result = containers[identifier].currentContainer;
            Assert.IsTrue(result is ResultType);
            return (ResultType)result;
        }

    }

}