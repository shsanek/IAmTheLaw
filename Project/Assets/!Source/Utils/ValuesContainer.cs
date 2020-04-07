using System;
using System.Collections.Generic;

// тут будут огранечения на контейнеры
public interface IValueContainer
{
}

public class ParametersContainer
{

    private Dictionary<string, IValueContainer> containers = new Dictionary<string, IValueContainer>();

    public ResultType fetch<ResultType>(string identifier, Func<ResultType> maker) where ResultType : IValueContainer
    {
        if (containers.ContainsKey(identifier) == false)
        {
            containers[identifier] = maker();
        }
        return (ResultType)this.containers[identifier];
    }

}