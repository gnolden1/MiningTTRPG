namespace MiningTTRPG.MineProducts {
    public class ExoticMaterial : NonGemstone {
        private ExoticMaterial(string name, uint[] outputs, List<(Gemstone, (int, int))>? byproducts) : base(name, outputs, byproducts)
        {

        }
        public static List<ExoticMaterial> InitializeExoticMaterials(IEnumerable<Gemstone> gemstones)
        {
            return
            [
                new ExoticMaterial("Coal",
                    [2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24],
                    [
                        (FindGemstone("Amber", gemstones), (51, 75)),
                        (FindGemstone("Jet", gemstones), (76, 100)),
                    ]
                ),
                new ExoticMaterial("Petroleum",
                    [5, 8, 11, 14, 17, 21, 24, 27, 30, 33, 36, 39],
                    [
                        (FindGemstone("Blue Calcite", gemstones), (51, 100)),
                    ]
                ),
                new ExoticMaterial("Radio-active Materials",
                    [9, 13, 17, 21, 25, 29, 33, 37, 41, 45, 49, 63],
                    null
                ),
            ];
        }
    }
}
