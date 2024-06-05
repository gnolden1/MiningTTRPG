namespace MiningTTRPG.MineProducts {
    public abstract class NonGemstone(string name, uint[] outputs, List<(Gemstone, (int, int))>? byproducts) : MineProduct(name) {
        public uint[] Outputs { get; private set; } = outputs;
        public List<(Gemstone, (int, int))>? Byproducts { get; private set; } = byproducts;

        protected static Gemstone FindGemstone(string name, IEnumerable<Gemstone>gemstones)
        {
            return gemstones.Where(x => x.Name == name).First();
        }
    }
}
