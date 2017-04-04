using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace headless_ie
{
    public partial class frmMain : Form
    {
        private string _url;
        public frmMain(string url)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(url))
            {
                _url = url;
            }
            else
            {
                _url = "https://www.google.com";
            }
            wbMain.Url = new UriBuilder(_url).Uri;
            wbMain.ScriptErrorsSuppressed = true;
        }

        private void wbMain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            frmMain.ActiveForm.Text = wbMain.Document.Title;
            
            Uri uri = new UriBuilder(_url).Uri;
            if (uri.HostNameType == UriHostNameType.Dns)
            {
                string iconUrl = "http://" + uri.Host + "/favicon.ico";

                try
                {
                    WebRequest request = HttpWebRequest.Create(iconUrl);
                    WebResponse response = request.GetResponse();

                    Stream stream = response.GetResponseStream();
                    MemoryStream ms = new MemoryStream();
                    int count = 0;
                    do
                    {
                        byte[] buf = new byte[1024];
                        count = stream.Read(buf, 0, 1024);
                        ms.Write(buf, 0, count);
                    } while (stream.CanRead && count > 0);
                    var bm = new Bitmap(ms);
                    var icon = Icon.FromHandle(bm.GetHicon());
                    frmMain.ActiveForm.Icon = icon;
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
