using Common;

#if USING_TAEF
using WEX.TestExecution;
using WEX.TestExecution.Markup;
using WEX.Logging.Interop;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
#endif

namespace Windows.UI.Xaml.Tests.MUXControls.ApiTests
{  
    public class VisualTreeTestBase
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void setup()
        {
            Log.Comment(" SETUP " + TestContext.TestName);
            Log.Comment(GetMasterFile("XMLFile1"));
        }
        
        protected string GetMasterFile(string fileNameNoExtension)
        {
            var uri = new Windows.Foundation.Uri("ms-appx:///master/" + fileNameNoExtension + ".xml");
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
            return await Windows.Storage.FileIO.ReadTextAsync(file);
        }
    }
}
