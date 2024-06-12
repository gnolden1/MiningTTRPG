using MiningTTRPG.MineProducts;
using System.Text;

namespace MiningTTRPG {
    public class Mine {
        private static Currency MinerCost => Currency.FromSilver(14);
        private static Currency ArtisanCost => Currency.FromGold(14);

        public Environment Environment { get; }
        public MineProduct MainProduct { get; }
        public Gemstone[] Byproducts { get; }
        public uint Quality { get; }
        public long Lifespan { get; set; }
        public uint Miners { get; set; }
        public uint SqFeetExcavated { get; set; }
        // Artisans if gemstones
        public uint Artisans { get; set; }
        // Smelter if metal
        public Smelter? Smelter { get; set; }
        // Equipment

        // Constructor

        public static string RollMine(Environment environment, Stone granite)
        {
            StringBuilder sb = new();
            DiceRoll d100 = new([100], []);

            MineProduct? product;
            List<Gemstone> byproducts = [];
            uint quality;
            long lifespan = 0;
            //uint miners;
            //uint sqFeetExcavated;
            //uint artisans;
            //Smelter smelter;

            int rollProductType = d100.Roll();
            int rollProduct = d100.Roll();

            sb.Append($"Rolled {rollProductType} for the product type, giving ");
            if (rollProductType <= 65)
            {
                // Stone
                sb.AppendLine(" stones.");
                if (rollProduct <= 60)
                    product = FindMineProduct("Granite", environment);
                else if (rollProduct <= 90)
                    product = FindMineProduct("Basalt", environment);
                else
                    product = FindMineProduct("Marble", environment);
            }
            else if (rollProductType <= 83)
            {
                // Metal
                sb.AppendLine(" metals.");
                if (rollProduct <= 5)
                    product = FindMineProduct("Lead", environment);
                else if (rollProduct <= 10)
                    product = FindMineProduct("Zinc", environment);
                else if (rollProduct <= 60)
                    product = FindMineProduct("Iron", environment);
                else if (rollProduct <= 70)
                    product = FindMineProduct("Tin", environment);
                else if (rollProduct <= 85)
                    product = FindMineProduct("Copper", environment);
                else if (rollProduct <= 90)
                    product = FindMineProduct("Silver", environment);
                else if (rollProduct <= 95)
                    product = FindMineProduct("Gold", environment);
                else if (rollProduct <= 97)
                    product = FindMineProduct("Platinum", environment);
                else if (rollProduct <= 99)
                    product = FindMineProduct("Mithril", environment);
                else
                    product = FindMineProduct("Adamantine", environment);
            }
            else if (rollProductType <= 93)
            {
                // Exotic material
                sb.AppendLine(" exotic materials.");
                if (rollProduct <= 60)
                    product = FindMineProduct("Coal", environment);
                else if (rollProduct <= 90)
                    product = FindMineProduct("Petroleum", environment);
                else
                    product = FindMineProduct("Radio-active Materials", environment);
            }
            else
            {
                // Gemstone
                sb.AppendLine(" gemstones.");
                if (rollProduct <= 15)
                    product = FindMineProduct("Aquamarine", environment);
                else if (rollProduct <= 30)
                    product = FindMineProduct("Blue Spinel", environment);
                else if (rollProduct <= 45)
                    product = FindMineProduct("Peridot", environment);
                else if (rollProduct <= 60)
                    product = FindMineProduct("Topaz", environment);
                else if (rollProduct <= 68)
                    product = FindMineProduct("Garnet", environment);
                else if (rollProduct <= 76)
                    product = FindMineProduct("Jacinth", environment);
                else if (rollProduct <= 84)
                    product = FindMineProduct("Opal", environment);
                else if (rollProduct <= 91)
                    product = FindMineProduct("Red Spinel", environment);
                else if (rollProduct <= 94)
                    product = FindMineProduct("Sapphire", environment);
                else if (rollProduct <= 96)
                    product = FindMineProduct("Emerald", environment);
                else if (rollProduct <= 98)
                    product = FindMineProduct("Ruby", environment);
                else
                    product = FindMineProduct("Diamond", environment);
            }

            sb.AppendLine($"Rolled {rollProduct} for the mine product, giving {(product == null ? "an invalid product." : product.Name)}.");
            if (product == null)
            {
                sb.AppendLine("The prospecting success was a false positive.");
                return sb.ToString();
            }

            if (product is NonGemstone nonGemstone && nonGemstone.Byproducts != null)
            {
                // Has byproducts
                Gemstone? byproduct1;
                Gemstone? byproduct2;
                int rollByproduct = d100.Roll();
                if (product.Name == "Granite" && rollByproduct >= 96 || product.Name == "Basalt" && rollByproduct >= 96)
                {
                    byproduct1 = RollByproduct(nonGemstone, d100.Roll());
                    byproduct2 = RollByproduct(nonGemstone, d100.Roll());
                    if (byproduct1 != null && byproduct2 != null && byproduct1.Name == byproduct2.Name)
                    {
                        byproducts.Add(byproduct1);
                    }
                    else
                    {
                        if (byproduct1 != null)
                            byproducts.Add(byproduct1);
                        if (byproduct2 != null)
                            byproducts.Add(byproduct2);
                    }
                }
                else if (product.Name == "Marble")
                {
                    //Stone granite = (Stone) MineProduct.LoadMineProducts().Where(x => x.Name == "Granite").First();
                    if (rollByproduct >= 96)
                    {
                        byproduct1 = RollByproduct(granite, d100.Roll());
                        byproduct2 = RollByproduct(granite, d100.Roll());
                        if (byproduct1 != null && byproduct2 != null && byproduct1.Name == byproduct2.Name)
                        {
                            byproducts.Add(byproduct1);
                        }
                        else
                        {
                            if (byproduct1 != null)
                                byproducts.Add(byproduct1);
                            if (byproduct2 != null)
                                byproducts.Add(byproduct2);
                        }
                    }
                    else if (rollByproduct >= 91)
                    {
                        if (d100.Roll() >= 96)
                        {
                            byproduct1 = RollByproduct(granite, d100.Roll());
                            byproduct2 = RollByproduct(granite, d100.Roll());
                            if (byproduct1 != null && byproduct2 != null && byproduct1.Name == byproduct2.Name)
                            {
                                byproducts.Add(byproduct1);
                            }
                            else
                            {
                                if (byproduct1 != null)
                                    byproducts.Add(byproduct1);
                                if (byproduct2 != null)
                                    byproducts.Add(byproduct2);
                            }
                        }
                        else
                        {
                            byproduct1 = RollByproduct(granite, d100.Roll());
                            if (byproduct1 != null)
                                byproducts.Add(byproduct1);
                        }
                    }
                }
                else
                {
                    byproduct1 = RollByproduct(nonGemstone, d100.Roll());
                    if (byproduct1 != null)
                        byproducts.Add(byproduct1);
                }
                sb.AppendLine($"The mine product has byproducts. The byproducts rolled {(byproducts.Count == 1 ? "was" : "were")} {(byproducts.Count == 0 ? "none" : string.Join(", ", byproducts.Select(x => x.Name)))}.");
            }

            DiceRoll lifespanDie = environment.FavoredMineProducts.Contains(product) ? new([100], []) : new([10], []);
            List<int> lifespanRolls = product.Name == "Coal" || product.Name == "Petroleum" ? [0, lifespanDie.Roll()] : [lifespanDie.Roll()];
            bool match;
            do
            {
                match = false;
                char[] lifespanChars = lifespanRolls.Last().ToString().ToCharArray();
                for (int i = 0; i < lifespanChars.Length - 1; i++)
                {
                    for (int j = i + 1; j < lifespanChars.Length; j++)
                        if (lifespanChars[j] == lifespanChars[i])
                        {
                            match = true;
                            lifespanRolls.Add(lifespanDie.Roll());
                            break;
                        }
                    if (match)
                        break;
                }
            } while (match && lifespanRolls.Count < 7);

            int[] lifespanMods = [1, 4, 48, 4800, 48000, 480000, 4800000];
            for (int i = 0; i < lifespanRolls.Count; i++)
            {
                lifespan += lifespanRolls[i] * lifespanMods[i];
            }
            sb.AppendLine($"Rolled for lifespan and got {string.Join(", ", lifespanRolls.Select(x => x.ToString()))} for a total lifespan of {lifespan} weeks.");

            quality = (uint) new DiceRoll([12], []).Roll();
            sb.AppendLine($"Rolled for quality and got {quality}.");

            return sb.ToString();
        }

        private static MineProduct? FindMineProduct(string name, Environment environment)
        {
            return environment.AvailableMineProducts.Where(x => x.Name == name).FirstOrDefault();
        }

        private static Gemstone? RollByproduct(NonGemstone product, int roll)
        {
            return product.Byproducts!.FirstOrDefault(x => x.Item2.Item1 <= roll && roll <= x.Item2.Item2).Item1;
        }
    }
}
