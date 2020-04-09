using System.Collections.Generic;
using UnityEngine.Assertions;
using System;

namespace GameCore
{
    public class GameContext
    {

        public delegate void PeopleHandler(People people);
        public delegate bool PeopleFilter(People people);

        public readonly ValuesContainerStorage storage;

        public readonly int stepInYear = 4;
        public double stepLength { get { return 1.0 / Convert.ToDouble(this.stepInYear); } }
        public double currentYear { get { return this.stepLength / Convert.ToDouble(this.currentStep); } }
        public int currentStep { get; internal set; } = 0;

        public IReadOnlyList<People> allNewPeopls { get { return this._allNewPeopls; } }
        public IReadOnlyList<People> allRemovePeopls { get { return this._allRemovePeopls; } }
        public IReadOnlyList<People> peopls { get { return this._peopls; } }

        private BaseParametersFactory peopleParametersFactory;
        private List<People> newPeopls = new List<People>();
        private List<People> removePeopls = new List<People>();
        private int peopleHandlerCount = 0;
        private int peopleTransactionCount = 0;
        private List<PeopleHandler> handlers = new List<PeopleHandler>();
        private bool stateStep = true;

        private List<People> _allNewPeopls = new List<People>();
        private List<People> _allRemovePeopls = new List<People>();
        private List<People> _peopls = new List<People>();

        public GameContext(BaseParametersFactory globalParametersFactory, BaseParametersFactory peopleParametersFactory)
        {
            this.peopleParametersFactory = peopleParametersFactory;
            this.storage = new ValuesContainerStorage(globalParametersFactory);
        }

        public void Kill(People people)
        {
            Assert.IsTrue(this.stateStep);
            if (peopleHandlerCount == 0)
            {
                _peopls.Remove(people);
            }
            else
            {
                removePeopls.Add(people);
            }
            this._allRemovePeopls.Add(people);
        }

        public People AddPeople()
        {
            Assert.IsTrue(this.stateStep);
            var people = new People(this.peopleParametersFactory);
            if (peopleHandlerCount == 0)
            {
                _peopls.Add(people);
            }
            else
            {
                newPeopls.Add(people);
            }
            this._allNewPeopls.Add(people);
            return people;
        }

        internal void startStep()
        {
            this.removePeopls = new List<People>();
            this.removePeopls = new List<People>();
            this.stateStep = true;
        }

        internal void endStep()
        {
            this.stateStep = false;
        }

        public void PeoplsForeach(PeopleHandler handler)
        {
            this.peopleHandlerCount++;
            foreach (var people in this._peopls)
            {
                handler(people);
            }
            this.peopleHandlerCount--;
            if (this.peopleHandlerCount == 0)
            {
                foreach (var people in this.newPeopls)
                {
                    _peopls.Add(people);
                }
                foreach (var people in this.removePeopls)
                {
                    _peopls.Remove(people);
                }
                this.newPeopls = new List<People>();
                this.removePeopls = new List<People>();
            }
        }

        public List<People> FilterPeopls(PeopleFilter filter)
        {
            var result = new List<People>();
            foreach (var people in this._peopls)
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
            foreach (var people in this._peopls)
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
                this.PeoplsForeach((people) =>
                {
                    foreach (var handler in this.handlers)
                    {
                        handler(people);
                    }
                });

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