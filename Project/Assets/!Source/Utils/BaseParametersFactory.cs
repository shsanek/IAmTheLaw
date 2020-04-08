using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class BaseParametersFactory
{

    private List<ParameterContainer> containers = new List<ParameterContainer>();

    public ResultType Make<ResultType>(string identifier) where ResultType: IValueContainer
    {
        foreach (ParameterContainer container in containers)
        {
            if (container.identifier == identifier)
            {
                object result = container.maker();
                Assert.IsTrue(result is ResultType);
                return (ResultType)result;
            }
        }
        Assert.IsTrue(false);
        return default;
    }

    public void AddElement(string identifier, Func<IValueContainer> maker)
    {
        foreach (ParameterContainer container in containers)
        {
            Assert.IsTrue(container.identifier != identifier);
        }
        containers.Add(new ParameterContainer(identifier, maker));
    }

}

public class ParameterContainer
{

    internal string identifier;
    internal Func<IValueContainer> maker;

    internal ParameterContainer(string identifier, Func<IValueContainer> maker)
    {
        this.identifier = identifier;
        this.maker = maker;
    }

}