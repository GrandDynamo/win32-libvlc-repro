using LibVLCSharp.Shared;
using System;

namespace LibVLCSharp.Windows.Net40.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Core.Initialize();

            using var libVLC = new LibVLC();
            using var media = new Media(libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            using var mp = new MediaPlayer(media);
            mp.Play();

            //Console.ReadKey();

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                // Check if key M was pressed.
                if (keyinfo.Key == ConsoleKey.M)
                {
                    if (mp.Mute) // Check if video is muted.
                    {
                        mp.Mute = false; // Unmute video.
                        Console.WriteLine("Unmuted Video");
                    }
                    else
                    {
                        mp.Mute = true; // Mute video.
                        Console.WriteLine("Muted Video");
                    }
                }
            }
            while (keyinfo.Key != ConsoleKey.X);
        }
    }
}
