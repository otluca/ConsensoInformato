using ConsensoInformato2;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsensoInformato2.Tests
{
    [TestClass()]
    public class ConsensiModelTest
    {
        public ConsensiModelTest()
        {
            Common.InitCommon();
        }


        [TestMethod()]
        public void LoadTemplatesTest()
        {
            var newModel = new ConsensiModel();
            newModel.LoadTemplates();
            var numberOfTemplates = newModel.ConsensoTemplates.Count;
            Assert.IsTrue(numberOfTemplates > 0);

            var label = newModel.ConsensoTemplates[0].FileLabel;
            //MEMO: Questo test passa ovviamente se il primo modello si chiama ANESTESIA.
            //      Cambiare se del caso.
            Assert.IsTrue(label == "ANESTESIA");
        }
    }
}

