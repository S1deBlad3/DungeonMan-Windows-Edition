using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMan_Windows_Port.Entity.Enemy
{
    public class StandardEnemy : Entity
    {




        public StandardEnemy(int health, int attack, int defense) : base(health, attack, defense)
        {
            base.health = health;
            base.attack = attack;
            base.defense = defense;

            base.name = "Gremlin";

            base.xp = 50;
            base.gold = 7;

        }


        public override void fight(int damageDone, Entity enemy)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("{0} did {1} damage to {2}", name, attack, enemy.getName());
            MainEntry.space();

            enemy.health -= attack;
            Console.ResetColor();


            MainEntry.space();
            getInfo();

        }

        public void dead()
        {
            health = 0;
            attack = 0;
            defense = 0;

            Console.WriteLine("{0} is dead forever", getName());


        }


        public void getInfo()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("{0} Has {1} Health and will attack for {2} damage.", getName(), getHealth(), getAttack());
            Console.ResetColor();
        }



    }
}
