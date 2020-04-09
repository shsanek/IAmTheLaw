
namespace GameCore
{
    public struct ValueStorageConfig
    {

        public static ValueStorageConfig NotSave => new ValueStorageConfig(0, 0, 0);
        public static ValueStorageConfig Statistic => new ValueStorageConfig(0, 1, 0);

        // если 0 то сохранение в историю не происходит ни когда если 1 то каждый шаг и тп
        public readonly int numberOfStepsForSave;

        // если 0 то очистка никогда не происходит если 1 один то каждый шаг (для счетчиков) и тп
        public readonly int numberOfStepsForClear;

        /// если 0 то ограничения нет если 2 то будет хранить только 2 значения и тп
        public readonly int maxSaveValue;

        public ValueStorageConfig(int numberOfStepsForSave, int numberOfStepsForClear, int maxSaveValue)
        {
            this.maxSaveValue = maxSaveValue;
            this.numberOfStepsForClear = numberOfStepsForClear;
            this.numberOfStepsForSave = numberOfStepsForSave;
        }

    }

}