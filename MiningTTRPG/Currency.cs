namespace MiningTTRPG {
    public class Currency(int copper) {
        public int Copper { get; set; } = copper;

        public Currency() : this(0) { }

        public static Currency FromCopper(int value)
        {
            return new Currency(value);
        }

        public static Currency FromSilver(int value)
        {
            return new Currency(value * 10);
        }

        public static Currency FromGold(int value)
        {
            return new Currency(value * 100);
        }

        public static Currency operator +(Currency a) => a;
        public static Currency operator -(Currency a) => new(-a.Copper);
        public static Currency operator +(Currency left, Currency right) => new(left.Copper + right.Copper);
        public static Currency operator -(Currency left, Currency right) => new(left.Copper - right.Copper);
        public static Currency operator *(Currency currency, int factor) => new(currency.Copper * factor);
        public static Currency operator *(Currency currency, decimal factor) => new((int)decimal.Round(currency.Copper * factor));
        public static Currency operator /(Currency currency, int factor) => new(currency.Copper / factor);
        public static Currency operator /(Currency currency, decimal factor) => new((int)decimal.Round(currency.Copper / factor));

    }
}
