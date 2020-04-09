// тут будут огранечения на контейнеры
using System;

namespace GameCore
{

    internal delegate void ValueContainerUpdateHandler();
    internal interface IValueContainer
    {

        void ClearValue();
        Byte[] ToBytes();
        void SetValueWithBytes(Byte[] input, int startIndex);

    }

}