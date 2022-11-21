using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_WK3_FighterDecorator.Model
{
    internal class ShieldFighterDecorator : BaseFighterDecorator
    {
        public int ShieldDefends { get; set; }

        public ShieldFighterDecorator(IFighter next, int ShieldDefends) : base(next)
        {
            this.ShieldDefends = ShieldDefends;
        }

        public override void Defend(Attack attack)
        {
            if (ShieldDefends > 0)
            {
                attack.Messages.Add("Shield protected, attack value = 0");
                attack.Value = 0;
                ShieldDefends--;
            }
            else
            {
                base.Defend(attack);
            }
        }
    }
}
