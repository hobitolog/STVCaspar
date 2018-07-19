using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Svt.Caspar;
using Svt.Network;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region variables

        private string hostname = "localhost";
        private readonly int port = 5250;
        private List<string> textList = new List<string>();
        private List<string> videoTitles;

        private Client client = new Client();

        #region Channels
        private Channel ch1 = new Channel();
        private Channel ch2 = new Channel();
        private Channel ch3 = new Channel();
        private Channel ch4 = new Channel();
        private Channel ch5 = new Channel();
        private Channel ch6 = new Channel();
        private Channel ch7 = new Channel();
        private Channel ch8 = new Channel();
        #endregion

        #endregion

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
        #endregion

            #region Textbox
            private void boxAdress_TextChanged(object sender, EventArgs e)
            {
                hostname = boxAdress.Text;
            }
            #endregion

        #endregion

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
        #endregion

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
            checkBoxBar.Checked = false;
            checkBoxClock.Checked = false;
            checkBoxLabels.Checked = false;
        }
        private void TextBoxColorChange(Color color)
        {
            boxAdress.BackColor = color;
        }
        #endregion

        #region Tabs

            #region Video

                #region Checkbox
                    private void checkBoxVideo1_CheckedChanged(object sender, EventArgs e)
                    {
                        if (ch1.VideoName == "")
                        {
                            checkBoxVideo1.Checked = false;
                        }
                        else
                        {
                            client.LoadVideo(1, ch1.VideoName);
                        }
                    }

                    private void checkBoxVideo2_CheckedChanged(object sender, EventArgs e)
                    {

                    }

                    private void checkBoxVideo3_CheckedChanged(object sender, EventArgs e)
                    {

                    }

                    private void checkBoxVideo4_CheckedChanged(object sender, EventArgs e)
                    {

                    }

                    private void checkBoxVideo5_CheckedChanged(object sender, EventArgs e)
                    {

                    }

                    private void checkBoxVideo6_CheckedChanged(object sender, EventArgs e)
                    {

                    }

                    private void checkBoxVideo7_CheckedChanged(object sender, EventArgs e)
                    {

                    }

                    private void checkBoxVideo8_CheckedChanged(object sender, EventArgs e)
                    {

                    }
                #endregion

                #region Radio

        #endregion

                #region LayerBox

                #endregion

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
                #endregion

            #endregion

            #region InfoBar

                #region Buttons
        private void buttonFile_Click(object sender, EventArgs e)
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK) ReadFile(openFileDialog.FileName);
                }
                #endregion

                #region Checkbox
                private void checkBoxBar_CheckedChanged(object sender, EventArgs e)
                {
                }
                #endregion

                #region Functions
                private void ReadFile(string fileName)
                {
                    using (var reader = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null) textList.Add(line);
                    }
                }
                #endregion

            #endregion

            #region Clock

            #region Checkbox
            private void checkBoxClock_CheckedChanged(object sender, EventArgs e)
            {
            }
            #endregion

            #endregion

            #region Labels

            #region Checkbox
            private void checkBoxLabels_CheckedChanged(object sender, EventArgs e)
            {
            }
        #endregion

        #endregion

        #endregion
    }
}