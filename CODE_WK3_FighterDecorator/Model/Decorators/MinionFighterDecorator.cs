using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_WK3_FighterDecorator.Model
{
    internal class MinionFighterDecorator : BaseFighterDecorator
    {
        public int MinionLives { get; set; }
        public int MinionAttackValue { get; set; }

        public MinionFighterDecorator(IFighter next, int MinionLives, int MinionAttackValue) : base(next)
        {
            this.MinionLives = MinionLives;
            this.MinionAttackValue = MinionAttackValue;
        }

        public override Attack Attack()
        {
            Attack attack = base.Attack();

            if (MinionLives > 0)
            {
                attack.Messages.Add("Minion helping the attack: " + MinionAttackValue);
                attack.Value += MinionAttackValue;
            }

            return attack;
        }

        public override void Defend(Attack attack)
        {
            if (MinionLives > 0)
            {
                int tmpLives = MinionLives;
                MinionLives -= Math.Max(0, attack.Value);
                attack.Value -= Math.Max(0, tmpLives - MinionLives);
                attack.Messages.Add("Minion defended from the attack: -" + attack.Value);
            }

            base.Defend(attack);
        }
    }
}
