using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void wbMain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            frmMain.ActiveForm.Text = wbMain.Document.Title;
        }
    }
}
