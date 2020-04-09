using GameCore;
using System.Collections.Generic;
public class BaseStatisticActivitiesFactory
{

    public static IReadOnlyList<IActivity> activities()
    {
        List<IActivity> result = new List<IActivity>();

        result.Add(new PeopleStatisticsActivity());

        return result;
    }

}