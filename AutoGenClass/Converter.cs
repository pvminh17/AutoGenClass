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
        private DictionaryWord dicWord = new DictionaryWord("dicWord.txt", true);
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
                    string result = dDLtoJavaClass.Process(tboxSrc.Text, txtCusEntityName.Text.Trim());
                    tboxDes.Text = result;
                }
            }
            catch(Exception objex)
            {
                MessageBox.Show(objex.ToString(), objex.Message);
            }
        }

        private void ToIDAO_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tboxSrc.Text))
                {
                    DDLtoJavaClass dDLtoJavaClass = new DDLtoJavaClass();
                    string result = dDLtoJavaClass.ToIDAO(tboxSrc.Text, txtCusEntityName.Text.Trim());
                    tboxDes.Text = result;
                }
            }
            catch (Exception objex)
            {
                MessageBox.Show(objex.ToString(), objex.Message);
            }
        }

        private void buttonToDAOImpl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tboxSrc.Text))
                {
                    DDLtoJavaClass dDLtoJavaClass = new DDLtoJavaClass();
                    string result = dDLtoJavaClass.ToDAOImpl(tboxSrc.Text, txtCusEntityName.Text.Trim());
                    tboxDes.Text = result;
                }
            }
            catch (Exception objex)
            {
                MessageBox.Show(objex.ToString(), objex.Message);
            }
        }

        private void buttonToIService_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tboxSrc.Text))
                {
                    DDLtoJavaClass dDLtoJavaClass = new DDLtoJavaClass();
                    string result = dDLtoJavaClass.ToIService(tboxSrc.Text, txtCusEntityName.Text.Trim());
                    tboxDes.Text = result;
                }
            }
            catch (Exception objex)
            {
                MessageBox.Show(objex.ToString(), objex.Message);
            }
        }

        private void buttonToServiceImpl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tboxSrc.Text))
                {
                    DDLtoJavaClass dDLtoJavaClass = new DDLtoJavaClass();
                    string result = dDLtoJavaClass.ToServiceImpl(tboxSrc.Text, txtCusEntityName.Text.Trim());
                    tboxDes.Text = result;
                }
            }
            catch (Exception objex)
            {
                MessageBox.Show(objex.ToString(), objex.Message);
            }
        }

        private void buttonToRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tboxSrc.Text))
                {
                    DDLtoJavaClass dDLtoJavaClass = new DDLtoJavaClass();
                    string result = dDLtoJavaClass.ToRequest(tboxSrc.Text, txtCusEntityName.Text.Trim());
                    tboxDes.Text = result;
                }
            }
            catch (Exception objex)
            {
                MessageBox.Show(objex.ToString(), objex.Message);
            }
        }

        private void buttonToResponse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tboxSrc.Text))
                {
                    DDLtoJavaClass dDLtoJavaClass = new DDLtoJavaClass();
                    string result = dDLtoJavaClass.ToResponse(tboxSrc.Text, txtCusEntityName.Text.Trim());
                    tboxDes.Text = result;
                }
            }
            catch (Exception objex)
            {
                MessageBox.Show(objex.ToString(), objex.Message);
            }
        }

        private void btnAutoCamel_Click(object sender, EventArgs e)
        {
            txtAutoCamel.Text = dicWord.ToCamel(txtAutoCamel.Text.Trim());
        }
    }
}
