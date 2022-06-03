using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
