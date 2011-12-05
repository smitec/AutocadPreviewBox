/*
 * This file is a simple preview file showing some of the ways you can interact with the user control
 * On its own this file doesn't do anything exciting but it shows how a file can be previewed from
 * its filename which could be useful when building an autocad extension that loads blocks or files. 
 * */

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
            //Create the palette if we havent already
            if (myPal == null)
            {
                myPal = new PaletteSet("My Palette", System.Guid.NewGuid());
                myPreviewBox = new PreviewBox();
                myPal.Add("Palette1", myPreviewBox);
            }

            //disply the palette
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
            //ask for a file using the open file dialog
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            PromptOpenFileOptions op = new PromptOpenFileOptions("Select a File to Preview.");
            PromptFileNameResult fn = ed.GetFileNameForOpen(op);
            
            //did we get a file okay?
            if (fn.Status == PromptStatus.OK)
            {
                //use the loaded dwg file to update the preview box
                myPreviewBox.load_file_preview(fn.StringResult);
            }
            //show the palette just in case it's been closed
            myPal.Visible = true;
        }
    }
}
