using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_WK3_FighterDecorator.Model
{
    internal class ShotgunFighterDecorator : BaseFighterDecorator
    {
        public int ShotgunRoundsFired { get; set; }

        public ShotgunFighterDecorator(IFighter next) : base(next)
        {
        }

        public override Attack Attack()
        {
            Attack attack = base.Attack();

            if (ShotgunRoundsFired < 2)
            {
                attack.Messages.Add("Shotgun: 20");
                attack.Value += 20;
                ShotgunRoundsFired++;
            }
            else
            {
                attack.Messages.Add("Shotgun reloading, no extra damage.");
                ShotgunRoundsFired = 0;
            }

            return attack;
        }
    }
}
