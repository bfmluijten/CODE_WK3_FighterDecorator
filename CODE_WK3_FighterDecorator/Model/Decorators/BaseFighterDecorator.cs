using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_WK3_FighterDecorator.Model
{
    internal abstract class BaseFighterDecorator : IFighter
    {
        readonly IFighter next;

        public BaseFighterDecorator(IFighter next)
        {
            this.next = next;
        }

        public int AttackValue
        {
            get
            {
                return next.AttackValue;
            }

            set
            {
                next.AttackValue = value;
            }
        }

        public int DefenseValue
        {
            get
            {
                return next.DefenseValue;
            }

            set
            {
                next.DefenseValue = value;
            }
        }

        public int Lives
        {
            get
            {
                return next.Lives;
            }

            set
            {
                next.Lives = value;
            }
        }

        public virtual Attack Attack()
        {
            return next.Attack();
        }

        public virtual void Defend(Attack attack)
        {
            next.Defend(attack);
        }
    }
}
