using GameCore;
using GameUtils;
public class BaseContextBuilder
{

    public static GameContext Build()
    {
        var globalFactory = new BaseParametersFactory();
        var peopleFactory = new BaseParametersFactory();
        GlobalBaseParametersFactoryFiller.Fill(globalFactory);
        PeopleBaseParametersFactoryFiller.Fill(peopleFactory);
        var context = new GameContext(globalFactory, peopleFactory);
        return context;
    }

}