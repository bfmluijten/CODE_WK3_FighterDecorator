namespace CODE_WK3_FighterDecorator.Model
{
    internal class StrengthenFighterDecorator : BaseFighterDecorator
    {
        public int PercentageStrengthend { get; set; }

        public StrengthenFighterDecorator(IFighter next, int PercentageStrengthend) : base(next)
        {
            this.PercentageStrengthend = PercentageStrengthend;
        }

        public override Attack Attack()
        {
            var attack = base.Attack();
            var addedValue = (int)(this.AttackValue * (PercentageStrengthend * 1.0 / 100));
            attack.Value += addedValue;
            attack.Messages.Add($"Increased attackvalue with an extra {PercentageStrengthend} % of our base attack: {addedValue}");
            return attack;
        }

        public override void Defend(Attack attack)
        {
            var addedValue = (int)(this.DefenseValue * (PercentageStrengthend * 1.0 / 100));
            DefenseValue += addedValue;
            attack.Messages.Add($"Increased defensevalue with an extra {PercentageStrengthend} % of our base defend: {addedValue}");
            base.Defend(attack);
            DefenseValue -= addedValue;
        }
    }
}