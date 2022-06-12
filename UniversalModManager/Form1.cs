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
            JArray gamesArr = JArray.Parse(games);
            JObject game = (JObject)gamesArr[index];
            return (JObject)(game).GetValue("game");
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
                    CopyDirectory(subDir.FullName, newDestinationDir, true, overwrite);
                }
            }
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
        private void refreshKnownJson() {
            string[] lines = System.IO.File.ReadAllLines(@"data.json");
            jsonString = string.Join("", lines);
        }
        private void Form1_Load(object sender, EventArgs e)                                                 //onload
        {
            refreshKnownJson();
            int gameNumber;
            gameNumber = JArray.Parse(jsonString).Count();
            for (int gameNo = 0; gameNo < gameNumber; gameNo++) {
                gameSelectBox.Items.Add(getGame(jsonString, gameNo).GetValue("name"));
                gameSelectBox.Items.Remove("None Selected");
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
        }
        private void importGameButton_Click(object sender, EventArgs e)                                     //onclick
        {
            string path = browseForFolder();
            string promptValue = Prompt.ShowDialog("Mod Name", "Mod Configuration");
            JObject savedGame = new JObject();
            savedGame.Add("name", promptValue);
            savedGame.Add("path", path);
            savedGame.Add("mods", new JArray());
            JObject finalGame = new JObject();
            finalGame.Add("game", (JToken)savedGame);
            JArray towrite = JArray.Parse(jsonString);
            towrite.Add((JToken)finalGame);
            System.IO.File.WriteAllText(@"data.json",towrite.ToString());
            refreshKnownJson();
            gameSelectBox.Items.Clear();
            for (int i = 0; i < JArray.Parse(jsonString).Count; i++)
            {
                gameSelectBox.Items.Add(getGame(jsonString, i).GetValue("name"));
            }
            
            
        }
        private void importModButton_Click(object sender, EventArgs e)                                      //onclick
        {
            string path = browseForFolder();
            string promptValue = Prompt.ShowDialog("Mod Name", "Mod Configuration");
            int selectedGame = gameSelectBox.SelectedIndex;
            JObject mod = new JObject();
            mod.Add("name", promptValue);
            mod.Add("path", path);
            JArray modList = ((JArray)(getGame(jsonString, selectedGame).GetValue("mods")));
            modList.Add((JToken)mod);
            JArray towrite = JArray.Parse(jsonString);
            JObject gameDataToWrite = getGame(jsonString, selectedGame);
            gameDataToWrite["mods"] = (JToken)modList;
            JObject gameToWrite = new JObject();
            gameToWrite.Add("game",(JToken)gameDataToWrite);
            towrite[selectedGame] = gameToWrite;
            System.IO.File.WriteAllText(@"data.json", towrite.ToString());
            refreshKnownJson();
            modSelectBox.Items.Clear();
            for (int i = 0; i < ((JArray)getGame(jsonString,selectedGame).GetValue("mods")).Count; i++)
            {
                modSelectBox.Items.Add(getMod(getGame(jsonString,selectedGame),i).GetValue("name"));
            }
        }
        private void deleteModButton_Click(object sender, EventArgs e)                                      //onclick
        {
            MessageBox.Show("Are You Sure? This Cannot Be Undone.");
            JObject db = getGame(jsonString, gameSelectBox.SelectedIndex);
            ((JArray)db.GetValue("mods")).Remove(modSelectBox.SelectedIndex);
        }
        private void deleteGameButton_Click(object sender, EventArgs e)                                     //onclick
        {
            MessageBox.Show("Are You Sure? This Cannot Be Undone.");
            JArray db = JArray.Parse(jsonString);
            db.Remove(gameSelectBox.SelectedIndex);
        }
        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        } 
    }
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
 