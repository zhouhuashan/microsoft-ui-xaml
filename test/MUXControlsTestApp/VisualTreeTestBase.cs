using Common;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;
using MUXControls.TestAppUtils;
using PlatformConfiguration = Common.PlatformConfiguration;
using MUXControlsTestApp.Utilities;

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
    public enum CompareType
    {
        Dark,
        Default,
        HC
    }

    public class VisualTreeTestBase
    {
        public TestContext TestContext { get; set; }

        private string GetMasterFileContent(string fileName)
        {
            return GetMasterFileContentAsync(fileName).Result;
        }

        private async Task<string> GetMasterFileContentAsync(string fileName)
        {
            var uri = new Uri("ms-appx:///master/" + fileName);
            string content = "";

            try
            {
                var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
                content = await FileIO.ReadTextAsync(file);
            }
            catch (FileNotFoundException)
            {
                Verify.Fail("File not found: " + fileName);
            }
            return content;
        }

        private bool IsFilePresent(string fileName)
        {
            return IsFilePresentAsync(fileName).Result;
        }

        private async Task<bool> IsFilePresentAsync(string fileName)
        {
            var uri = new Uri("ms-appx:///master/" + fileName);
            try
            {
                var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
                await FileIO.ReadTextAsync(file);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }
        private void LogTextContent()
        {
            Log.Comment("FullyQualifiedTestClassName:" + TestContext.FullyQualifiedTestClassName);
            Log.Comment("TestName" + TestContext.TestName);
#if USING_TAEF
            Log.Comment(TestContext.TestRunResultsDirectory);
            Log.Comment(TestContext.TestRunDirectory);
            Log.Comment(TestContext.TestResultsDirectory);           
            Log.Comment("TestDir" + TestContext.TestDir);
            Log.Comment("TestLogsDir" + TestContext.TestLogsDir);
            Log.Comment("ResultsDirectory" + TestContext.ResultsDirectory);
            Log.Comment("TestDeploymentDir" + TestContext.TestDeploymentDir);
#endif
        }

        private async void WriteFile(string fileName, string content)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            Log.Comment(fileName + " is written to " + storageFolder.Path );
            await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        }
        private string GetTargetFileName(string fileNamePrefix)
        {
            return String.Format("{0}-{1}.xml", fileNamePrefix, PlatformConfiguration.GetCurrentAPIVersion());
        }

        private string GetMasterFileNameWithoutAPIVersion(string fileNamePrefix)
        {
            return fileNamePrefix + ".xml";
        }

        private string GetBestMatchedMasterFileName(string fileNamePrefix)
        {
            for (ushort version = PlatformConfiguration.GetCurrentAPIVersion(); version >= 2; version--)
            {
                var fileName = String.Format("{0}-{1}.xml", fileNamePrefix, version);
                if (IsFilePresent(fileName))
                {
                    return fileName;
                }
            }
            return GetMasterFileNameWithoutAPIVersion(fileNamePrefix);
        }

        private string GetMasterFilePrefix()
        {
            CheckTrue(TestContext != null, "Testframework should inject the TestContent but not");
            CheckTrue(!String.IsNullOrEmpty(TestContext.FullyQualifiedTestClassName), "FullyQualifiedTestClassName should not be empty");

            var name = TestContext.FullyQualifiedTestClassName.Split(new String[] { "ApiTests." }, StringSplitOptions.None)[1]?.Replace(".", "_");
            CheckTrue(!String.IsNullOrEmpty(name), "Have problem to get master file name for " + TestContext.FullyQualifiedTestClassName);

            return name;
        }

        private void _VisualTreeCompareAsync(UIElement root, String fileNamePrefix)
        {
            LogTextContent();

            string content = null;

            RunOnUIThread.Execute(() =>
            {
                content = VisualTreeDumper.DumpToXML(root);
            });

            var fileName = GetBestMatchedMasterFileName(fileNamePrefix);
            var targetFileName = GetTargetFileName(fileNamePrefix);

            Log.Comment("Target master file: " + targetFileName);
            Log.Comment("Best matched master file: " + targetFileName);
            bool same = false;
            if (IsFilePresent(fileName))
            {
            }
            if (!same)
            {
                WriteFile(targetFileName, content);
            }

        }

        protected void VisualTreeCompare(UIElement root, String partName)
        {
            var fileNamePrefix = String.Format("{0}_{1}", GetMasterFilePrefix(), partName);
             _VisualTreeCompareAsync(root, fileNamePrefix);
        }

        protected void VisualTreeCompare(UIElement root, CompareType type)
        {
            VisualTreeCompare(root, type.ToString());
        }

        private void CheckTrue(bool flag, string message)
        {
            if (!flag)
            {
                Verify.Fail(message);
            }
        }
        private void CompareXML()
        {

        }
    }
}
