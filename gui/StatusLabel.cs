using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public class StatusLabel : Label
    {
        string originalText = string.Empty;
        bool updating = false;

        public StatusLabel()
        {
            TextChanged += StatusLabel_TextChanged;
            originalText = Text;
        }

        private void StatusLabel_TextChanged(object sender, EventArgs e)
        {
            if (!updating)
                originalText = Text;
        }

        public enum Status
        {
            Success,
            Warning,
            Danger,
            Disabled,
            Done,
            Current
        }

        private Status _status = Status.Disabled;
        public Status CurrentStatus
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                updateColors();
            }
        }

        void updateColors()
        {
            if (updating)
                return;
            updating = true;
            Color fontColor = Color.Black;
            string prefix = string.Empty;
            bool bold = true;
            switch (CurrentStatus)
            {
                case Status.Success:
                    fontColor = Color.DarkGreen;
                    prefix = "✓";
                    break;
                case Status.Warning:
                    fontColor = Color.Gold;
                    prefix = "!";
                    break;
                case Status.Danger:
                    fontColor = Color.Firebrick;
                    prefix = "x";
                    break;
                case Status.Disabled:
                    fontColor = Color.Gray;
                    bold = false;
                    break;
                case Status.Done:
                    fontColor = Color.DodgerBlue;
                    prefix = "✓";
                    break;
                case Status.Current:
                    fontColor = Color.Black;
                    prefix = ">";
                    break;
            }
            ForeColor = fontColor;
            Font = new Font(Font.FontFamily, Font.SizeInPoints, bold ? FontStyle.Bold : Font.Style);
            Text = (!string.IsNullOrEmpty(prefix) ? prefix + " " : string.Empty) + originalText;
            updating = false;
        }
    }
}
