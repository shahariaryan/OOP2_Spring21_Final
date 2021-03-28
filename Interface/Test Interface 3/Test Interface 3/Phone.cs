using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Interface_3
{


    class Phone : RadioPlayerInterface, MusicPlayerInterface
    {

        public string PhoneName { get; set; }
        public string PhoneModel { get; set; }
        public int Volume { get; set; }

        MusicFiles[] musicFiles;
        public int totalfiles { get; set; }

        public Phone()
        {
            
        }
        public Phone(string phonename, string phoneModel, int volume)
        {
            PhoneName = phonename;
            PhoneModel = phoneModel;
            Volume = volume;
            musicFiles = new MusicFiles[100];
        }
        public void AddMusicFile(params MusicFiles[] musicfiles)
        {
            foreach (MusicFiles m in musicfiles)
            {
                this.musicFiles[totalfiles++] = m;
            }
        }
            public void changeChannel()
        {
            Console.WriteLine("Chaneel Changed");

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

        public void retune(double frequency)
        {
            Console.WriteLine("The Frequency is Changed to {0} ", frequency);

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
