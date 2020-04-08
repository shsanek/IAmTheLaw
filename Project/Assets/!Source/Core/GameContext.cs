using System.Collections.Generic;
using UnityEngine.Assertions;
using GameUtils;

namespace GameCore
{
    public class GameContext
    {

        public delegate void PeopleHandler(People people);
        public delegate bool PeopleFilter(People people);

        public readonly ParametersContainer global;

        public int stepInYear = 4;
        public int currentStep { get; internal set; } = 0;

        internal List<ActivityExecutor> activityExecutors = new List<ActivityExecutor>();

        private BaseParametersFactory peopleParametersFactory;
        private List<People> peopls = new List<People>();
        private List<People> newPeopls = new List<People>();
        private List<People> removePeopls = new List<People>();
        private int peopleHandlerCount = 0;
        private int peopleTransactionCount = 0;
        private List<PeopleHandler> handlers = new List<PeopleHandler>();

        public GameContext(BaseParametersFactory globalParametersFactory, BaseParametersFactory peopleParametersFactory)
        {
            this.peopleParametersFactory = peopleParametersFactory;
            this.global = new ParametersContainer(globalParametersFactory);
        }

        public void Kill(People people)
        {
            if (peopleHandlerCount == 0)
            {
                peopls.Remove(people);
            }
            else
            {
                removePeopls.Add(people);
            }
        }

        public People AddPeople()
        {
            var people = new People(this.peopleParametersFactory);
            if (peopleHandlerCount == 0)
            {
                peopls.Add(people);
            }
            else
            {
                newPeopls.Add(people);
            }
            return people;
        }

        public void PeoplsForeach(PeopleHandler handler)
        {
            this.peopleHandlerCount++;
            foreach (var people in this.peopls)
            {
                handler(people);
            }
            this.peopleHandlerCount--;
            if (this.peopleHandlerCount == 0)
            {
                foreach (var people in this.newPeopls)
                {
                    peopls.Add(people);
                }
                foreach (var people in this.removePeopls)
                {
                    peopls.Remove(people);
                }
                this.newPeopls = new List<People>();
                this.removePeopls = new List<People>();
            }
        }

        public List<People> FilterPeopls(PeopleFilter filter)
        {
            var result = new List<People>();
            foreach (var people in this.peopls)
            {
                if (filter(people))
                {
                    result.Add(people);
                }
            }
            return result;
        }

        public People SearchPeopl(PeopleFilter filter)
        {
            foreach (var people in this.peopls)
            {
                if (filter(people))
                {
                    return people;
                }
            }
            return null;
        }

        public void AddPeopleHandlerInTransaction(PeopleHandler handler)
        {
            this.handlers.Add(handler);
        }

        public bool ContainsWithIdentifier(string identifier)
        {
            foreach (var activity in activityExecutors)
            {
                if (activity.identifier == identifier)
                {
                    return true;
                }
            }
            return false;
        }

        internal void AddActivity(IActivity activity)
        {
            Assert.IsFalse(ContainsWithIdentifier(activity.identifier));
            this.activityExecutors.Add(new ActivityExecutor(activity));
        }

        internal void BeginPeopleHandlingTransaction()
        {
            this.peopleTransactionCount++;
        }

        internal void CommitPeopleHandlingTransaction()
        {
            this.peopleTransactionCount--;
            Assert.IsTrue(this.peopleTransactionCount >= 0);
            if (this.peopleTransactionCount == 0)
            {
                void handler(People people)
                {
                    foreach (var handler in this.handlers)
                    {
                        handler(people);
                    }
                }
                this.PeoplsForeach(handler);
                this.handlers = new List<PeopleHandler>();
            }
            if (this.peopleTransactionCount < 0)
            {
                this.peopleTransactionCount = 0;
            }
        }

        internal void CommitAllPeopleHandlingTransactions()
        {
            Assert.IsTrue(this.peopleTransactionCount != 0);
            while (this.peopleTransactionCount > 0)
            {
                this.CommitPeopleHandlingTransaction();
            }
            if (this.peopleTransactionCount < 0)
            {
                this.peopleTransactionCount = 0;
            }
        }

    }

}