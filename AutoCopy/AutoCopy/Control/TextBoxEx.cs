using System.Drawing;
using System.Windows.Forms;

namespace AutoCopy.Control
{
    public class TextBoxEx : TextBox
    {
        public string PlaceHolderStr { get; set; }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xF || m.Msg == 0x133)
            {
                WmPaint(ref m);
            }
        }

        private void WmPaint(ref Message m)
        {
            Graphics g = Graphics.FromHwnd(Handle);
            if (!string.IsNullOrEmpty(PlaceHolderStr) && string.IsNullOrEmpty(Text))
            {
                g.DrawString(PlaceHolderStr, Font, new SolidBrush(Color.LightGray), 0, 0);

            }
        }
    }
}
