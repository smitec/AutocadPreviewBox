using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//All in the acdmgd.dll from C:\Program Files\Autocad etc
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows;



namespace previewer
{
    public class PreviewTester
    {
        /// <summary>
        /// Pallet to hold the user control
        /// </summary>
        PaletteSet myPal;

        /// <summary>
        /// Instance of the Preview box
        /// </summary>
        PreviewBox myPreviewBox;

        /// <summary>
        /// Simple method to initialize the pallete in Autocad
        /// </summary>
        [CommandMethod("prev")]
        public void preview()
        {
            if (myPal == null)
            {
                myPal = new PaletteSet("My Palette", System.Guid.NewGuid());
                myPreviewBox = new PreviewBox();
                myPal.Add("Palette1", myPreviewBox);
            }
            myPal.Visible = true;
        }

        /// <summary>
        /// Load a preview image into the box.
        /// </summary>
        [CommandMethod("ldprv")]
        public void load_preview()
        {
            if (myPal == null) {
                this.preview();
            }

            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            PromptOpenFileOptions op = new PromptOpenFileOptions("Select a File to Preview.");
            PromptFileNameResult fn = ed.GetFileNameForOpen(op);
            if (fn.Status == PromptStatus.OK)
            {
                myPreviewBox.load_file_preview(fn.StringResult);
            }
        }

    }
}
