﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_WK3_FighterDecorator.Model
{
    public class FighterFactory
    {
        public Dictionary<string, string> FighterOptions { get; private set; }

        public const string DOUBLE_HANDED = "Double handed";
        public const string MINION = "Minion";
        public const string POISON = "Poison";
        public const string SHIELD = "Shield";
        public const string SHOTGUN = "Shotgun";
        public const string STRENGTHEN = "Strengthen";

        public FighterFactory()
        {
            FighterOptions = new Dictionary<string, string>();
            FighterOptions[DOUBLE_HANDED] = "A double handed sword for double attack and double defense.";
            FighterOptions[MINION] = "A little minion, adding attack and taking damage before the fighter does.";
            FighterOptions[POISON] = "A poison for 5 time attacks.";
            FighterOptions[SHIELD] = "Taking all your damase for 3 defenses.";
            FighterOptions[SHOTGUN] = "Adding attack, needs reloading every 2 times.";
            
            // TODO: Implement strengthen on fighter
            FighterOptions[STRENGTHEN] = "Increasing attack by 50%, increasing defense by 50%.";
        }

        public IFighter CreateFighter(int lives, int attack, int defense, IEnumerable<string> options)
        {
            IFighter fighter = new Fighter(lives, attack, defense);

            if (options.Contains(DOUBLE_HANDED)) fighter = new DoubleHandedFighterDecorator(fighter);
            if (options.Contains(MINION)) fighter = new MinionFighterDecorator(fighter, MinionLives: fighter.Lives / 2, MinionAttackValue: fighter.AttackValue / 2);
            if (options.Contains(POISON)) fighter = new PoisonFighterDecorator(fighter, PoisonStrength: 10);
            if (options.Contains(SHIELD)) fighter = new ShieldFighterDecorator(fighter, ShieldDefends: 3);
            if (options.Contains(SHOTGUN)) fighter = new ShotgunFighterDecorator(fighter);
            if (options.Contains(STRENGTHEN)) fighter = new StrengthenFighterDecorator(fighter, PercentageStrengthend: 50);

            return fighter;
        }
    }
}
