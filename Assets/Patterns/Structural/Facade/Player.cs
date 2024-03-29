using System;

namespace Patterns.Structural.Facade
{
    [Serializable]
    public class Player : Hero
    {
        public int Mana;

        public Player(int health, int mana) : base(health)
        {
            Mana = mana;
        }
    }
}
