using GameCore;
using ParametersConstant;
public class PeopleStatisticsActivity : IActivity
{

    string IActivity.identifier => "PeopleStatisticsActivityIdentifier";

    private DoubleValueContainer numberOfDeaths;
    private DoubleValueContainer numberOfBirths;

    public bool CheckConditionsForStarting(GameContext context)
    {
        return true;
    }

    public void DidEnd(GameContext context)
    {
        // смерть
    }

    public void Load(GameContext context)
    {
        this.numberOfBirths = context.storage.Fetch<DoubleValueContainer>(GlobalBaseKey.numberOfBirths);
        this.numberOfDeaths = context.storage.Fetch<DoubleValueContainer>(GlobalBaseKey.numberOfDeaths);
    }

    public void Loop(GameContext context, int step, ActivityStopHandler stopHandler)
    {
        numberOfDeaths.value = context.deadPeopls.Count;
        numberOfBirths.value = context.bornPeopls.Count;
    }

    public void WillStart(GameContext context)
    {
        // создать стартовую популяцию
    }

}