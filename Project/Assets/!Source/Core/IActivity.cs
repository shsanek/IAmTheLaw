
public interface IActivity
{

    void WillStart(GameContext context);
    void Loop(int iterationNumber);
    void DidEnd(GameContext context);

}