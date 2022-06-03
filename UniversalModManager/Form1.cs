using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalModManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)                                         //onload
        {

        }

        private void modSelectBox_SelectedIndexChanged(object sender, EventArgs e)                          //onvaluechange
        {

        }
            
        private void gameSelectBox_SelectedIndexChanged(object sender, EventArgs e)                         //onvaluechange
        {

        }

        private void applyButton_Click(object sender, EventArgs e)                                          //onclick
        {
            Console.WriteLine("Clicked Apply");
        }

        private void importGameButton_Click(object sender, EventArgs e)                                     //onclick
        {
            Console.WriteLine("Clicked importG");
            string path;
            path = browseForFolder();
        }

        private void importModButton_Click(object sender, EventArgs e)                                      //onclick
        {
            Console.WriteLine("Clicked importM");
            string path;
            path = browseForFolder();
        }

        private void deleteModButton_Click(object sender, EventArgs e)                                      //onclick
        {
            Console.WriteLine("Clicked deleteM");
        }

        private void deleteGameButton_Click(object sender, EventArgs e)                                     //onclick
        {
            Console.WriteLine("Clicked deleteG");
        }
        

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private string browseForFolder()
        {
            if (browseForFolderPopup.ShowDialog() == DialogResult.OK)
            {
                return browseForFolderPopup.SelectedPath;
            } 
            else 
            {
                return "";
            }
        }
    }
}
