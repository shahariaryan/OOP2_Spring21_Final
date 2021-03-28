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

        MusicFiles[] musicFiles;
        public int totalfiles { get; set; }

        public Ipod()
        {
            musicFiles = new MusicFiles[100];
        }
        public Ipod(string ipodename, string ipodModel)
        {
            IpodName = ipodename;
            IpodModel = ipodModel;
            musicFiles = new MusicFiles[100];
        }
        public void play(boolean on)
        {
            
        }

        public void playNext()
        {
          
        }

        public void playPrevious()
        {
          
        }

        public void setVolume(int loudness)
        {
          
        }

        public void switching(boolean on)
        {
           
        }
    }
}
