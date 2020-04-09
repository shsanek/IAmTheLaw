namespace GameCore
{

    public delegate void ActivityStopHandler();
    public interface IActivity
    {
        string identifier { get; }
        bool CheckConditionsForStarting(GameContext context);
        void Load(GameContext context);
        void WillStart(GameContext context);
        void Loop(GameContext context, int step, ActivityStopHandler stopHandler);
        void DidEnd(GameContext context);

    }

}