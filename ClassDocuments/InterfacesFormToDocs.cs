using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AMAS_DBI;

namespace ClassInterfases
{
    public interface FormShowCon
    {
        ImageList imagelib();
        Panel panel();
        Class_syb_acc DB_acc();
        ToolStripProgressBar FuelBar();
    }

    public interface GSADR
    {
        int GSAddressID();
        string GSAddressString();
    }

    public interface GSORG
    {
        string GSOrgName();
        int GSOrgID();
    }
}
