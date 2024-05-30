﻿namespace MiningTTRPG.MineProducts {
    public class Metal(string name, uint[] outputs, List<(Gemstone, (int, int))>? byproducts) : MineProduct 
    {
        public string Name { get; private set; } = name;
        public uint[] Outputs { get; private set; } = outputs;
        public List<(Gemstone, (int, int))>? Byproducts { get; private set; } = byproducts;

        public Currency GetValue(int roll) => Currency.FromGold(Outputs[roll]);

        public static IEnumerable<Metal> InitializeMetals(IEnumerable<Gemstone> gemstones)
        {
            return
            [
                new Metal("Adamantine",
                    [200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300],
                    null
                ),
                new Metal("Copper",
                    [10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65],
                    [
                        (gemstones.Where(x => x.Name == "Azurite").First(), (61, 66)),
                        (gemstones.Where(x => x.Name == "Malachite").First(), (67, 82)),
                        (gemstones.Where(x => x.Name == "Turquoise").First(), (83, 100)),
                    ]
                ),
                new Metal("Gold",
                    [35, 55, 77, 100, 120, 135, 155, 175, 200, 220, 235, 260],
                    null
                ),
                new Metal("Iron",
                    [4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37],
                    [
                        (gemstones.Where(x => x.Name == "Hematite").First(), (51, 71)),
                        (gemstones.Where(x => x.Name == "Rhodochrosite").First(), (72, 87)),
                        (gemstones.Where(x => x.Name == "Bloodstone").First(), (88, 90)),
                        (gemstones.Where(x => x.Name == "Carnelian").First(), (91, 93)),
                        (gemstones.Where(x => x.Name == "Chrysopidate").First(), (94, 96)),
                        (gemstones.Where(x => x.Name == "Alexandrite").First(), (97, 98)),
                        (gemstones.Where(x => x.Name == "Jade").First(), (99, 100)),
                    ]
                ),
                new Metal("Lead",
                    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
                    null
                ),
                new Metal("Mithril",
                    [150, 210, 280, 340, 410, 480, 550, 620, 690, 770, 830, 910],
                    null
                ),
                new Metal("Platinum",
                    [80, 130, 177, 225, 275, 320, 370, 420, 465, 560, 610, 660],
                    null
                ),
                new Metal("Silver",
                    [20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130],
                    null
                ),
                new Metal("Tin",
                    [7, 11, 15, 19, 23, 27, 31, 35, 39, 43, 47, 51],
                    null
                ),
                new Metal("Zinc",
                    [2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24],
                    null
                ),
            ];
        }
    }
}