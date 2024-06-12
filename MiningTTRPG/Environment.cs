using MiningTTRPG.MineProducts;

namespace MiningTTRPG {
    public class Environment {
        public string Name { get; set; }
        public List<MineProduct> AvailableMineProducts {  get; private set; } 
        public List<MineProduct> FavoredMineProducts { get; private set; }
        public uint ProspectingDC { get; private set; }
        public uint TimeRequired { get; private set; }
        public uint SurfaceCovered { get; private set; }
        public uint DepositChance { get; private set; }

        private Environment(string name, List<MineProduct> availableMineProducts, List<MineProduct> favoredMineProducts, uint prospectingDC, uint timeRequired, uint surfaceCovered, uint depositChance)
        {
            Name = name;
            AvailableMineProducts = availableMineProducts;
            FavoredMineProducts = favoredMineProducts;
            ProspectingDC = prospectingDC;
            TimeRequired = timeRequired;
            SurfaceCovered = surfaceCovered;
            DepositChance = depositChance;
        }

        public static List<Environment> InitializeEnvironments(IEnumerable<MineProduct> mineProducts)
        {
            return [
                new("Desert",
                    [
                        FindMineProduct("Lead", mineProducts),
                        FindMineProduct("Zinc", mineProducts),
                        FindMineProduct("Iron", mineProducts),
                        FindMineProduct("Copper", mineProducts),
                        FindMineProduct("Gold", mineProducts),
                        FindMineProduct("Silver", mineProducts),
                        FindMineProduct("Coal", mineProducts),
                        FindMineProduct("Petroleum", mineProducts),
                        FindMineProduct("Radio-active Materials", mineProducts),
                    ],
                    [
                        FindMineProduct("Coal", mineProducts),
                        FindMineProduct("Petroleum", mineProducts),
                    ],
                    20, 1, 4, 10
                ),
                new("Hill",
                    [
                        .. mineProducts.Where(x => x is Metal && x.Name != "Mithril"),
                        FindMineProduct("Granite", mineProducts),
                        FindMineProduct("Marble", mineProducts),
                        .. mineProducts.Where(x => x is Gemstone),
                        FindMineProduct("Coal", mineProducts),
                        FindMineProduct("Radio-active Materials", mineProducts),
                    ],
                    [
                        .. mineProducts.Where(x => x is Metal),    
                    ],
                    15, 1, 2, 30
                ),
                new("Jungle",
                    [
                        FindMineProduct("Silver", mineProducts),
                        FindMineProduct("Gold", mineProducts),
                        FindMineProduct("Platinum", mineProducts),
                        .. mineProducts.Where(x => x is Gemstone y && (
                            y.Group == Gemstone.GemstoneGroup.Precious || 
                            y.Group == Gemstone.GemstoneGroup.Gems || 
                            y.Group == Gemstone.GemstoneGroup.Jewels
                        )),
                        .. mineProducts.Where(x => x is ExoticMaterial),
                    ],
                    [
                        .. mineProducts.Where(x => x is Gemstone),
                    ],
                    25, 2, 2, 15
                ),
                new("Mountain",
                    [
                        .. mineProducts.Where(x => !(x.Name == "Coal" || x.Name == "Petroleum")),
                    ],
                    [
                        .. mineProducts,    
                    ],
                    15, 1, 1, 30
                ),
                new("Plain",
                    [
                        FindMineProduct("Coal", mineProducts),
                        FindMineProduct("Petroleum", mineProducts),
                        FindMineProduct("Radio-active Materials", mineProducts),
                    ],
                    [
                        FindMineProduct("Coal", mineProducts),
                    ],
                    12, 2, 6, 26
                ),
                new("Volcanic Land",
                    [
                        FindMineProduct("Granite", mineProducts),
                        FindMineProduct("Basalt", mineProducts),
                        .. mineProducts.Where(x => x is Gemstone y && (
                            y.Group == Gemstone.GemstoneGroup.Gems || 
                            y.Group == Gemstone.GemstoneGroup.Jewels
                        )),
                    ],
                    [
                        FindMineProduct("Basalt", mineProducts),
                    ],
                    18, 1, 2, 35
                ),
            ];
        }

        private static MineProduct FindMineProduct(string name, IEnumerable<MineProduct> mineProducts)
        {
            Console.WriteLine($"Trying to find {name}");
            return mineProducts.Where(x => x.Name == name).First();
        }
    }
}
