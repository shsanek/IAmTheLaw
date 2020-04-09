using System;

namespace GameCore
{
    internal class ValueStorage
    {

        internal delegate IValueContainer ContainerMaker();

        internal readonly IValueContainer currentContainer;
        private ValueStorageConfig config;
        private IDataSorage storage;

        internal ValueStorage(ValueStorageConfig config, IDataSorage storage, ContainerMaker maker)
        {
            this.currentContainer = maker();
            this.config = config;
            this.storage = storage;
        }

        internal void endStep(int stepIndex)
        {
            if (config.numberOfStepsForClear != 0 && stepIndex % config.numberOfStepsForClear == 0)
            {
                this.currentContainer.ClearValue();
            }
            if (config.numberOfStepsForSave != 0 && stepIndex % config.numberOfStepsForSave == 0)
            {
                this.storage.Add(this.currentContainer.ToBytes());
            }
            if (config.maxSaveValue != 0 && this.storage.Count() > config.maxSaveValue)
            {
                this.storage.RemoveFirst();
            }
        }

    }

}