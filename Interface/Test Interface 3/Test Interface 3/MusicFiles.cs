using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Interface_3
{
    class MusicFiles
    {
        public string Title {  get; private set; }
        public string Artist { get; private set; }
        public int YOR { get;private set; }
        public int DIS { get; private set; }

        public MusicFiles()
        {

        }
        public MusicFiles(string title, string artist, int yearOfRelease, int durationInSeconds)
        {
            Title = title;
            Artist = artist;
            YOR = yearOfRelease;
            DIS = durationInSeconds;
        }
       
    }
}
