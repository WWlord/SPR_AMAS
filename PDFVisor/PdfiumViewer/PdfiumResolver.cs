using System;
using System.Collections.Generic;
using System.Text;

namespace PdfiumViewer
{
    public class PdfiumResolver
    {
#pragma warning disable CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена
        public static event PdfiumResolveEventHandler Resolve;
#pragma warning restore CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена

        private static void OnResolve(PdfiumResolveEventArgs e)
        {
            Resolve?.Invoke(null, e);
        }

        internal static string GetPdfiumFileName()
        {
            var e = new PdfiumResolveEventArgs();
            OnResolve(e);
            return e.PdfiumFileName;
        }
    }
}
