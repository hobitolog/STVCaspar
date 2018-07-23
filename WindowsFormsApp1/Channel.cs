using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Channel
    {
        private string videoName = "";
        private bool infoBar = false;
        private bool clock = false;
        private bool labels = false;
        private int videoLayer = 0;
        private bool loaded = false;

        public bool Loaded
        {
            get => loaded;
            set => loaded = value;
        }

        public int VideoLayer
        {
            get => videoLayer;
            set => videoLayer = value;
        }

        public string VideoName
        {
            get => videoName;
            set => videoName = value;
        }

        public bool InfoBar
        {
            get => infoBar;
            set => infoBar = value;
        }

        public bool Clock
        {
            get => clock;
            set => clock = value;
        }

        public bool Labels
        {
            get => labels;
            set => labels = value;
        }
    }
}
