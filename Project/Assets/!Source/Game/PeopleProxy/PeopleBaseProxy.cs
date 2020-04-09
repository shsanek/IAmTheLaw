using GameCore;
using ParametersConstant;
public class PeopleBaseProxy
{

    public DoubleValueContainer year
    {
        get { return this.people.storage.Fetch<DoubleValueContainer>(PeopleBaseKey.year); }
    }

    private People people;

    public PeopleBaseProxy(People people)
    {
        this.people = people;
    }

}