using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Resources;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection;
using System.Windows.Controls;

namespace Chief
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {

            AMASound snd = new AMASound();
            snd.SoundHelp();
            
            InitializeComponent();

        }

    }

    }

