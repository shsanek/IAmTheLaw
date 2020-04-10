using GameCore;
using System;
public class PeoplsPopulationActivity : IActivity
{

    string IActivity.identifier => "PeoplsPopulationActivityIdentifier";

    public bool CheckConditionsForStarting(GameContext context)
    {
        return true;
    }

    public void DidEnd(GameContext context)
    {
    }

    public void Load(GameContext context)
    {
        double[] array = { 0.00827, 0.00072, 0.00045, 0.0004, 0.00036, 0.00029, 0.00031, 0.00028, 0.00027, 0.00025, 0.00029, 0.00032, 0.00034, 0.00039, 0.0005, 0.00068, 0.00091, 0.00107, 0.00126, 0.00143, 0.00178, 0.00207, 0.00215, 0.00235, 0.00261, 0.00291, 0.0033, 0.00366, 0.00382, 0.00406, 0.00493, 0.00544, 0.00586, 0.00619, 0.00647, 0.00727, 0.00778, 0.00791, 0.0081, 0.00797, 0.0085, 0.00842, 0.00876, 0.00887, 0.00894, 0.00998, 0.01047, 0.01148, 0.01145, 0.01234, 0.01377, 0.01443, 0.0151, 0.01577, 0.01722, 0.01925, 0.02057, 0.02174, 0.02363, 0.0256, 0.02858, 0.03038, 0.0331, 0.03326, 0.03539, 0.04026, 0.03691, 0.04608, 0.04192, 0.04451, 0.04984, 0.04858, 0.06436, 0.0615, 0.06732, 0.07744, 0.07664, 0.08441, 0.09107, 0.09691, 0.09977, 0.11009, 0.1216, 0.12696, 0.13796, 0.14673, 0.16266, 0.1745, 0.19, 0.20686, 0.23131, 0.24586, 0.26283, 0.27574, 0.32823, 0.31404, 0.33474, 0.3561, 0.37805, 0.4005, 0.42339, 0.4466, 0.47006, 0.49364, 0.51725, 0.54079, 0.56415, 0.58722, 0.60992, 0.63215, 0.65384, 1 };
        context.probabilityDistributionMaleDeath.setValues(1, array);
    }

    public void Loop(GameContext context, int step, ActivityStopHandler stopHandler)
    {
        // регулировать популяцию
        var random = new Random();
        context.PeoplsForeach((people) =>
        {
            if( random.NextDouble() <= context.probabilityDistributionMaleDeath.fetchValue(people.age.value))
            {
                context.Kill(people);
            }
            else
            {
                people.age.value += context.stepLength;
            }
        });
    }

    public void WillStart(GameContext context)
    {
        double[][] array = { new double[] { 1, 966 }, new double[] { 4, 3958 }, new double[] { 5, 4389 }, new double[] { 5, 3791 }, new double[] { 5, 3418 }, new double[] { 5, 3993 }, new double[] { 5, 6035 }, new double[] { 5, 6270 }, new double[] { 5, 5505 }, new double[] { 5, 5008 }, new double[] { 5, 4439 }, new double[] { 5, 4545 }, new double[] { 5, 4947 }, new double[] { 5, 3964 }, new double[] { 5, 2942 }, new double[] { 41, 3874 } };
        var ras = new DistributionValueContainer();
        ras.setDestibution(1.0, array);
        var random = new Random();
        for (int i = 0; i < 15000; i++)
        {
            var people = context.AddPeople();
            people.age.value = ras.fetchRange(random.NextDouble());
        }
    }
}