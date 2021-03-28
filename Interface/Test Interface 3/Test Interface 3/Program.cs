using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Interface_3
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicFiles m1 = new MusicFiles("Abc", "AVVV", 2020, 130);
            MusicFiles m2 = new MusicFiles("Asssc", "AAAVVV", 2019, 120);


            Phone p1 = new Phone("iPhone","11s",50);
            p1.AddMusicFile(m1,m2);
            

        }
    }
}
