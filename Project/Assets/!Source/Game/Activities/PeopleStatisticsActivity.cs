using GameCore;
public class PeopleStatisticsActivity : IActivity
{

    string IActivity.identifier => "PeopleStatisticsActivityIdentifier";

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
    }

    public void Loop(GameContext context, int step, ActivityStopHandler stopHandler)
    {
        context.numberOfDeaths.value = context.deadPeopls.Count;
        context.numberOfBirths.value = context.bornPeopls.Count;
        context.numberOfPeopls.value = context.peopls.Count;
    }

    public void WillStart(GameContext context)
    {
        // создать стартовую популяцию
    }

}