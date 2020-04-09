using GameCore;
public class PeoplsPopulationActivity : IActivity
{

    string IActivity.identifier => "PeoplsPopulationActivityIdentifier";

    public bool CheckConditionsForStarting(GameContext context)
    {
        return true;
    }

    public void DidEnd(GameContext context)
    {
        // смерть
    }

    public void Loop(GameContext context, int step, ActivityStopHandler stopHandler)
    {
        // регулировать популяцию
    }

    public void WillStart(GameContext context)
    {
        // создать стартовую популяцию
    }
}