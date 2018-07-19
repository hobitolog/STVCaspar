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
