using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace GameUtils
{
    // тут будут огранечения на контейнеры
    public interface IValueContainer
    {
    }

    public class ParametersContainer
    {

        private BaseParametersFactory factory;
        private Dictionary<string, IValueContainer> containers = new Dictionary<string, IValueContainer>();

        public ParametersContainer(BaseParametersFactory factory)
        {
            this.factory = factory;
        }

        public ResultType Fetch<ResultType>(string identifier) where ResultType : IValueContainer
        {
            if (containers.ContainsKey(identifier) == false)
            {
                containers[identifier] = factory.Make<ResultType>(identifier);
            }
            IValueContainer result = containers[identifier];
            Assert.IsTrue(result is ResultType);
            return (ResultType)this.containers[identifier];
        }

    }

}