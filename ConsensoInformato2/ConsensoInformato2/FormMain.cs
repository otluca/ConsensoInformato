using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace ConsensoInformato2
{
    public partial class FormMain : Form
    {
        ConsensiController _controller = null;
        int _currentId = -1;
        Font _detailsFont = new Font("Arial", 10);

        bool _firstActivate = false;

        public FormMain()
        {
            InitializeComponent();

            lblPaziente.Text += Common.Cognome + " " + Common.Nome;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void SetController(ConsensiController controller)
        {
            if (_controller != null && _controller != controller) {
                _controller.TemplatesLoaded -= OnTemplatesLoaded;
                _controller.SelectionChanged -= OnSelectionChanged;
                _controller.DocumentsGenerating -= OnDocumentsGenerating;
                _controller.DocumentsGenerated -= OnDocumentsGenerated;
            }

            _controller = controller;

            if (_controller != null) {
                _controller.TemplatesLoaded += OnTemplatesLoaded;
                _controller.SelectionChanged += OnSelectionChanged;
                _controller.DocumentsGenerating += OnDocumentsGenerating;
                _controller.DocumentsGenerated += OnDocumentsGenerated;

            }

            _controller?.ClearDstDirectory();
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            if (lsbSelezionati.Items.Count > 0) {

                if (_currentId != -1)
                {
                    CommonSaveCurrentDocument();
                }

                cmdClose.Enabled = false;
                cmdGenerate.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                _controller.GenerateDocuments();
            }

            this.Close();
        }

        #region Eventi da UI

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (lsbModelli.Items.Count == 0 || lsbModelli.SelectedIndex < 0) return;

            var idx = lsbModelli.SelectedIndex;
            var item = lsbModelli.Items[idx];
            var id = (int)((long)item.GetType().GetProperty("Id").GetValue(item, null));
            _controller.SelectTemplate(id);
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lsbSelezionati.Items.Count == 0 || lsbSelezionati.SelectedIndex < 0) return;

            var idx = lsbSelezionati.SelectedIndex;

            if (_currentId >= 0)
            {
                var toRemove = _currentId;
                _currentId = -1;
                _controller.DeselectTemplate(toRemove);
                pdfvViewer.UnloadDocument();
            }

            if (lsbSelezionati.Items.Count > 0)
            {
                lsbSelezionati.SelectedIndex = (idx < lsbSelezionati.Items.Count) ? idx : idx - 1;
            }
        }

        private void lsbSelezionati_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lsbSelezionati.SelectedIndex;

            Cursor.Current = Cursors.WaitCursor;

            if (_currentId >= 0)
            {
                CommonSaveCurrentDocument();
            }

            _currentId = -1;

            if (idx >= 0) {
                var item = lsbSelezionati.Items[idx];
                var selectedId = (int)((long)item.GetType().GetProperty("Id").GetValue(item, null));
                var template = _controller.GetSelectedTemplate(selectedId);

                pdfvViewer.LoadDocument(template.FileTemporaryPath);

                _currentId = selectedId;
            }
            
            Cursor.Current = Cursors.Default;
        }

        private void rdbChiFirma_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rdbMadre) {
                _controller.SetChiFirma(EChiFirma.Madre);
            }
            else if (sender == rdbPadre) {
                _controller.SetChiFirma(EChiFirma.Padre);
            }
            else if (sender == rdbTutore) {
                _controller.SetChiFirma(EChiFirma.Tutore);
            }
            else {
                _controller.SetChiFirma(EChiFirma.Paziente);
            }
        }

        private void pdfvViewer_DocumentLoaded(object sender, EventArgs e)
        {
            pdfvViewer.FitFullPage = true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.ClearTmpDirectory();
        }

        #endregion Eventi da UI

        #region Eventi da controller

        private void OnTemplatesLoaded(List<ConsensoTemplate> templates)
        {
            lsbModelli.Items.Clear();
            lsbSelezionati.ClearSelected();
            lsbModelli.DisplayMember = "Label";
            lsbSelezionati.DisplayMember = "Label";

            foreach (var item in templates) {
                var index = lsbModelli.Items.Add(new { Label = item.FileLabel, Id = item.Id } );
            }
        }

        private void OnSelectionChanged(bool isAdd, ConsensoTemplate template)
        {
            var item = new { Label = template.FileLabel, Id = template.Id };
            var itemId = template.Id;

            int InsertItem(ListBox lst)
            {
                var index = 0;
                var found = false;

                foreach(var listItem in lst.Items) {
                    var listItemId = (int)((long)listItem.GetType().GetProperty("Id").GetValue(listItem, null)); 
                    if (listItemId > itemId) {
                        lst.Items.Insert(index, item);
                        found = true;
                        break;
                    }
                    index++;
                }

                if (!found) {
                    lst.Items.Add(item);
                    index = lst.Items.Count - 1;
                }

                return index;
            }

            if (isAdd) {
                var index = InsertItem(lsbSelezionati);
                lsbModelli.Items.Remove(item);
                lsbSelezionati.SelectedIndex = index;
            }
            else {
                InsertItem(lsbModelli);
                lsbSelezionati.Items.Remove(item);
            }
        }

        private void OnDocumentsGenerating(string fileGenerated)
        {
            lblGenerating.Text = fileGenerated;
            lblGenerating.Refresh();
        }

        private void OnDocumentsGenerated(string errorMessage)
        {
            lblGenerating.Text = string.Empty;

            var noError = errorMessage == null;
            MessageBox.Show(
                noError ?
                    "Generazione completata!" :
                    "Generazione terminata con errori.\n" + errorMessage,
                "Generazione consensi",
                MessageBoxButtons.OK,
                noError ?
                    MessageBoxIcon.Information :
                    MessageBoxIcon.Error);

            cmdClose.Enabled = true;
            cmdGenerate.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        #endregion Eventi da controller

        private void ForceClickPatch()
        {
            // memo: questo è un magheggio che devo creare per aggirare un buco nel pdf viewer di telerik...
            //       in sostanza, simulo la pressione del tasto sinistro del mouse, MA deve essere ripetuto
            //       più volte e deve essere lasciato tempo perché l'ordine venga eseguito.
            for (int i = 0; i < 6; i++)
            {
                if (i < 3) pdfvViewer.ForceClick();
                Application.DoEvents();
                Thread.Sleep(100);
            }
        }

        private void CommonSaveCurrentDocument()
        {
            var currentTemplate = _controller.GetSelectedTemplate(_currentId);

            //ForceClickPatch();
            pdfvViewer.CheckFields();
            pdfvViewer.SaveDocument(currentTemplate.FileTemporaryPath);

            //  con l'ultima versione di Telerik questo rompe le balle...
            // pdfvViewer.UnloadDocument();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (_firstActivate) return;
            _firstActivate = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Common.Dottore))
            {
                lblMedico.Text = "Dottore: " + Common.Dottore;
            }

            if (!Common.DottoreFromParameters && Common.DoctorList != null)
            {
                var formDottore = new FormDottore();
                var result = formDottore.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    lblMedico.Text = "Dottore: " + Common.Dottore;
                }
                else
                {
                    this.Close();
                }
            }

        }

        private void lblMedico_Click(object sender, EventArgs e)
        {
            if (!Common.DottoreFromParameters && Common.DoctorList != null)
            {
                var formDottore = new FormDottore();
                if (formDottore.ShowDialog() == DialogResult.OK)
                {
                    lblMedico.Text = "Dottore: " + Common.Dottore;
                }
            }
        }
    }
}
