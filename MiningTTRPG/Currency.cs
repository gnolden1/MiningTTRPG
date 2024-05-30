namespace MiningTTRPG {
    public class Currency(uint copper) {
        public uint Copper { get; set; } = copper;

        public static Currency FromCopper(uint value)
        {
            return new Currency(value);
        }

        public static Currency FromSilver(uint value)
        {
            return new Currency(value * 10);
        }

        public static Currency FromGold(uint value)
        {
            return new Currency(value * 100);
        }
    }
}
