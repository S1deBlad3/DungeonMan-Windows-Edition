using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMan_Windows_Port.Items.Weapons
{
    public class AdvancedSword : Items
    {

        public static int advancedSwordAmount;

        public AdvancedSword(int cost = 50, int damage = 15, int rarity = 0, int amount = 1) : base(cost, damage, rarity, amount)
        {
            base.cost = cost;
            base.damage = damage;
            base.rarity = rarity;

            base.Name = "Advanced Sword";

            base.ID = 1;
        }

        public AdvancedSword(int amount) : base(amount)
        {
            base.cost = 50;
            base.damage = 15;
            base.rarity = 0;
            base.Amount = amount;

            base.Name = "Advanced Sword";

            base.ID = 1;
        }
    }
}
