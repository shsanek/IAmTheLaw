using GameCore;
public class BaseRunLoopBuilder
{

    public static RunLoop Build()
    {
        var globalFactory = new BaseParametersFactory();
        var peopleFactory = new BaseParametersFactory();
        GlobalBaseParametersFactoryFiller.Fill(globalFactory);
        PeopleBaseParametersFactoryFiller.Fill(peopleFactory);
        var context = new GameContext(globalFactory, peopleFactory);
        var activities = BaseActivitiesFactory.activities();
        var statisticActivities = BaseActivitiesFactory.activities();
        return new RunLoop(context, activities, statisticActivities);
    }

}