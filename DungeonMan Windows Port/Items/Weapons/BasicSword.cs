using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMan_Windows_Port.Items.Weapons
{
    public class BasicSword : Items
    {

        public static int basicSwordAmount;

        public BasicSword(int cost = 30, int rarity = 0, int damage = 5, int amount = 1) : base(cost, damage, rarity, amount)
        {

            base.cost = cost;
            base.rarity = rarity;
            base.damage = damage;

            base.Name = "Basic Sword";
            base.ID = 0;


        }


        public BasicSword(int amount) : base(amount)
        {
            base.cost = 30;
            base.damage = 5;
            base.rarity = 0;
            base.Amount = amount;

            base.Name = "Basic Sword";

            base.ID = 1;
        }

        public override void Use()
        {
            base.Use();
        }


    }
}
