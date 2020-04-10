using System;
using System.Collections.Generic;

namespace GameCore
{
    public class DistributionValueContainer : IValueContainer
    {

        public double sum { get; private set; }

        private double[] values
        {
            get { return _values; }
            set
            {
                _values = value;
                sum = 0;
                foreach (var x in value)
                {
                    sum += x;
                }
            }
        }

        private double startValue;
        private double shift;

        private double[] _values;


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

        public double fetchRange(double normal)
        {
            var currentValue = normal * this.sum;
            double current = 0;
            for (int i = 0; i < this.values.Length; i++)
            {
                current += this.values[i];
                if (current >= currentValue)
                {
                    return Convert.ToDouble(i) * shift + startValue;
                }
            }
            return Convert.ToDouble(this.values.Length) * shift + startValue;
        }

        public void setDestibution<Object>(double shift, int count, IReadOnlyList<Object> list, Func<Object, double> handler)
        {
            this.setDestibution<Object>(0, shift, count, list, handler);
        }
        public void setDestibution<Object>(double start, double shift, int count, IReadOnlyList<Object> list, Func<Object, double> handler)
        {
            double[] values = new double[count];
            foreach(var obj in list)
            {
                var value = handler(obj);
                int index = Convert.ToInt32((value - startValue) / shift);
                if (index >= count)
                {
                    index = count - 1;
                }
                if (index < 0)
                {
                    index = 0;
                }
                values[index] = values[index] + 1;
            }
            this.shift = shift;
            this.startValue = start;
            this.values = values;
        }

        public void setDestibution(double shift, double[][] values)
        {
            this.setDestibution(0, shift, values);
        }

        public void setDestibution(double start, double shift, double[][] values)
        {
            List<double> result = new List<double>();
            var random = new Random();
            foreach(var container in values)
            {
                double range = container[0];
                double value = container[1];
                int n = Convert.ToInt32(range / shift);
                double[] ras = new double[n];
                double sum = 0.0;
                for (int i = 0; i < n; i++)
                {
                    ras[i] = 1.0 + random.NextDouble() / 2.0;
                    sum += ras[i];
                }
                for (int i = 0; i < n; i++)
                {
                    result.Add(ras[i] / sum * value);
                }
            }
            this.values = result.ToArray();
            this.shift = shift;
            this.startValue = start;
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
