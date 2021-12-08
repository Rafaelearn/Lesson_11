using System;

namespace Lab_12
{
    public class DecadeBuilding
    {
        private Building[] buildings = new Building[10];

        public Building this[int index]
        {
            get { return buildings[index]; }
            set {
                if (index < 0 || index >= buildings.Length)
                {
                    //throw
                    Console.WriteLine($"Not exist {index} - element");
                }
                else
                {
                    buildings[index] = value;
                }
            }
        }


    }
}
