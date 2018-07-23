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
        private List<Channel> channels = new List<Channel>();

        #endregion variables

        #region MainWindow

        #region Form

            public Form1()
        {
            InitializeComponent();
            ButtonsReset();
            AddChannels();
            TabControl.Enabled = false;
        }

            private void Form1_Load(object sender, EventArgs e)
        {
        }

            private void AddChannels()
        {
            for (int i = 0; i < 8; i++)
            {
                channels.Add(new Channel());
            }
        }
            
        #endregion

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
            buttonPause.Enabled = true;
            buttonStop.Enabled = true;
            int i = 0;
            foreach (Channel ch in channels)
            {
                i++;
                if (ch.Loaded)
                {
                    client.PlayVideo(i , ch.VideoLayer );
                }
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = true;
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
            int i = 0;
            foreach (Channel ch in channels)
            {
                i++;
                if (ch.Loaded)
                {
                    client.PauseVideo(i, ch.VideoLayer);
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
            int i = 0;
            foreach (Channel ch in channels)
            {
                i++;
                if (ch.Loaded)
                {
                    client.StopVideo(i, ch.VideoLayer);
                }
            }
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
                cbxV1.Items.Add(s);
                cbxV2.Items.Add(s);
                cbxV3.Items.Add(s);
                cbxV4.Items.Add(s);
                cbxV5.Items.Add(s);
                cbxV6.Items.Add(s);
                cbxV7.Items.Add(s);
                cbxV8.Items.Add(s);
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

        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (typeof(System.Windows.Forms.CheckBox) == sender.GetType())
            {
                System.Windows.Forms.CheckBox cb = (System.Windows.Forms.CheckBox)sender;
                for (int i = 1; i < 9; i++)
                {
                    if (cb.Name == "cbV" + i)
                    {
                        if (channels[i-1].VideoName == "")
                        {
                            cb.Checked = false;
                        }
                        else
                        {
                            client.LoadVideo(i, channels[i-1].VideoLayer, channels[i-1].VideoName);
                            channels[i - 1].Loaded = true;
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

        private void ComboBoxesVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeof(System.Windows.Forms.ComboBox) == sender.GetType())
            {
                System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)sender;
                for (int i = 1; i < 9; i++)
                {
                    if (cbx.Name == "cbxV" + i)
                    {
                        channels[i-1].VideoName=cbx.SelectedItem.ToString();
                    }
                }
            }
        }

        private void NumericUpDown_CheckedChanged(object sender, EventArgs e)
        {
            if (typeof(System.Windows.Forms.NumericUpDown) == sender.GetType())
            {
                System.Windows.Forms.NumericUpDown nud = (System.Windows.Forms.NumericUpDown)sender;
                for (int i = 1; i < 9; i++)
                {
                    if (nud.Name == "VL" + i)
                    {
                        channels[i - 1].VideoLayer = Decimal.ToInt32(nud.Value);
                    }
                }
            }
        }

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
            buttonPause.Enabled = false;
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