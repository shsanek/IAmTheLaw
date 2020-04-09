namespace GameCore
{
    public class People
    {

        public readonly ValuesContainerStorage storage;

        public People(BaseParametersFactory factory)
        {
            this.storage = new ValuesContainerStorage(factory);
        }

    }

}