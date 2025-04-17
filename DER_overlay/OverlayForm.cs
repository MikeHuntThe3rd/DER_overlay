using Gma.System.MouseKeyHook;
using System;
using System.Data.SqlTypes;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

public class OverlayForm : Form
{
    public bool show = true;
    public OverlayForm()
    {
        this.FormBorderStyle = FormBorderStyle.None; // No border
        this.TopMost = true; // Stay on top
        this.BackColor = Color.LimeGreen; // Choose a color to be transparent
        this.TransparencyKey = Color.LimeGreen; // Make that color transparent
        this.WindowState = FormWindowState.Maximized; // Full screen
        this.ShowInTaskbar = true; // Hide from taskbar
        this.KeyPreview = true;
        this.KeyPreview = true;
        
        int initialStyle = NativeMethods.GetWindowLong(this.Handle, NativeMethods.GWL_EXSTYLE);
        NativeMethods.SetWindowLong(this.Handle, NativeMethods.GWL_EXSTYLE,
            initialStyle | NativeMethods.WS_EX_LAYERED); // NO WS_EX_TRANSPARENT
    }
    public void rev()
    {
        show = !show;
        this.Invalidate();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (show)
        {
            using (Pen pen = new Pen(Color.Red, 20))
            {
                float x = e.Graphics.DpiX / 96f;
                float y = e.Graphics.DpiY / 96f;
                e.Graphics.DrawEllipse(pen, (ClientSize.Width - 40 * 5 * x) * x, 20 * y + 200, 20, 20);
            }
        }
        
    }
    private static class NativeMethods
    {
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int WS_EX_LAYERED = 0x80000;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }


}