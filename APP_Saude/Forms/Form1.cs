using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
namespace APP_Saude
{
    public partial class AppSaude : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildform;
        //Constructor
        public AppSaude()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,46);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }     
        private struct RGBcolors
        {
             public static Color  color1 = Color.FromArgb(213, 255, 135);
             public static Color  color2 = Color.FromArgb(135, 255, 170);
             public static Color  color3 = Color.FromArgb(203, 107, 255);
             public static Color  color4 = Color.FromArgb(255, 112, 112);
             public static  Color color5 = Color.FromArgb(102, 135, 255);
        }

       //Methods
       private void ActivateButton(object senderBtn, Color color)
        {
            if(senderBtn !=null)
            {
                DisableButton();
                //btn
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(50, 81, 88);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //iconcurrent Childform
                CurrentChildFormIcon.IconChar = currentBtn.IconChar;
                CurrentChildFormIcon.IconColor = color;

            }
        }
       //disable BTN
       private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(50,81,88);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(16,173,156);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildform(Form childform)
        {
            if(currentChildform != null)
            {
                //open only form
                currentChildform.Close();
            }
            currentChildform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            PanelDesktop.Controls.Add(childform);
            PanelDesktop.Tag = childform;
            childform.BringToFront();
            childform.Show();
            TitleChildform.Text = childform.Text;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            OpenChildform(new questionario());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color2);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color4);
        }

        private void Definições_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color5);
        }

        private void BtnHomes_Click(object sender, EventArgs e)
        {
            currentChildform.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            CurrentChildFormIcon.IconChar = IconChar.Home;
            CurrentChildFormIcon.IconColor = Color.FromArgb(45, 173, 160)  ;
            TitleChildform.Text = "Home";
        }
        //mover Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwind, int wMsg, int wParam, int IParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112,  0xf012,0 );
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

    }
}
