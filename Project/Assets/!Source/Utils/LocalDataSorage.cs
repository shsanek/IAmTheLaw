using System;
using System.Collections.Generic;

namespace GameCore
{
    public class LocalDataSorage : IDataSorage
    {

        private List<byte[]> bytes = new List<byte[]>();

        void IDataSorage.Add(byte[] input)
        {
            this.bytes.Add(input);
        }

        int IDataSorage.Count()
        {
            return this.bytes.Count;
        }

        byte[] IDataSorage.Fetch(int inputWithIndex)
        {
            return this.bytes[inputWithIndex];
        }

        void IDataSorage.RemoveFirst()
        {
            this.bytes.RemoveAt(0);
        }

    }

}