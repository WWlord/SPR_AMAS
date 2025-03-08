using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using NAudio.Wave;
using System.Threading.Tasks;
using System.Threading;

namespace Chief
{
    public class AMASound
    {

        private ResourceManager rm;

        //private string killFile = string.Empty;
        private string Playfile = "";

        public void SoundHelp()
        {

            // ResourceManager rm = new ResourceManager("Chief.SplashForm.resx", Assembly.GetExecutingAssembly());

            rm = new ResourceManager(@"\Resound.resx", Assembly.GetExecutingAssembly());

            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\..\\..\\Resources";

            string[] sndfile = { "\\indoor1.wav", "\\indoor2.wav", "\\indoor3.wav", "\\interview1.wav", "\\interview2.wav" };

            int fi = 0;


            for (int i = 0; i < 5; i++)
            {
                Playfile = directory + sndfile[i];
                if (File.Exists(Playfile))
                {
                    fi = i;
                    break;
                }
            }

            if (sndfile[fi].Split('.').Last().ToLower().CompareTo("wav") >= 0)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Playfile);   //[resouns()]);
                player.Play();
            }
            else if (sndfile[fi].Split('.').Last().ToLower().CompareTo("mp3") >= 0)
            {

                string WavFile = "d:\\snd" + sndfile[fi].Split('.').First() + ".wav";

                using (var reader = new Mp3FileReader(Playfile))
                {
                    using (var writer = new WaveFileWriter(WavFile, reader.WaveFormat))
                    {
                        reader.CopyTo(writer);
                    }
                }
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(WavFile);   //[resouns()]);
                player.Play();

            }

        }

        public string[] resourses()
        {

            Assembly Assem = Assembly.GetExecutingAssembly();
            string[] lines = Assem.GetManifestResourceNames();

            return lines;
        }

        public int resouns()
        {

            string[] strg = resourses();

            string rs = "";
            int res = 0;

            try
            {
                ResourceManager rm = new ResourceManager(strg[0], Assembly.GetExecutingAssembly());
                rs = rm.GetString("SoundNum");
                res = Convert.ToInt32(rs);
            }
            catch { res = 0; }

            return res;
        }

        ~AMASound()
        {
            if (Playfile.CompareTo(string.Empty) != 0)
            {
                while (true)
                    try
                    {
                        if (File.Exists(Playfile))
                        {
                            //File.Delete(Playfile); разархивировать пир выпуске
                        }
                        break;
                    }
                    catch (IOException ex)
                    {
                        // Файл занят, ждем 1 секунду перед повторной попыткой
                        Thread.Sleep(1000);
                         int cnt=ex.Message.Length;
                    }
            }
        }

    }

}

