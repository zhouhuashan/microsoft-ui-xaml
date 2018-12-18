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
        }
    }
}
