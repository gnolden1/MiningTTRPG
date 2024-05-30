namespace MiningTTRPG.MineProducts {
    public class Gemstone(string name, Gemstone.GemstoneGroup group) : MineProduct {
        public enum GemstoneGroup { Ornamental, SemiPrecious, Fancy, Precious, Gems, Jewels }

        private static readonly Dictionary<GemstoneGroup, uint> _values = new()
        {
            { GemstoneGroup.Ornamental,     10 },
            { GemstoneGroup.SemiPrecious,   50 },
            { GemstoneGroup.Fancy,          100 },
            { GemstoneGroup.Precious,       500 },
            { GemstoneGroup.Gems,           1000 },
            { GemstoneGroup.Jewels,         5000 },
        };

        private static readonly Dictionary<GemstoneGroup, DiceRoll[]> _outputs = new()
        {
            {
                GemstoneGroup.Ornamental,
                [
                    new DiceRoll([8], []), 
                    new DiceRoll([8], [1]),
                    new DiceRoll([10], []),
                    new DiceRoll([10], [1]),
                    new DiceRoll([12], []),
                    new DiceRoll([6, 6], []),
                    new DiceRoll([6, 6], [1]),
                    new DiceRoll([6, 6], [2]),
                    new DiceRoll([6, 6], [3]),
                    new DiceRoll([6, 6], [4]),
                    new DiceRoll([6, 6], [5]),
                    new DiceRoll([6, 6], [6]),
                ]
            },
            {
                GemstoneGroup.SemiPrecious,
                [
                    new DiceRoll([6], []),
                    new DiceRoll([6], [1]),
                    new DiceRoll([8], []),
                    new DiceRoll([8], [1]),
                    new DiceRoll([8], [2]),
                    new DiceRoll([8], [2]),
                    new DiceRoll([8], [3]),
                    new DiceRoll([10], [1]),
                    new DiceRoll([6, 6], [3]),
                    new DiceRoll([6, 6], [4]),
                    new DiceRoll([6, 6], [5]),
                    new DiceRoll([6, 6], [6]),
                ]
            },
            {
                GemstoneGroup.Fancy,
                [
                    new DiceRoll([4],[]),
                    new DiceRoll([4],[1]),
                    new DiceRoll([6],[]),
                    new DiceRoll([6],[1]),
                    new DiceRoll([6],[2]),
                    new DiceRoll([8],[1]),
                    new DiceRoll([8],[2]),
                    new DiceRoll([8],[3]),
                    new DiceRoll([8],[1]),
                    new DiceRoll([10],[1]),
                    new DiceRoll([10],[2]),
                    new DiceRoll([12],[1]),
                ]
            },
            {
                GemstoneGroup.Precious,
                [
                    new DiceRoll([8], []),
                    new DiceRoll([8], [1]),
                    new DiceRoll([8], [2]),
                    new DiceRoll([8], [3]),
                    new DiceRoll([8], [4]),
                    new DiceRoll([8], [5]),
                    new DiceRoll([8], [6]),
                    new DiceRoll([8], [7]),
                    new DiceRoll([8], [8]),
                    new DiceRoll([8], [9]),
                    new DiceRoll([8], [10]),
                    new DiceRoll([8], [11]),
                ]
            },
            {
                GemstoneGroup.Gems,
                [
                    new DiceRoll([6], []),
                    new DiceRoll([6], [1]),
                    new DiceRoll([6], [2]),
                    new DiceRoll([6], [3]),
                    new DiceRoll([6], [4]),
                    new DiceRoll([6], [5]),
                    new DiceRoll([6], [6]),
                    new DiceRoll([6], [7]),
                    new DiceRoll([6], [8]),
                    new DiceRoll([6], [9]),
                    new DiceRoll([6], [10]),
                    new DiceRoll([6], [11]),
                ]
            },
            {
                GemstoneGroup.Jewels,
                [
                    new DiceRoll([4], []),
                    new DiceRoll([4], [1]),
                    new DiceRoll([4], [2]),
                    new DiceRoll([4], [3]),
                    new DiceRoll([4], [4]),
                    new DiceRoll([4], [5]),
                    new DiceRoll([4], [6]),
                    new DiceRoll([4], [7]),
                    new DiceRoll([4], [8]),
                    new DiceRoll([4], [9]),
                    new DiceRoll([4], [10]),
                    new DiceRoll([4], [11]),
                ]
            },
        };

        public string Name { get; private set; } = name;
        public GemstoneGroup Group { get; private set; } = group;
        public Currency Value => Currency.FromGold(_values[Group]);

        public int RollOutput(int quality) => _outputs[Group][quality].Roll();

        public static IEnumerable<Gemstone> InitializeGemstones()
        {
            return
            [
                new("Azurite", GemstoneGroup.Ornamental),
                new("Agate", GemstoneGroup.Ornamental),
                new("Blue Calcite", GemstoneGroup.Ornamental),
                new("Hematite", GemstoneGroup.Ornamental),
                new("Lapis Lazuli", GemstoneGroup.Ornamental),
                new("Malachite", GemstoneGroup.Ornamental),
                new("Obsidian", GemstoneGroup.Ornamental),
                new("Rhodocrosite", GemstoneGroup.Ornamental),
                new("Turquoise", GemstoneGroup.Ornamental),
                new("Bloodstone", GemstoneGroup.SemiPrecious),
                new("Carnelian", GemstoneGroup.SemiPrecious),
                new("Chrysoprase", GemstoneGroup.SemiPrecious),
                new("Citrine", GemstoneGroup.SemiPrecious),
                new("Jasper", GemstoneGroup.SemiPrecious),
                new("Moonstone", GemstoneGroup.SemiPrecious),
                new("Onyx", GemstoneGroup.SemiPrecious),
                new("Quartz Crystal", GemstoneGroup.SemiPrecious),
                new("Tourmaline", GemstoneGroup.SemiPrecious),
                new("Zircon", GemstoneGroup.SemiPrecious),
                new("Alexandrite", GemstoneGroup.Fancy),
                new("Amber", GemstoneGroup.Fancy),
                new("Amethyst", GemstoneGroup.Fancy),
                new("Fluorite", GemstoneGroup.Fancy),
                new("Jade", GemstoneGroup.Fancy),
                new("Jet", GemstoneGroup.Fancy),
                new("Aquamarine", GemstoneGroup.Precious),
                new("Blue Spinel", GemstoneGroup.Precious),
                new("Peridot", GemstoneGroup.Precious),
                new("Topaz", GemstoneGroup.Precious),
                new("Garnet", GemstoneGroup.Gems),
                new("Jacinth", GemstoneGroup.Gems),
                new("Opal", GemstoneGroup.Gems),
                new("Red Spinel", GemstoneGroup.Gems),
                new("Diamond", GemstoneGroup.Jewels),
                new("Emerald", GemstoneGroup.Jewels),
                new("Ruby", GemstoneGroup.Jewels),
                new("Sapphire", GemstoneGroup.Jewels),
            ];
        }
    }
}