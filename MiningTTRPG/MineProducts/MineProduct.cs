namespace MiningTTRPG.MineProducts {
    public abstract class MineProduct {
        public static IEnumerable<MineProduct> LoadMineProducts()
        {
            List<MineProduct> mineProducts = [];
            List<Gemstone> gemstones = Gemstone.InitializeGemstones().ToList();

            mineProducts.AddRange(gemstones);
            mineProducts.AddRange(Metal.InitializeMetals(gemstones));
            mineProducts.AddRange(Stone.InitializeStones());

            return mineProducts;
        }
    }
}
