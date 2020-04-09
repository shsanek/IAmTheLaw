using System.Collections.Generic;
using UnityEngine.Assertions;

namespace GameCore
{
    public class RunLoop
    {

        public GameContext context;

        private List<ActivityExecutor> activityExecutors = new List<ActivityExecutor>();
        private List<ActivityExecutor> statisticExecutors = new List<ActivityExecutor>();

        public RunLoop(GameContext context, IReadOnlyList<IActivity> activities, IReadOnlyList<IActivity> statisticActivities)
        {
            this.context = context;
            foreach (var activity in activities)
            {
                this.AddActivity(activity);
            }
            foreach (var activity in statisticActivities)
            {
                this.AddStaticActivity(activity);
            }
        }
        internal void Step()
        {
            context.startStep();
            foreach (var executors in this.activityExecutors)
            {
                executors.Run(this.context);
            }
            context.endStep();
            foreach (var executors in this.statisticExecutors)
            {
                executors.Run(this.context);
            }
            this.context.currentStep++;
        }

        internal void AddActivity(IActivity activity)
        {
            Assert.IsFalse(ContainsWithIdentifier(activity.identifier, this.activityExecutors));
            this.activityExecutors.Add(new ActivityExecutor(activity));
        }

        internal void AddStaticActivity(IActivity activity)
        {
            Assert.IsFalse(ContainsWithIdentifier(activity.identifier, this.statisticExecutors));
            this.statisticExecutors.Add(new ActivityExecutor(activity));
        }

        private bool ContainsWithIdentifier(string identifier, List<ActivityExecutor> list)
        {
            foreach (var activity in list)
            {
                if (activity.identifier == identifier)
                {
                    return true;
                }
            }
            return false;
        }

    }

}