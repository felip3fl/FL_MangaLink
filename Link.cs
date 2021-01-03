using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Download
{
    public class Link
    {
        public void AbrirLinks()
        {
            var partida = 10;
            var contador1 = 14274 + partida;
            var contador2 = 131 + partida;
            var quantidadeLinkParaGerar = 10;
            StringBuilder arquivo = new StringBuilder();

            for (int i = 0; i < quantidadeLinkParaGerar; i++)
            {
                var link = $"https://mangalivre.net/baixar/berserk/{contador1}/capitulo-{contador2}";
                arquivo.AppendLine(link);
                contador1++;
                contador2++;
                OpenUrl(link);
                Thread.Sleep(300);
            }

            //System.IO.File.WriteAllText(@"C:\Users\felip\Desktop\Download\Links.txt", arquivo.ToString());
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

    }
}
