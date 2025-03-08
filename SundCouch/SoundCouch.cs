using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Chief
{
    public class AMASound
    {
        public void SoundHelp()
        {

            Assembly Assem = Assembly.GetExecutingAssembly();
            string[] r = Assem.GetManifestResourceNames();

            foreach (string r2 in r)
            {
                Console.WriteLine(r2);
            }

            ResourceManager rm = new ResourceManager("Chief.SplashForm.resx", Assembly.GetExecutingAssembly());

            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(directory + "\\..\\..\\Resources\\indoor1.wav");

            player.Play();
        }

    }
}
