using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;

namespace UniversalModManager
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string jsonString;
        private JObject getGame(string games, int index) {
            return (JObject)((JObject)JArray.Parse(games)[index]).GetValue("game");
        }
        private JObject getMod(JObject game, int index)
        {
            return (JObject)(((JArray)game.GetValue("mods"))[index]);
        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive, bool overwrite)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {

                string targetFilePath = Path.Combine(destinationDir, file.Name);
                if (File.Exists(targetFilePath) && overwrite) { File.Delete(targetFilePath); } 
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)                                         //onload
        {
            string[] lines = System.IO.File.ReadAllLines(@"data.json");
            jsonString = string.Join("",lines);
            int gameNumber;
            gameNumber = JArray.Parse(jsonString).Count();
            for (int gameNo = 0; gameNo < gameNumber; gameNo++) {
                gameSelectBox.Items.Add(getGame(jsonString, gameNo).GetValue("name"));
                gameSelectBox.Items.Remove("None Selected");
                /*for (int modNo = 0; modNo < ((JArray)(getGame(jsonString,gameNo).GetValue("mods"))).Count; modNo++) {
                    modSelectBox.Items.Add(getMod(getGame(jsonString,gameNo),modNo).GetValue("name"));
                }*/
            }
        }

        private void modSelectBox_SelectedIndexChanged(object sender, EventArgs e)                          //onvaluechange
        {

        }
            
        private void gameSelectBox_SelectedIndexChanged(object sender, EventArgs e)                         //onvaluechange
        {
            modSelectBox.Items.Clear();
            for (int modNo = 0; modNo < ((JArray)(getGame(jsonString, gameSelectBox.SelectedIndex).GetValue("mods"))).Count; modNo++)
            {
                modSelectBox.Items.Add(getMod(getGame(jsonString, gameSelectBox.SelectedIndex), modNo).GetValue("name"));
            }
        }

        private void applyButton_Click(object sender, EventArgs e)                                          //onclick
        {
            string dst = getGame(jsonString, gameSelectBox.SelectedIndex).GetValue("path").ToString();
            string src = getMod(getGame(jsonString, gameSelectBox.SelectedIndex), modSelectBox.SelectedIndex).GetValue("path").ToString();
            CopyDirectory(src,dst,true,true);
            Console.WriteLine("Applied");
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
            MessageBox.Show("Are You Sure? This Cannot Be Undone.");
        }

        private void deleteGameButton_Click(object sender, EventArgs e)                                     //onclick
        {
            Console.WriteLine("Clicked deleteG");
            MessageBox.Show("Are You Sure? This Cannot Be Undone.");
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

        private void setModArchiveButton_Click(object sender, EventArgs e)
        {
            string path;
            path = browseForFolder();
        }

    }
}
