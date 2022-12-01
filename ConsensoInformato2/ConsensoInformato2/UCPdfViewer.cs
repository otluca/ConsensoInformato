using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Drawing;

using Telerik.Windows.Documents.Fixed.Model.InteractiveForms;
using System.Windows.Forms;
using Telerik.WinControls.CodedUI;

namespace ConsensoInformato2
{
    class UCPdfViewer : RadPdfViewer
    {
        protected override bool ProcessKeyEventArgs(ref Message m)
        {
            // memo: questo serve per aggirare un bug del controllo che 
            //       - fa rendering del normale apostrofo con il carattere copyright
            //         soluzione: la rimpiazzo con la virgoletta di chiusura.
            var returnValue = true;
            var keyCodePressed = m.WParam.ToInt32();

            if (m.Msg == 258 && keyCodePressed == 0x27)
            {
                m.WParam = new IntPtr(0x2019);
            }

            returnValue = base.ProcessKeyEventArgs(ref m);

            return returnValue;
        }


        public void ForceClick()
        {
            this.FitFullPage = true;
            var rect = this.PdfViewerElement.Bounds;
            var pt = new Point(rect.Left + rect.Width / 2, rect.Top + 10);
            ClickOnPointTool.ClickOnPoint(this.Handle, pt);
        }

        public void CheckFields()
        {
            var doc = this.Document;

            foreach(var field in doc.AcroForm.FormFields)
            {
                if (field.FieldType == FormFieldType.TextBox)
                {
                    var textField = field as TextBoxField;
                }
            }
        }
    }
}
