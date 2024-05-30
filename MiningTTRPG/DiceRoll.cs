namespace MiningTTRPG {
    public class DiceRoll(List<uint> dice, List<int> modifiers) {
        private static readonly Random _random = new();
        public List<uint> Dice { get; set; } = dice;
        public List<int> Modifiers { get; set; } = modifiers;

        public int Roll()
        {
            return Dice.Select(x => _random.Next((int)x + 1)).Sum() + Modifiers.Sum();
        }
    }
}
