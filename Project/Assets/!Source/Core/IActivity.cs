
public interface IActivity
{

    void willStart(GameContext context);
    void loop(int iterationNumber);
    void didEnd(GameContext context);

}