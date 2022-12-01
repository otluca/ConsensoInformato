using ConsensoInformato2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConsensoInformato2
{
    public static class Common
    {
        public static void InitCommon()
        {
            TemplatesStore = Properties.Settings.Default.TemplatesStore;
            TemplatePostfix = Properties.Settings.Default.TemplatePostfix;
            TemplateExtension = Properties.Settings.Default.TemplateExtension;
            TemporaryStore = Properties.Settings.Default.TemporaryStore;
            PdfStore = Properties.Settings.Default.PdfStore;
            PdfDestination = Properties.Settings.Default.PdfDestination;
            DoctorListStore = Properties.Settings.Default.DoctorListStore;
            Dottore = Properties.Settings.Default.CurrentDoctor;

            if (!string.IsNullOrEmpty(DoctorListStore))
            {
                LoadDoctorList();
            }
        }

        private static void LoadDoctorList()
        {
            if (File.Exists(DoctorListStore))
            {
                DoctorList = File.ReadAllLines(DoctorListStore);
            }
        }

        public static void SetDoctor(string doctor)
        {
            Dottore = doctor;
            Properties.Settings.Default.CurrentDoctor = doctor;
            Properties.Settings.Default.Save();
        }

        public const string LabelCognome = "$$cognome$$";
        public const string LabelNome = "$$nome$$";
        public const string LabelCognomeNome = "$$cognomenome$$";
        public const string LabelCodiceFiscale = "$$codicefiscale$$";
        public const string LabelIndirizzo = "$$indirizzo$$";
        public const string LabelDataNascita = "$$datanascita$$";
        public const string LabelLuogoNascita = "$$luogonascita$$";
        public const string LabelDottore = "$$dottore$$";
        
        public const string LabelDettaglio = "$$dettaglio$$";
        public const string LabelDelegato = "$$delegato$$";
        public const string LabelData = "$$data$$";
        
        public static string[] DoctorList;

        public static string TemplatesStore { get; private set; } = null;
        public static string TemplatePostfix { get; private set; } = null;
        public static string TemplateExtension { get; private set; } = null;
        public static string TemporaryStore { get; private set; } = null;
        public static string PdfStore { get; private set; } = null;
        public static string PdfDestination { get; set; } = null;
        public static string DoctorListStore { get; set; } = null;


        public static string Cognome { get; set;  }
        public static string Nome { get; set;  }
        public static string CodiceFiscale { get; set; }
        public static string Indirizzo { get; set; }
        public static string DataNascita { get; set; }
        public static string LuogoNascita { get; set; }
        
        public static bool DottoreFromParameters { get; set; }
        public static string Dottore { get; set; }
    }
}
