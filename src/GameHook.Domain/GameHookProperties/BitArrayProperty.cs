﻿using GameHook.Domain.Interfaces;
using System.Collections;

namespace GameHook.Domain.GameHookProperties
{
    public class BitArrayProperty : GameHookProperty<IEnumerable<bool>>
    {
        public BitArrayProperty(IGameHookContainer mapper, string identifier, PropertyFields fields)
            : base(mapper, identifier, fields)
        {
        }

        protected override byte[] FromValue(IEnumerable<bool>? value)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<bool> ToValue(byte[] bytes)
        {
            if (PlatformOptions.EndianType == EndianTypeEnum.LittleEndian)
            {
                Array.Reverse(bytes);
            }

            var bitArray = new BitArray(bytes);
            var boolArray = new bool[bitArray.Length];
            bitArray.CopyTo(boolArray, 0);

            return boolArray;
        }
    }
}