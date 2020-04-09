using GameCore;
using System.Collections.Generic;
public class BaseActivitiesFactory
{

    public static IReadOnlyList<IActivity> activities()
    {
        List<IActivity> result = new List<IActivity>();

        result.Add(new PeoplsPopulationActivity());

        return result;
    }

}