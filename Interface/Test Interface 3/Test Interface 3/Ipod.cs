using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Interface_3
{
    class Ipod : MusicPlayerInterface
    {
        public string IpodName { get; set; }
        public string IpodModel { get; set; }
        public int Volume { get; set; }
        MusicFiles[] musicFiles;
        public int totalfiles { get; set; }

        public Ipod()
        {
            
        }
        public Ipod(string ipodename, string ipodModel, int volume)
        {
            IpodName = ipodename;
            IpodModel = ipodModel;
            Volume = volume;
            musicFiles = new MusicFiles[100];
        }
        public void play(bool on)
        {
            if (on)
            {
                Console.WriteLine("off");

            }
            else
            {
                Console.WriteLine("on");
            }
        }
        public void playNext()
        {
            Console.WriteLine("Play the Next Music");
        }

        public void playPrevious()
        {
            Console.WriteLine("Play the Previous Music");
        }

        public void setVolume(int loudness)
        {
            if (loudness > Volume)
            {
                int newVolume = loudness + Volume;
                Console.WriteLine("Volume decreased by " + newVolume);
            }
            else if (loudness < Volume)
            {
                int newVolume = Volume - loudness;
                Console.WriteLine("Volume decreased by " + newVolume);
            }

        }

        public void switching(bool on)
        {
            if (on)
            {
                Console.WriteLine("off");

            }
            else
            {
                Console.WriteLine("on");
            }

        }
       

       
    }
}
