using GameCore;
using ParametersConstant;
public class PeopleStatisticsActivity : IActivity
{

    string IActivity.identifier => "PeopleStatisticsActivityIdentifier";

    private DoubleValueContainer numberOfDeaths;
    private DoubleValueContainer numberOfBirths;
    private DoubleValueContainer numberOfPeopls;

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
        this.numberOfPeopls = context.storage.Fetch<DoubleValueContainer>(GlobalBaseKey.numberOfPeopls);
    }

    public void Loop(GameContext context, int step, ActivityStopHandler stopHandler)
    {
        numberOfDeaths.value = context.deadPeopls.Count;
        numberOfBirths.value = context.bornPeopls.Count;
        numberOfPeopls.value = context.peopls.Count;
    }

    public void WillStart(GameContext context)
    {
        // создать стартовую популяцию
    }

}