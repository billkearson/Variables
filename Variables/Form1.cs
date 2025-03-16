using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Variables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Environment

        // Get the environment variable if it is present. 
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Text = Environment.GetEnvironmentVariable(textBox1.Text);
            if (label1.Text == "") label1.Text = "Not found";
        }

        // Set or create the environment variable to the desired target.
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label2.Text = "";
                switch (comboBox1.Text)
                {
                    case "Process":
                        Environment.SetEnvironmentVariable(textBox2.Text, textBox3.Text, EnvironmentVariableTarget.Process);
                        break;

                    case "Machine":
                        Environment.SetEnvironmentVariable(textBox2.Text, textBox3.Text, EnvironmentVariableTarget.Machine);
                        break;

                    case "Null":
                        Environment.SetEnvironmentVariable(textBox2.Text, null);
                        break;

                    default:
                        Environment.SetEnvironmentVariable(textBox2.Text, textBox3.Text, EnvironmentVariableTarget.User);
                        break;
                }
                label2.Text = "Ok";
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
            }
        }

        #endregion

        #region .env


        // Get the environment variables from the .env file location provided. 
        private void button3_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            label8.Text = get_Env_Value(textBox4.Text, textBox5.Text);
        }

        // Get the environment variables from the .env file located in the project folder. 
        private void button4_Click(object sender, EventArgs e)
        {
            label12.Text = "";
            label12.Text = get_Env_Value(textBox6.Text);

        }

        // Select .env file to use
        private void button5_Click(object sender, EventArgs e)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter to only show .env files
            openFileDialog.Filter = "Environment Files (*.env)|*.env";
            openFileDialog.Title = "Select a .env file";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path of the selected file and show it in the textbox
                string filePath = openFileDialog.FileName;
                textBox5.Text = filePath;

            }

        }

        // Method to get the environment variable from the .env file. 
        private string get_Env_Value(string Key, string FilePath = @"C:\ENV\prod.env")
        {
            string envfilepath = string.Empty;
            List<string> filepaths = new List<string>()
            {
                FilePath,
                Directory.GetCurrentDirectory() + @"\.env",
                System.IO.Path.GetFullPath(@"..\..\..\..\") + @"\.env",
                System.IO.Path.GetFullPath(@"..\..\..\") + @"\.env",
                System.IO.Path.GetFullPath(@"..\..\") + @"\.env",
                System.IO.Path.GetFullPath(@"..\") + @"\.env"

            };

            try
            {
                // Search for .env file in build location or use program location
                foreach (string filepath in filepaths)
                {
                    if (File.Exists(filepath))
                    {
                        envfilepath = filepath;
                        break;
                    }

                }

                foreach (var line in File.ReadAllLines(envfilepath))
                {   // Skip empty lines and comments
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;

                    // Skip lines that are not key value pairs with an = sign
                    var key_value_pairs = line.Split('=', 2);
                    if (key_value_pairs.Length != 2)
                        continue;

                    // If case sensative key found return the value
                    if (key_value_pairs[0].Trim() == Key)
                    {
                        return key_value_pairs[1].Trim();
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Not found";

        }


        #endregion
                       
    }
}
