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

        MusicFiles[] musicFiles;
        public int totalfiles { get; set; }

        public Phone()
        {
            musicFiles = new MusicFiles[100];
        }
        public Phone(string phonename, string phoneModel)
        {
            PhoneName = phonename;
            PhoneModel = phoneModel;
            musicFiles = new MusicFiles[100];
        }
        public void changeChannel()
        {
            Console.WriteLine("Chaneel Changed");
            
        }

        public void play(boolean on)
        {
            Console.WriteLine("Turnned on");
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
            for(loudness=0; loudness>=100; loudness++)
            {
                Console.WriteLine("Volume Increasd to {0} ", loudness);
            }
            for (loudness = 0; loudness >= 100; loudness--)
            {
                Console.WriteLine("Volume Decreased to {0} ", loudness);
            }

        }

        public void switching(boolean on)
        {
            Console.WriteLine("Switch is off");
           
        }
        public void ShowInfo()
        {
            Console.WriteLine("Phone Name: " + PhoneName);
            Console.WriteLine("Phone Model: " + PhoneModel);
        }
}
 }
