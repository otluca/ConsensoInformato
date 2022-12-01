using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsensoInformato2.Properties;
using System.Windows.Forms;
using ConsensoInformato2;
using System.Runtime.CompilerServices;

using System.Diagnostics;

using Newtonsoft.Json.Linq;


using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.Model.Text;
using Telerik.Windows.Documents.Fixed.Model.Fonts;

namespace ConsensoInformato2
{
    public enum EChiFirma
    {
        Paziente,
        Padre,
        Madre,
        Tutore
    }


    public class TemplateDetail
    {
        public string Label { get; set; }
        public string Detail { get; set; }
    }


    public class ConsensoTemplate
    {
        public long Id { get; set; }
        public string FileLabel { get; set; }
        public string FileName { get; set; }
        public string FileDestinationName { get; set; }
        public string FileTemplatePath { get; set; }
        public string FileTemporaryPath { get; set; }
    }

    public class ConsensiModel
    {
        public List<ConsensoTemplate> ConsensoTemplates { get; private set; } = new List<ConsensoTemplate>();
        public List<ConsensoTemplate> ConsensoSelected { get; private set; } = new List<ConsensoTemplate>();

        public EChiFirma ChiFirma { get; set; } = EChiFirma.Paziente;


        public void LoadTemplates()
        {
            var id = 0;
            var listOfFiles = from x in Directory.EnumerateFiles(Common.TemplatesStore, $"*{Common.TemplatePostfix}.{Common.TemplateExtension}")
                              orderby Path.GetFileName(x).Replace(Common.TemplateExtension, string.Empty)
                              select new { Path = x, FileName = Path.GetFileName(x)};

            var idx = 0;
            foreach (var fileElement in listOfFiles) {
                ConsensoTemplates.Add(
                    new ConsensoTemplate() {
                        Id = idx++,
                        FileLabel = fileElement.FileName,
                        FileTemplatePath = fileElement.Path,
                        FileName = fileElement.FileName
                    });
            }

            var templatesConfigurationPath = Common.TemplatesStore + "\\Templates.json";
            if (File.Exists(templatesConfigurationPath))
            {
                var content = File.ReadAllText(templatesConfigurationPath);
                JObject o = JObject.Parse(content);
                foreach (var item in o["templates"])
                {
                    var templateFile = item["name"].ToString();
                    var templateLabel = item["label"].ToString();

                    if (!string.IsNullOrEmpty(templateFile) && !string.IsNullOrEmpty(templateLabel))
                    {
                        var consensoSelection = (from x in ConsensoTemplates
                                                 where x.FileName == templateFile
                                                 select x);
                        var consenso = (consensoSelection.Count() > 0) ? consensoSelection.First() : null;

                        if (consenso != null)
                        {
                            consenso.FileLabel = templateLabel;
                        }
                    }
                }
            }
        }

        public void InsertConsenso(List<ConsensoTemplate>templates, ConsensoTemplate consenso)
        {
            int pos = 0;

            foreach(var item in templates) {
                if (item.Id > consenso.Id) {
                    templates.Insert(pos, consenso);
                    pos = -1;
                    break;
                }
                pos++;
            }

            if (pos >= 0) {
                templates.Add(consenso);
            }
        }

        internal void GenerateTemporaryFileName(ConsensoTemplate itemSelected)
        {
            itemSelected.FileDestinationName =
                itemSelected.FileName
                    .Replace(Common.TemplatePostfix, string.Empty)
                    .Replace("." + Common.TemplateExtension, string.Empty) +
                "_" + DateTime.Now.ToString("yyMMddHHmm") + "." + Common.TemplateExtension;
            itemSelected.FileTemporaryPath = System.IO.Path.Combine(Common.TemporaryStore, itemSelected.FileDestinationName);
        }

        internal void FillCommonFields(ConsensoTemplate consenso, Dictionary<string, string> argumentsReplacement)
        {
            RadFixedDocument document = null;
            PdfFormatProvider formatProvider = new PdfFormatProvider();

            using (var pdfStream = new FileStream(consenso.FileTemporaryPath, FileMode.Open))
            {
                document = formatProvider.Import(pdfStream);
            }

            if (document == null) return;

            foreach (var page in document.Pages)
            {
                FillCommonFieldsInPage(page, argumentsReplacement);
            }

            using (Stream output = File.OpenWrite(consenso.FileTemporaryPath))
            {
                formatProvider.Export(document, output);
            }
        }

        protected void FillCommonFieldsInPage(RadFixedPage page, Dictionary<string, string> argumentsReplacement)
        {
            List<(string, List<int>)> markupsToReplace = SearchMarkups(page);
            List<int> toRemove = new List<int>();

            foreach (var tupleItem in markupsToReplace)
            {
                var key = tupleItem.Item1;
                if (argumentsReplacement.ContainsKey(key))
                {
                    var indexes = tupleItem.Item2;
                    var indexBase = indexes[0];
                    var tx = page.Content[indexBase] as TextFragment;

                    var txNew = new TextFragment(argumentsReplacement[key]);
                    txNew.Position = tx.Position;
                    if (tx.Font.Name.Contains("Oblique") || tx.Font.Name.Contains("Italic"))
                    {
                        txNew.Font = FontsRepository.HelveticaOblique;
                    }
                    else
                    {
                        txNew.Font = FontsRepository.Helvetica;
                    }
                    txNew.FontSize = tx.FontSize;
                    page.Content[indexBase] = txNew;

                    for (int i = 1; i < indexes.Count; i++)
                    {
                        toRemove.Add(indexes[i]);
                    }
                }
            }

            if (toRemove.Count > 0)
            {
                toRemove.Sort();
                for (int i = toRemove.Count - 1; i >= 0; i--)
                {
                    page.Content.RemoveAt(toRemove[i]);
                }
            }
        }

        protected List<(string, List<int>)> SearchMarkups(RadFixedPage page)
        {
            List<(string, List<int>)> markupsToReplace = new List<(string, List<int>)>();
            var isOn = false;
            var isStart = false;
            List<int> temporaryIndex = null;
            string temporaryElementsAccumulator = string.Empty;

            var lenPage = page.Content.Count;

            //TODO: perché funzioni, devono essere messi spazi attorno ai tag.
            //      eventualmente, rivedi l'analisi in modo da separare bene i tag dal resto del testo.

            for (int i = 0; i < lenPage; i++)
            {
                var element = page.Content[i];
                if (element is TextFragment)
                {
                    isStart = false;
                    var tx = element as TextFragment;
                    if (!isOn && tx.Text.TrimStart().StartsWith("$$"))
                    {
                        isOn = true;
                        isStart = true;
                        temporaryIndex = new List<int>();
                        temporaryElementsAccumulator = string.Empty;
                    }

                    if (isOn)
                    {
                        temporaryIndex.Add(i);
                        temporaryElementsAccumulator += tx.Text;
                    }

                    if (isOn && !isStart && tx.Text.TrimEnd().EndsWith("$$"))
                    {
                        isOn = false;
                        markupsToReplace.Add((temporaryElementsAccumulator.Trim(), temporaryIndex));
                        temporaryElementsAccumulator = string.Empty;
                        temporaryIndex = null;
                    }
                }
            }

            return markupsToReplace;
        }

    }
}
