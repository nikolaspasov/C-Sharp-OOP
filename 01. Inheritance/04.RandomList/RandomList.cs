using System;
using System.Collections.Generic;
using System.Text;

namespace _04.RandomList
{
   public class RandomList:List<string>
    {
        private Random rnd;
        public string RandomString()
        {
            rnd = new Random();
            int index = rnd.Next(0, Count);

            string str = this[index];
            this.RemoveAt(index);
            return str;

        }
    }
}
