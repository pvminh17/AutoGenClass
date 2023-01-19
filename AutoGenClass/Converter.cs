using AutoGenClass.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGenClass
{
    public partial class Converter : Form
    {
        public Converter()
        {
            InitializeComponent();
        }

        private void btnDLLtoJavaClass_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tboxSrc.Text))
                {
                    DDLtoJavaClass dDLtoJavaClass = new DDLtoJavaClass();
                    string result = dDLtoJavaClass.Process(tboxSrc.Text);
                    tboxDes.Text = result;
                }
            }
            catch(Exception objex)
            {
                MessageBox.Show(objex.ToString(), objex.Message);
            }
           
        }
    }
}
