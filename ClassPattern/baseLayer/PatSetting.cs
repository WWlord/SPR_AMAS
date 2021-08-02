using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace ClassPattern.baseLayer
{
    sealed class PicLibSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue("100")]
        public int Zoom
        {
            get { return (int)this["Zoom"]; }
            set { this["Zoom"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("2")]
        public int RollDown
        {
            get { return (int)this["RollDown"]; }
            set { this["RollDown"] = value; }
        }
    }

}
