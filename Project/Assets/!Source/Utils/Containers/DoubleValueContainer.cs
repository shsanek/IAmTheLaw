using System;

namespace GameCore
{

    public class DoubleValueContainer : IValueContainer
    {

        public double value
        {
            get { return _value; }
            set
            {
                _value = value;
            }
        }
        private double _value = 0;

        byte[] IValueContainer.ToBytes()
        {
            return BitConverter.GetBytes(_value);
        }

        void IValueContainer.SetValueWithBytes(byte[] input, int startIndex)
        {
            BitConverter.ToDouble(input, startIndex);
        }

        void IValueContainer.ClearValue()
        {
            this._value = 0;
        }

    }

}