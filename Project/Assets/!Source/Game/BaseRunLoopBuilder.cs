using GameCore;
public class BaseRunLoopBuilder
{

    public static RunLoop Build()
    {
        var globalFactory = new BaseParametersFactory();
        var peopleFactory = new BaseParametersFactory();
        var context = new GameContext();
        var activities = BaseActivitiesFactory.activities();
        var statisticActivities = BaseStatisticActivitiesFactory.activities();
        return new RunLoop(context, activities, statisticActivities);
    }

}