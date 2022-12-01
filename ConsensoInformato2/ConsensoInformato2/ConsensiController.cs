using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using System.Linq.Expressions;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.Model;

namespace ConsensoInformato2
{
    public delegate void TemplatesLoadedHandler(List<ConsensoTemplate> templates);
    public delegate void TemplateSelectHandler(bool isAdd, ConsensoTemplate template);
    public delegate void GenerationProgressHandler(string error);
    public delegate void GenerationCompletedHandler(string error);

    class ConsensiController
    {
        public event TemplatesLoadedHandler TemplatesLoaded = null;
        public event TemplateSelectHandler SelectionChanged = null;
        public event GenerationProgressHandler DocumentsGenerating = null;
        public event GenerationCompletedHandler DocumentsGenerated = null;

        protected ConsensiModel _model = null;

        protected Dictionary<string, string> _argumentsReplacement = null;

        public void StartUp()
        {
            _model = new ConsensiModel();
            _model.LoadTemplates();

            _argumentsReplacement = new Dictionary<string, string>() {
                {Common.LabelDelegato, _model.ChiFirma.ToString()  },
                {Common.LabelCognome, Common.Cognome },
                {Common.LabelNome, Common.Nome },
                {Common.LabelCognomeNome, Common.Cognome + " " + Common.Nome },
                {Common.LabelCodiceFiscale, Common.CodiceFiscale },
                {Common.LabelIndirizzo, Common.Indirizzo },
                {Common.LabelDataNascita, Common.DataNascita },
                {Common.LabelLuogoNascita, Common.LuogoNascita },
                {Common.LabelDottore, Common.Dottore },
                {Common.LabelData, "00/00/0000 00:00" }
            };

           SafeCallTemplatesLoaded(_model.ConsensoTemplates);
        }

        public void ShutDown()
        {
            _model = null;
        }

        #region Metodi

        public void SelectTemplate(int templateId)
        {
            var itemSelected = (from x in _model.ConsensoTemplates
                                where x.Id == templateId
                                select x).FirstOrDefault();
            if (itemSelected != null) {
                try
                { 

                    _model.GenerateTemporaryFileName(itemSelected);
                    _model.InsertConsenso(_model.ConsensoSelected, itemSelected);
                    _model.ConsensoTemplates.Remove(itemSelected);
                    CopyToWorkingDirectory(itemSelected);
                    _argumentsReplacement[Common.LabelData] = DateTime.Now.ToString("dd/MM/yyyy");
                    _model.FillCommonFields(itemSelected, _argumentsReplacement);
                    SafeCallSelectionChanged(true, itemSelected);
                }
                catch(Exception e)
                {

                }
            }
        }

        public void DeselectTemplate(int templateId)
        {
            var itemSelected = (from x in _model.ConsensoSelected
                                where x.Id == templateId
                                select x).FirstOrDefault();
            if (itemSelected != null) {
                _model.InsertConsenso(_model.ConsensoTemplates, itemSelected);
                _model.ConsensoSelected.Remove(itemSelected);
                RemoveFromWorkingDirectory(itemSelected);
                SafeCallSelectionChanged(false, itemSelected);
            }
        }

        public void GenerateDocuments()
        {
            try {
                foreach (var consenso in _model.ConsensoSelected) {
                    SafeCallDocumentsGenerating(consenso.FileName);
                    GenerateSingleDocument(consenso);
                }

                ClearTmpDirectory();
                SafeCallDocumentsGenerated();
            }
            catch (Exception e) {
                SafeCallDocumentsGenerated(e.ToString());
            }
        }

        private void GenerateSingleDocument(ConsensoTemplate consenso)
        {
            var provider = new PdfFormatProvider();
            var document = provider.Import(File.ReadAllBytes(consenso.FileTemporaryPath));

            var fields = document.AcroForm.FormFields;

            Pdf.FlattenFormFields(document);

            var destinationPath = Path.Combine(Common.PdfDestination, consenso.FileDestinationName);
            using (Stream output = File.OpenWrite(destinationPath))
            {
                provider.Export(document, output);
            }
        }

        public void ClearTmpDirectory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Common.TemporaryStore);

            foreach (var file in dirInfo.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (var dir in dirInfo.EnumerateDirectories())
            {
                Directory.Delete(dir.FullName, true);
            }
        }

        public void ClearDstDirectory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Common.PdfDestination);

            foreach (var file in dirInfo.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (var dir in dirInfo.EnumerateDirectories())
            {
                Directory.Delete(dir.FullName, true);
            }
        }

        public ConsensoTemplate GetSelectedTemplate(int templateId)
        {
            return (from x in _model.ConsensoSelected
                    where x.Id == templateId
                    select x).FirstOrDefault();
        }

        public void SetChiFirma(EChiFirma who)
        {
            _model.ChiFirma = who;
            _argumentsReplacement[Common.LabelDelegato] = who.ToString();
        }

        #endregion Metodi

        #region eventi

        private void SafeCallTemplatesLoaded(List<ConsensoTemplate> consensoTemplates)
        {
            if (TemplatesLoaded != null) {
                TemplatesLoaded(consensoTemplates);
            }
        }

        private void SafeCallSelectionChanged(bool isAdd, ConsensoTemplate template)
        {
            if (SelectionChanged != null) {
                SelectionChanged(isAdd, template);
            }
        }

        private void SafeCallDocumentsGenerating(string errorMessage = null)
        {
            if (DocumentsGenerating != null) {
                DocumentsGenerating(errorMessage);
            }
        }

        private void SafeCallDocumentsGenerated(string errorMessage = null)
        {
            if (DocumentsGenerated != null) {
                DocumentsGenerated(errorMessage);
            }
        }

        #endregion eventi

        #region Helpers
        
        private void CopyToWorkingDirectory(ConsensoTemplate itemSelected)
        {
            if (File.Exists(itemSelected.FileTemporaryPath))
            {
                File.Delete(itemSelected.FileTemporaryPath);
            }
            File.Copy(itemSelected.FileTemplatePath, itemSelected.FileTemporaryPath);
        }

        private void RemoveFromWorkingDirectory(ConsensoTemplate itemSelected)
        {
            File.Delete(itemSelected.FileTemporaryPath);
        }

        #endregion

    }
}
