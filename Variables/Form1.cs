using System;
using System.IO;

namespace Variables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Environment
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Text = Environment.GetEnvironmentVariable(textBox1.Text);
            if (label1.Text == "") label1.Text = "Not found";
        }

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


        private void button4_Click(object sender, EventArgs e)
        {
            label12.Text = "";
            label12.Text = get_Env_Value(textBox6.Text);
            
        }


        private string get_Env_Value(string Key)
        {
            try
            {
                // Search for .env file in build location or use program location
                string envfilepath = Directory.GetCurrentDirectory() + @"\.env";
              
                if (!File.Exists(envfilepath))
                {
                    envfilepath = System.IO.Path.GetFullPath(@"..\..\..\") + @"\.env";
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


        private static void set_Env_File_Environment(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The file '{filePath}' does not exist.");

            foreach (var line in File.ReadAllLines(filePath))
            {
                // Skip empty lines and comments

                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                // Skip lines that are not key-value pairs
                var key_value_pairs = line.Split('=', 2);
                if (key_value_pairs.Length != 2)
                    continue;

                var key = key_value_pairs[0].Trim();
                var value = key_value_pairs[1].Trim();
                Environment.SetEnvironmentVariable(key, value);
            }
        }

        #endregion


    }
}
