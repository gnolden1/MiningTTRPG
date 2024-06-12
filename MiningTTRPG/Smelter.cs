namespace MiningTTRPG {
    public class Smelter {
        private static Smelter[]? Smelters { get; set; } = null;

        public string Name { get; }
        public uint Size { get; }
        public uint Efficiency => BaseEfficiency + ModEfficiency;
        private uint BaseEfficiency {  get; }
        private uint ModEfficiency { get; set; }
        public uint Capacity => BaseCapacity + ModCapacity;
        private uint BaseCapacity { get; }
        private uint ModCapacity { get; set; }
        public Currency Cost => BaseCost * (1 - ModCost);
        private Currency BaseCost { get; }
        private decimal ModCost { get; set; }
        public Currency Maintenance => BaseMaintenance * (1 - ModMaintenance);
        private Currency BaseMaintenance { get; }
        private decimal ModMaintenance { get; }

        private Smelter(string name, uint size, uint efficiency, uint capacity, Currency cost, Currency maintenance)
        {
            Name = name;
            Size = size;
            BaseEfficiency = efficiency;
            ModEfficiency = 0;
            BaseCapacity = capacity;
            ModCapacity = 0;
            BaseCost = cost;
            ModCost = new();
            BaseMaintenance = maintenance;
            ModMaintenance = new();
        }

        public static void InitializeSmelters()
        {
            if (Smelters != null)
                return;

            Smelters =
            [
                new(
                    "Bloomery",
                    1, 20, 10,
                    Currency.FromGold(0), Currency.FromGold(0)
                ),
                new(
                    "Blast Furnace I",
                    2, 30, 20,
                    Currency.FromGold(1000), Currency.FromGold(50)
                ),
                new(
                    "Blast Furnace II",
                    2, 35, 40,
                    Currency.FromGold(2500), Currency.FromGold(125)
                ),
                new(
                    "Blast Furnace III",
                    3, 40, 70,
                    Currency.FromGold(5000), Currency.FromGold(250)
                ),
                new(
                    "Blast Furnace IV",
                    4, 45, 120,
                    Currency.FromGold(8000), Currency.FromGold(400)
                ),
                new(
                    "Blast Furnace V",
                    5, 55, 250,
                    Currency.FromGold(15000), Currency.FromGold(750)
                ),
                new(
                    "Blast Furnace VI",
                    6, 65, 300,
                    Currency.FromGold(20000), Currency.FromGold(800)
                ),
                new(
                    "Blast Furnace VII",
                    7, 75, 360,
                    Currency.FromGold(30000), Currency.FromGold(900)
                ),
                new(
                    "Blast Furnace VIII",
                    8, 85, 430,
                    Currency.FromGold(35000), Currency.FromGold(1050)
                ),
                new(
                    "Blast Furnace IX",
                    9, 95, 470,
                    Currency.FromGold(45000), Currency.FromGold(1350)
                ),
                new(
                    "Blast Furnace ",
                    10, 100, 500,
                    Currency.FromGold(50000), Currency.FromGold(1500)
                ),
            ];
        }

        public static Smelter? GetSmelter(uint rank)
        {
            return Smelters?[rank];
        }
    }
}
