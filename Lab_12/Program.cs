using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing of Indexer");
            DecadeBuilding decade = new DecadeBuilding();
            for (int i = 0; i < 11; i++)
            {
                decade[i] = new Building(height: 25 + i, numberStoreys: 5 + i, numberEntrance: 2 + i, numberFlats: 10 + i);
                Console.WriteLine(decade[i]);
            }
        }
    }
}
