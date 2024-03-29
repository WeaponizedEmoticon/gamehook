﻿using GameHook.Domain.Interfaces;
using GameHook.Domain.ValueTransformers;

namespace GameHook.Domain.Preprocessors
{
    public static partial class Preprocessors
    {
        public static MemoryAddress? dma_967d10cc(MemoryAddress memoryAddress, int size, int offset, MemoryAddressBlockResult memoryAddressBlockResult)
        {
            var dmaMemoryAddressBytes = memoryAddressBlockResult.GetRelativeAddress(memoryAddress, size);
            var dmaMemoryAddressValue = UnsignedIntegerTransformer.ToValue(dmaMemoryAddressBytes);

            // Check to see if the DMA pointer references 0x00.
            // This can happen if the game is in the middle of a reset.
            if (dmaMemoryAddressValue == 0)
            {
                return null;
            }

            return (MemoryAddress)(dmaMemoryAddressValue + offset);
        }
    }
}
