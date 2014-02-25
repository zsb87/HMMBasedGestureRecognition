using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Recognizer.HMM
{
	public class MainForm : System.Windows.Forms.Form
	{
		#region Fields

        private RecognizerUtils _rec;
        private bool _recording;
        private bool _isDown;
        private ArrayList _points;
        private ViewForm _viewFrm;

		#endregion

		#region Form Elements

		private System.Windows.Forms.Label lblRecord;
		private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem Exit;
		private System.Windows.Forms.MenuItem LoadGesture;
		private System.Windows.Forms.MenuItem ViewGesture;
		private System.Windows.Forms.MenuItem RecordGesture;
		private System.Windows.Forms.MenuItem GestureMenu;
        private System.Windows.Forms.MenuItem ClearGestures;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.MenuItem HelpMenu;
        private System.Windows.Forms.MenuItem About;
        private Label lblRecognizing;
        private MenuItem FileMenu;
        private IContainer components;

		#endregion

        #region Start & Stop

        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new MainForm());
        }

        public MainForm()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            InitializeComponent();
            _rec = new RecognizerUtils();
            _points = new ArrayList(256);
            _viewFrm = null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lblRecord = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenu = new System.Windows.Forms.MenuItem();
            this.Exit = new System.Windows.Forms.MenuItem();
            this.GestureMenu = new System.Windows.Forms.MenuItem();
            this.RecordGesture = new System.Windows.Forms.MenuItem();
            this.LoadGesture = new System.Windows.Forms.MenuItem();
            this.ViewGesture = new System.Windows.Forms.MenuItem();
            this.ClearGestures = new System.Windows.Forms.MenuItem();
            this.HelpMenu = new System.Windows.Forms.MenuItem();
            this.About = new System.Windows.Forms.MenuItem();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblRecognizing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRecord
            // 
            this.lblRecord.BackColor = System.Drawing.Color.Transparent;
            this.lblRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecord.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRecord.Location = new System.Drawing.Point(0, 0);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(1184, 26);
            this.lblRecord.TabIndex = 1;
            this.lblRecord.Text = "[Recording]";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecord.Visible = false;
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenu,
            this.GestureMenu,
            this.HelpMenu});
            // 
            // FileMenu
            // 
            this.FileMenu.Index = 0;
            this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Exit});
            this.FileMenu.Text = "&File";
            // 
            // Exit
            // 
            this.Exit.Index = 0;
            this.Exit.Text = "E&xit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // GestureMenu
            // 
            this.GestureMenu.Index = 1;
            this.GestureMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.RecordGesture,
            this.LoadGesture,
            this.ViewGesture,
            this.ClearGestures});
            this.GestureMenu.Text = "&Gestures";
            this.GestureMenu.Popup += new System.EventHandler(this.GestureMenu_Popup);
            // 
            // RecordGesture
            // 
            this.RecordGesture.Index = 0;
            this.RecordGesture.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.RecordGesture.Text = "&Record";
            this.RecordGesture.Click += new System.EventHandler(this.RecordGesture_Click);
            // 
            // LoadGesture
            // 
            this.LoadGesture.Index = 1;
            this.LoadGesture.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.LoadGesture.Text = "&Load...";
            this.LoadGesture.Click += new System.EventHandler(this.LoadGesture_Click);
            // 
            // ViewGesture
            // 
            this.ViewGesture.Index = 2;
            this.ViewGesture.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.ViewGesture.Text = "&View";
            this.ViewGesture.Click += new System.EventHandler(this.ViewGesture_Click);
            // 
            // ClearGestures
            // 
            this.ClearGestures.Index = 3;
            this.ClearGestures.Text = "&Clear";
            this.ClearGestures.Click += new System.EventHandler(this.ClearGestures_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.Index = 2;
            this.HelpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.About});
            this.HelpMenu.Text = "&Help";
            // 
            // About
            // 
            this.About.Index = 0;
            this.About.Text = "&About...";
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblResult.Location = new System.Drawing.Point(1155, 26);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(29, 12);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Test";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRecognizing
            // 
            this.lblRecognizing.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecognizing.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRecognizing.Location = new System.Drawing.Point(0, 26);
            this.lblRecognizing.Name = "lblRecognizing";
            this.lblRecognizing.Size = new System.Drawing.Size(1155, 25);
            this.lblRecognizing.TabIndex = 3;
            this.lblRecognizing.Text = "Recognizing...";
            this.lblRecognizing.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblRecognizing.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1184, 640);
            this.Controls.Add(this.lblRecognizing);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblRecord);
            this.Menu = this.MainMenu;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recognizer.HMM";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        #region File Menu

        private void Exit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        #endregion

        #region Gestures Menu

        private void GestureMenu_Popup(object sender, System.EventArgs e)
        {
            RecordGesture.Checked = _recording;
            ViewGesture.Checked = (_viewFrm != null && !_viewFrm.IsDisposed);
            ClearGestures.Enabled = (_rec.NumGestures > 0);
        }

        private void LoadGesture_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Gestures (*.xml)|*.xml";
            dlg.Title = "Load Gestures";
            dlg.RestoreDirectory = false;
            dlg.Multiselect = true;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    string name = dlg.FileNames[i];
                    _rec.LoadGesture(name);
                }
                ReloadViewForm();
            }
        }

        private void ViewGesture_Click(object sender, System.EventArgs e)
        {
            if (_viewFrm != null && !_viewFrm.IsDisposed)
            {
                _viewFrm.Close();
                _viewFrm = null;
            }
            else
            {
                _viewFrm = new ViewForm(_rec.Gestures);
                _viewFrm.Owner = this;
                _viewFrm.Show();
            }
        }

        // helper fn
        private void ReloadViewForm()
        {
            if (_viewFrm != null && !_viewFrm.IsDisposed)
            {
                _viewFrm.Close();
                _viewFrm = new ViewForm(_rec.Gestures);
                _viewFrm.Owner = this;
                _viewFrm.Show();
            }
        }

        private void RecordGesture_Click(object sender, System.EventArgs e)
        {
            _points.Clear();
            Invalidate();
            _recording = !_recording; // recording will happen on mouse-up
            lblRecord.Visible = _recording;
        }

        private void ClearGestures_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(this, "This will clear all loaded gestures. (It will not delete any XML files.)", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                _rec.ClearGestures();
                ReloadViewForm();
            }
        }


        #endregion

        #region About Menu

        private void About_Click(object sender, System.EventArgs e)
        {
            AboutForm frm = new AboutForm(_points);
            frm.ShowDialog(this);
        }

        #endregion

        #region Window Form Events

        private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (_points.Count > 0)
            {
                PointF p0 = (PointF) (PointR) _points[0]; // draw the first point bigger
                e.Graphics.FillEllipse(_recording ? Brushes.Firebrick : Brushes.DarkBlue, p0.X - 5f, p0.Y - 5f, 10f, 10f);
            }
            foreach (PointR r in _points)
            {
                PointF p = (PointF) r; // cast
                e.Graphics.FillEllipse(_recording ? Brushes.Firebrick : Brushes.DarkBlue, p.X - 2f, p.Y - 2f, 4f, 4f);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblResult.Text = String.Empty;
        }

        #endregion

        #region Mouse Events

        private void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _isDown = true;
            _points.Clear();
            _points.Add(new PointR(e.X, e.Y, Environment.TickCount));
            Invalidate();
        }

        private void MainForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_isDown)
            {
                _points.Add(new PointR(e.X, e.Y, Environment.TickCount));
                Invalidate(new Rectangle(e.X - 2, e.Y - 2, 4, 4));
            }
        }

        private void MainForm_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_isDown)
            {
                _isDown = false;

                if (_points.Count >= 5) // require 5 points for a valid gesture
                {
                    if (_recording)
                    {
                        SaveFileDialog dlg = new SaveFileDialog();
                        dlg.Filter = "Gestures (*.xml)|*.xml";
                        dlg.Title = "Save Gesture As";
                        dlg.AddExtension = true;
                        dlg.RestoreDirectory = false;

                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            _rec.SaveGesture(dlg.FileName, _points);  // resample, scale, translate to origin
                            ReloadViewForm();
                        }

                        dlg.Dispose();
                        _recording = false;
                        lblRecord.Visible = false;
                        Invalidate();
                    }
                    else if (_rec.NumGestures > 0) // not recording, so testing
                    {
                        lblRecognizing.Visible = true;
                        Application.DoEvents(); // forces label to display

                        //NBestList result = _rec.Recognize(_points); // where all the action is!!
                        //lblResult.Text = String.Format("{0}: {1} ({2}px, {3}{4})",
                        //    result.Name,
                        //    Math.Round(result.Score, 2),
                        //    Math.Round(result.Distance, 2),
                        //    Math.Round(result.Angle, 2), (char) 176);

                        lblRecognizing.Visible = false;
                    }
                }
            }
        }

        #endregion
	}
}