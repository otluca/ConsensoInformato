using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsensoInformato2
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione...
        /// </summary>
        [STAThread]
        static void Main()
        {
            Common.InitCommon();

            DecodeArguments();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConsensiController controller = new ConsensiController();
            FormMain mainForm = new FormMain();
            mainForm.SetController(controller);

            controller.StartUp();

            Application.Run(mainForm);

            mainForm.SetController(null);
            controller.ShutDown();
        }

        private static void DecodeArguments()
        {
            var args = Environment.GetCommandLineArgs();
            string value;
            int i = 1;

            (int, string) EvalValue(int iPar)
            {
                string result = string.Empty;
                value = args[iPar + 1];
                if (!value.StartsWith("/")) {
                    result = value;
                    iPar++;
                }
                return (iPar, result);
            }

            for (; i < args.Length - 1; i++) {
                switch (args[i].ToLower()) {
                    case "/cognome":
                        (i, Common.Cognome) = EvalValue(i);
                        break;
                    case "/nome":
                        (i, Common.Nome) = EvalValue(i);
                        break;
                    case "/codicefiscale":
                        (i, Common.CodiceFiscale) = EvalValue(i);
                        break;
                    case "/indirizzo":
                        (i, Common.Indirizzo) = EvalValue(i);
                        break;
                    case "/datanascita":
                        (i, Common.DataNascita) = EvalValue(i);
                        break;
                    case "/luogonascita":
                        (i, Common.LuogoNascita) = EvalValue(i);
                        break;
                    case "/dottore":
                        Common.DottoreFromParameters = true;
                        (i, Common.Dottore) = EvalValue(i);
                        break;
                    case "/destinazione":
                        (i, Common.PdfDestination) = EvalValue(i);
                        break;

                }
            }
        }
    }
}
