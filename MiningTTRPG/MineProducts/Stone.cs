using System.Xml.Linq;

namespace MiningTTRPG.MineProducts {
    public class Stone : NonGemstone {
        private Stone(string name, uint[] outputs, List<(Gemstone, (int, int))>? byproducts) : base(name, outputs, byproducts)
        {

        }

        public static List<Stone> InitializeStones(IEnumerable<Gemstone> gemstones)
        {
            return
            [
                new Stone("Basalt",
                    [2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24],
                    [
                        (FindGemstone("Agate", gemstones), (51, 62)),
                        (FindGemstone("Obsidian", gemstones), (63, 75)),
                        (FindGemstone("Quartz", gemstones), (76, 85)),
                        (FindGemstone("Amethyst", gemstones), (86, 90)),
                        (FindGemstone("Fluorite", gemstones), (91, 95)),
                    ]
                ),
                new Stone("Granite",
                    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
                    [
                        (FindGemstone("Agate", gemstones), (51, 70)),
                        (FindGemstone("Bloodstone", gemstones), (71, 72)),
                        (FindGemstone("Carnelian", gemstones), (73, 75)),
                        (FindGemstone("Citrine", gemstones), (76, 78)),
                        (FindGemstone("Jasper", gemstones), (79, 81)),
                        (FindGemstone("Moonstone", gemstones), (82, 84)),
                        (FindGemstone("Onyx", gemstones), (85, 87)),
                        (FindGemstone("Tourmaline", gemstones), (88, 90)),
                        (FindGemstone("Zircon", gemstones), (91, 93)),
                        (FindGemstone("Fluorite", gemstones), (94, 95)),
                    ]
                ),
                new Stone("Marble",
                    [4, 8, 16, 32, 36, 40, 44 , 48, 52, 56, 60, 64],
                    [
                        (FindGemstone("Lapis Lazuli", gemstones), (51, 91)),
                    ]
                ),
            ];
        }
    }
}
