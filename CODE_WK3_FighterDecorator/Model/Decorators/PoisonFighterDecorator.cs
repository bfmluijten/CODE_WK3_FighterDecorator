using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_WK3_FighterDecorator.Model
{
    internal class PoisonFighterDecorator : BaseFighterDecorator
    {
        public int PoisonStrength { get; set; }

        public PoisonFighterDecorator(IFighter next, int PoisonStrength) : base(next)
        {
            this.PoisonStrength = PoisonStrength;
        }

        public override Attack Attack()
        {
            Attack attack = base.Attack();

            if (PoisonStrength > 0)
            {
                attack.Messages.Add("Poison weakening, current value: " + PoisonStrength);
                attack.Value += PoisonStrength;
                PoisonStrength -= 2;
            }
            else
            {
                attack.Messages.Add("Poison ran out.");
            }

            return attack;
        }
    }
}
