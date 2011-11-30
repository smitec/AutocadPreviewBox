using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//All in the acdmgd.dll from C:\Program Files\Autocad etc
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows;


namespace previewer
{   
    /// <summary>
    /// Preview Box User Control
    /// </summary>
    public partial class PreviewBox : UserControl
    {
        /// <summary>
        /// Preview Box User Control
        /// </summary>
        public PreviewBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// on load method (Nothing to do here at this stage)
        /// </summary>
        /// <param name="sender">sender of the request</param>
        /// <param name="e">event arguments</param>
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Load a dwg preview into the control.
        /// </summary>
        /// <param name="filename">Path to the .dwg file</param>
        public void load_file_preview(string filename)
        {
            //create a new database instance and load the dwg file into it.
            Database dbb = new Database(false, true);
            dbb.ReadDwgFile(filename, FileOpenMode.OpenForReadAndAllShare, false, "");

            //grab the thumbnail bitmap and get rid of the white background
            System.Drawing.Bitmap preview = dbb.ThumbnailBitmap;
            preview.MakeTransparent(System.Drawing.Color.White);
                
            //place the picture in the preview box and resize
            this.pictureBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.pictureBox1.Image = preview;
            this.pictureBox1.Width = preview.Width;
            this.pictureBox1.Height = preview.Height;
        }
    }
}
