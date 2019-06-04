using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    class DiceRoller
    {
        protected int numDice;
        protected int dieSize;

        public DiceRoller(int numDice, int dieSize)
        {
            this.numDice = numDice;
            this.dieSize = dieSize;
        }

        public List<int> roll()
        {
            List<int> numbers = new List<int>();
            Random r = new Random();
            for(int i = 0; i < this.numDice; i++)
            {
                numbers.Add(r.Next(1, this.dieSize));
            }
            return numbers;
        }
    }
}
