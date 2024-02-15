namespace Console_RPG
{
    // Structs are useful for storing complex objects.
    struct Stats
    {
        public int speed;
        public int strength;
        public int defense;

        public Stats(int speed, int strength, int defense)
        {
            this.speed = speed;
            this.defense = defense;
            this.strength = strength;
        }
    }
}
