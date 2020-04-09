using System;

namespace GameCore
{
    public class DistributionValueContainer : IValueContainer
    {

        private double[] values;
        private double startValue;
        private double shift;

        public DistributionValueContainer()
        {
        }

        public void setValues(double shift, double[] values)
        {
            this.setValues(0, shift, values);
        }
        public void setValues(double startValue, double shift, double[] values)
        {
            this.shift = shift;
            this.startValue = startValue;
            this.values = values;
        }

        public double fetchValue(double x)
        {
            int index = Convert.ToInt32((x - startValue) / shift);
            if (index < values.Length)
            {
                return values[index];
            }
            return int.MinValue;
        }

        void IValueContainer.ClearValue()
        {
        }

        void IValueContainer.SetValueWithBytes(byte[] input, int startIndex)
        {
            throw new System.NotImplementedException();
        }

        byte[] IValueContainer.ToBytes()
        {
            throw new System.NotImplementedException();
        }
    }

}
