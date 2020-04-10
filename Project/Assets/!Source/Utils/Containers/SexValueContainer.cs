
namespace GameCore
{
    public enum SexValue
    {
        male,
        female
    };

    public class SexValueContainer : IValueContainer
    {

        public SexValue value = SexValue.male;
        void IValueContainer.ClearValue()
        {
            throw new System.NotImplementedException();
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
