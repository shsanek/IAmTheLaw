namespace GameCore
{

    public delegate void ActivityStopHandler();
    public interface IActivity
    {
        public string identifier { get; }
        public bool CheckConditionsForStarting(GameContext context);
        public void WillStart(GameContext context);
        public void Loop(GameContext context, int step, ActivityStopHandler stopHandler);
        public void DidEnd(GameContext context);

    }

}