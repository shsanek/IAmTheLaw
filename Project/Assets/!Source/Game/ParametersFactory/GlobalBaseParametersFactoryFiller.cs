using ParametersConstant;
using GameCore;

namespace ParametersConstant
{
    public class GlobalBaseKey
    {
        public static string numberOfDeaths = "numberOfDeaths";
        public static string numberOfBirths = "numberOfBirths";
        public static string numberOfPeopls = "numberOfPeopls";
        public static string probabilityDistributionMaleDeath = "ProbabilityDistributionOfMaleDeath";

    }

}

public class GlobalBaseParametersFactoryFiller
{

    public static void Fill(BaseParametersFactory factory)
    {
        factory.AddElement(GlobalBaseKey.numberOfDeaths, () => { return new DoubleValueContainer(); });
        factory.AddElement(GlobalBaseKey.numberOfBirths, () => { return new DoubleValueContainer(); });
        factory.AddElement(GlobalBaseKey.numberOfPeopls, () => { return new DoubleValueContainer(); });
        factory.AddElement(GlobalBaseKey.probabilityDistributionMaleDeath, () => { return new DistributionValueContainer(); });
    }

}