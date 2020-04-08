using ParametersConstant;
using GameUtils;

namespace ParametersConstant
{
    public class PeopleBaseKey
    {
        public static string year = "year";
    }

}
public class PeopleBaseParametersFactoryFiller
{

    public static void Fill(BaseParametersFactory factory)
    {
        factory.AddElement(PeopleBaseKey.year, () => { return new DoubleValueContainer(); });
    }

}