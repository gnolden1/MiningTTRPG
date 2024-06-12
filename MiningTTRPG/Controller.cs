using MiningTTRPG.MineProducts;

namespace MiningTTRPG {
    public class Controller {
        public static List<MineProduct> MineProducts { get; private set; } = MineProduct.LoadMineProducts();
        public static List<Environment> Environments { get; private set; } = Environment.InitializeEnvironments(MineProducts);
    }
}
