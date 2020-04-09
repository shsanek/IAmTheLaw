using System;

namespace GameCore
{
    internal interface IDataSorage
    {
        int Count();

        void RemoveFirst();
        void Add(Byte[] input);

        Byte[] Fetch(int inputWithIndex);

    }

}