namespace GameCore
{
    public class RunLoop
    {

        public GameContext context;

        public RunLoop(GameContext context)
        {
            this.context = context;
        }
        public void step()
        {
            foreach (var executors in context.activityExecutors)
            {
                executors.Run(this.context);
            }
            this.context.currentStep++;
        }

    }

}