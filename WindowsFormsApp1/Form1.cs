using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region variables

        private Client client = new Client();
        private string hostname = "localhost";
        private readonly int port = 5250;
        private List<string> textList = new List<string>();
        private List<string> videoTitles;

        #region Channels

        private Channel ch1 = new Channel();
        private Channel ch2 = new Channel();
        private Channel ch3 = new Channel();
        private Channel ch4 = new Channel();
        private Channel ch5 = new Channel();
        private Channel ch6 = new Channel();
        private Channel ch7 = new Channel();
        private Channel ch8 = new Channel();

        #endregion Channels

        #endregion variables

        #region MainWindow

        public Form1()
        {
            InitializeComponent();
            ButtonsReset();
            TabControl.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        #region Buttons

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            //caspar_.SetBackgroundColor(backgroundColorHex);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
        }

        #endregion Buttons

        #region Textbox

        private void boxAdress_TextChanged(object sender, EventArgs e)
        {
            hostname = boxAdress.Text;
        }

        #endregion Textbox

        #region Tabs

        #region Video

        #region Functions

        private void LoadVideoNames()
        {
            this.videoTitles = this.client.GetFilesInfo();
            foreach (string s in this.videoTitles)
            {
                comboBoxVideo1.Items.Add(s);
                comboBoxVideo2.Items.Add(s);
                comboBoxVideo3.Items.Add(s);
                comboBoxVideo4.Items.Add(s);
                comboBoxVideo5.Items.Add(s);
                comboBoxVideo6.Items.Add(s);
                comboBoxVideo7.Items.Add(s);
                comboBoxVideo8.Items.Add(s);
            }
        }

        #endregion Functions

        #endregion Video

        #region InfoBar

        #region Buttons

        private void buttonFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) ReadFile(openFileDialog.FileName);
        }

        #endregion Buttons

        #region Functions

        private void ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null) textList.Add(line);
            }
        }

        #endregion Functions

        #endregion InfoBar

        #region Clock

        #endregion Clock

        #region Labels

        #endregion Labels

        #region CheckBoxes

        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox cb = (System.Windows.Forms.CheckBox)sender;
            if (typeof(System.Windows.Forms.CheckBox) == sender.GetType())
            {
                for (int i = 1; i < 9; i++)
                {
                    if (cb.Name == "cbV" + i)
                    {
                        var result = this.GetType().GetField("ch" + i);
                        if (result == "")
                        {
                            cb.Checked = false;
                        }
                        else
                        {
                            client.LoadVideo(i, result);
                        }
                    }
                    else if (cb.Name == "cbB" + i)
                    {

                    }
                    else if (cb.Name == "cbC" + i)
                    {

                    }
                    else if (cb.Name == "cbL" + i)
                    {
                    }
                }
            }
            else
            {
            }
        }

        #endregion

        #endregion Tabs

        #endregion MainWindow

        #region Connection

        private void Connect()
        {
            client.SetAdress(hostname, port);
            if (client.Connect())
            {
                ConnectionBox box = new ConnectionBox();
                OnConnectUpdateGUI();
                box.Show(this);
            }
            else
            {
                OnFailUpdateGUI();
            }
        }

        private void Disconnect()
        {
            client.Disconnect();
            OnDisconnectUpdateGUI();
        }

        #endregion Connection

        #region GUIupdate

        private void OnConnectUpdateGUI()
        {
            TextBoxColorChange(Color.LimeGreen);
            buttonConnect.Enabled = false;
            buttonStart.Enabled = true;
            buttonFile.Enabled = true;
            buttonReset.Enabled = true;
            TabControl.Enabled = true;
            LoadVideoNames();
        }

        private void OnDisconnectUpdateGUI()
        {
            TextBoxReset();
            ButtonsReset();
            TabControl.Enabled = false;
        }

        private void OnFailUpdateGUI()
        {
            TextBoxColorChange(Color.Red);
            ButtonsReset();
        }

        private void ButtonsReset()
        {
            buttonConnect.Enabled = true;
            buttonReset.Enabled = false;
            buttonFile.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = false;
        }

        private void TextBoxReset()
        {
            boxAdress.Text = "localhost";
            TextBoxColorChange(Color.White);
            boxBarHorizontalPos.Value = 0;
            boxBarVerticalPos.Value = 0;
            boxLabelHorizontalPos.Value = 0;
            boxLabelVerticalPos.Value = 0;
            boxClockHorizontalPos.Value = 0;
            boxClockVerticalPos.Value = 0;
            boxClockStyle.SelectedItem = boxClockStyle.Items[0];
        }

        private void CheckBoxesReset()
        {
        }

        private void TextBoxColorChange(Color color)
        {
            boxAdress.BackColor = color;
        }

        #endregion GUIupdate

    }
}