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

        public int Lives { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AttackValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DefenseValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
