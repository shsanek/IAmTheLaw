using GameUtils;

namespace GameCore
{
    public class People
    {

        public readonly ParametersContainer containers;

        public People(BaseParametersFactory factory)
        {
            this.containers = new ParametersContainer(factory);
        }

    }

}
