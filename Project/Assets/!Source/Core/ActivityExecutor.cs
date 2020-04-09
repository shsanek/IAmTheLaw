namespace GameCore
{
    internal class ActivityExecutor
    {

        private enum State
        {
            watingForStart,
            run,
            end
        }

        internal readonly string identifier;

        private IActivity activity;
        private State state = State.watingForStart;
        private int currentStep = 0;
        private bool isLoad = false;

        internal ActivityExecutor(IActivity activity)
        {
            this.identifier = activity.identifier;
            this.activity = activity;
        }

        internal void Run(GameContext context)
        {
            if (isLoad == false)
            {
                isLoad = true;
                this.activity.Load(context);
            }
            switch( this.state )
            {
                case State.end:
                    break;
                case State.watingForStart:
                    if (this.activity.CheckConditionsForStarting(context))
                    {
                        this.state = State.run;
                        this.activity.WillStart(context);
                        this.activity.Loop(context, 0, () => { this.state = State.end; });
                        this.currentStep++;
                    }
                    break;
                case State.run:
                    this.activity.Loop(context, this.currentStep, () => { this.state = State.end; });
                    this.currentStep++;
                    break;
            }
        }

    }

}