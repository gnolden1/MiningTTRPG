namespace MiningTTRPG.MineProducts {
    public abstract class MineProduct(string name) {
        public string Name { get; } = name;

        public static List<MineProduct> LoadMineProducts()
        {
            List<MineProduct> mineProducts = [];
            List<Gemstone> gemstones = Gemstone.InitializeGemstones();

            mineProducts.AddRange(gemstones);
            mineProducts.AddRange(Metal.InitializeMetals(gemstones));
            mineProducts.AddRange(Stone.InitializeStones(gemstones));
            mineProducts.AddRange(ExoticMaterial.InitializeExoticMaterials(gemstones));

            return mineProducts;
        }
    }
}
