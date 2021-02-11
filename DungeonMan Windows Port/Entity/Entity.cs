using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMan_Windows_Port.Entity
{
    public class Entity
    {

        public int health, attack, defense, gold, xp;
        public String name;

        public Entity(int health, int attack, int defense)
        {
            this.health = health;
            this.attack = attack;
            this.defense = defense;



        }



        public virtual void fight(int damageDone, Entity enemy)
        {
            Console.WriteLine("{0} did {1} damage to {2}", name, attack, enemy.getName());
            enemy.health -= attack;

        }

        public int getHealth()
        {
            return health;
        }

        public int getAttack()
        {
            return attack;
        }

        public String getName()
        {
            return name;
        }



    }
}
