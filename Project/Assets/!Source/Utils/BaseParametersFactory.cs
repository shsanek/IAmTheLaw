using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace GameCore
{
    public class BaseParametersFactory
    {

        private List<ParameterContainer> containers = new List<ParameterContainer>();

        internal ValueStorage Make(string identifier)
        {
            foreach (ParameterContainer container in containers)
            {
                if (container.identifier == identifier)
                {
                    return new ValueStorage(container.storageConfig, 
                        new LocalDataSorage(),
                        () => { return (IValueContainer)container.maker(); });
                }
            }
            Assert.IsTrue(false);
            return default;
        }

        public void AddElement(string identifier, Func<object> maker, ValueStorageConfig storageConfig)
        {
            foreach (ParameterContainer container in containers)
            {
                Assert.IsTrue(container.identifier != identifier);
            }
            containers.Add(new ParameterContainer(identifier, maker, storageConfig));
        }

        public void AddElement(string identifier, Func<object> maker)
        {
            var storageConfig = ValueStorageConfig.NotSave;
            foreach (ParameterContainer container in containers)
            {
                Assert.IsTrue(container.identifier != identifier);
            }
            containers.Add(new ParameterContainer(identifier, maker, storageConfig));
        }

    }

    internal class ParameterContainer
    {

        internal string identifier;
        internal Func<object> maker;
        internal ValueStorageConfig storageConfig;

        internal ParameterContainer(string identifier, Func<object> maker, ValueStorageConfig storageConfig)
        {
            this.identifier = identifier;
            this.maker = maker;
            this.storageConfig = storageConfig;
        }

    }

}