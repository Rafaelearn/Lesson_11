using System;

namespace Lab_12
{
    public class DecadeBuilding
    {
        private Building[] buildings = new Building[10];
        // Question about access modifiers
        public Building this[int index]
        {
            get {
                if (index < 0 || index >= buildings.Length)
                {
                    throw new ArgumentOutOfRangeException($"Not exist {index} - element");
                }
                return buildings[index];
            }
            set {
                if (index < 0 || index >= buildings.Length)
                {
                    throw new ArgumentOutOfRangeException($"Not exist {index} - element");
                }
                buildings[index] = value;
            }
        }


    }
}
