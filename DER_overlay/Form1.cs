using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DER_overlay
{

    public partial class Form1 : Form
    {
        private IKeyboardMouseEvents globalHook;
        private OverlayForm overlay;
        OverlayForm over = new OverlayForm();
        private IKeyboardMouseEvents gma_hook;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gma_hook = Hook.GlobalEvents();
            gma_hook.KeyDown += Gma_hook_KeyDown;
            over.ShowDialog();

        }

        private void Gma_hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F14)
            {
                over.rev();
            }
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gma_hook.KeyDown -= Gma_hook_KeyDown;
            gma_hook.Dispose();
        }
    }
}
