using GameHook.Domain.Interfaces;

namespace GameHook.Domain.GameHookProperties
{
    public class IntegerProperty : GameHookProperty<int?>
    {
        public IntegerProperty(IGameHookContainer mapper, string identifier, PropertyFields fields)
            : base(mapper, identifier, fields)
        {
        }

        protected override byte[] FromValue(int? value)
        {
            throw new NotImplementedException();
        }

        protected override int? ToValue(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return null;
            }

            if (PlatformOptions.EndianType == EndianTypeEnum.BigEndian)
                Array.Reverse(bytes);

            byte[] value = new byte[8];
            Array.Copy(bytes, value, bytes.Length);

            return BitConverter.ToInt32(value, 0);
        }
    }
}