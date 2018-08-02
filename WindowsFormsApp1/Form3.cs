using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private Client client;
        private List<Channel> channels = new List<Channel>();
        private string type = "";

        public Form3(Client client, List<Channel> channels, string type)
        {
            this.client = client;
            this.channels = channels;
            SelectChannels();
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {    
        }

        private void SelectType()
        {
            switch (this.type)
            {
                case "start":
                    SelectToPlay();
                    break;
                case "pause":
                    SelectToPause();
                    break;
                case "stop":
                    SelectToStop();
                    break;
            }
        }

        private void SelectChannels()
        {
            int i = 0;
            foreach (Channel ch in channels)
            {
                i++;
                if (ch.Loaded)
                {
                    SelectCheckBox(i);
                }
            }
        }

        private void SelectCheckBox(int r)
        {
            if (SV1.Name == "SV" + r)
            {
                SV1.Enabled = true;
            }
            else if (SV2.Name == "SV" + r)
            {
                SV2.Enabled = true;
            }
            else if (SV3.Name == "SV" + r)
            {
                SV3.Enabled = true;
            }
            else if (SV4.Name == "SV" + r)
            {
                SV4.Enabled = true;
            }
            else if (SV5.Name == "SV" + r)
            {
                SV5.Enabled = true;
            }
            else if (SV6.Name == "SV" + r)
            {
                SV6.Enabled = true;
            }
            else if (SV7.Name == "SV" + r)
            {
                SV7.Enabled = true;
            }
            else if (SV8.Name == "SV" + r)
            {
                SV8.Enabled = true;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SelectType();
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (typeof(System.Windows.Forms.CheckBox) == sender.GetType())
            {
                System.Windows.Forms.CheckBox cb = (System.Windows.Forms.CheckBox) sender;
                for (int i = 1; i < 9; i++)
                {
                    if (cb.Name == "SV" + i)
                    {
                        Form1.selectedFromForm3[i - 1] = true;
                    }
                }
            }
            else
            {
            }
        }

        private void SelectToPlay()
        {
            int i = 0;
            foreach (Channel ch in channels)
            {
                i++;
                if (ch.Loaded)
                {
                    client.PlayVideo(i, ch.VideoLayer);
                }
            }
            Form1.form3Executed = true;
        }

        private void SelectToPause()
        {
            int i = 0;
            foreach (Channel ch in channels)
            {
                i++;
                if (ch.Loaded)
                {
                    client.PauseVideo(i, ch.VideoLayer);
                }
            }
            Form1.form3Executed = true;
        }

        private void SelectToStop()
        {
            int i = 0;
            foreach (Channel ch in channels)
            {
                i++;
                if (ch.Loaded)
                {
                    client.StopVideo(i, ch.VideoLayer);
                }
            }
            Form1.form3Executed = true;
        }

    }
}
