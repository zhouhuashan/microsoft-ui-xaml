using Common;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;
using MUXControls.TestAppUtils;
using PlatformConfiguration = Common.PlatformConfiguration;

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

        private async Task<string> GetMasterFileContentAsync(string filename)
        {
            var uri = new Uri("ms-appx:///master/" + filename);
            var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            string content = "";
            try
            {
                content = await FileIO.ReadTextAsync(file);
            }
            catch (FileNotFoundException)
            {
                Verify.Fail("File not found: " + filename);
            }
            return content;
        }

        private async Task<bool> IsFilePresent(string filename)
        {
            var uri = new Uri("ms-appx:///master/" + filename);
            var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            try
            {
                await FileIO.ReadTextAsync(file);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        private async void WriteFile(string fileName, string content)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
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

        private async Task<string> GetBestMatchedMasterFileName(string fileNamePrefix)
        {
            for (ushort version = PlatformConfiguration.GetCurrentAPIVersion(); version >= 2; version--)
            {
                var fileName = String.Format("{0}-{1}.xml", fileNamePrefix, version);
                if (await IsFilePresent(fileName))
                {
                    return fileName;
                }
            }
            return GetMasterFileNameWithoutAPIVersion(fileNamePrefix);
        }

        private string GetMasterFilePrefix()
        {
            CheckTrue(TestContext == null, "Testframework should inject the TestContent but not");
            CheckTrue(String.IsNullOrEmpty(TestContext.FullyQualifiedTestClassName), "FullyQualifiedTestClassName should not be empty");

            var name = TestContext.FullyQualifiedTestClassName.Split(new String[] { "ApiTests" }, StringSplitOptions.None)[1]?.Replace(".", "_");
            CheckTrue(String.IsNullOrEmpty(name), "Have problem to get master file name for " + TestContext.FullyQualifiedTestClassName);

            return name;
        }

        private async Task _VisualTreeCompareAsync(UIElement root, String fileNamePrefix)
        {
            var content = VisualTreeDumper.DumpToXML(root);

            var fileName = await GetBestMatchedMasterFileName(fileNamePrefix);
            var targetFileName = GetTargetFileName(fileNamePrefix);

            Log.Comment("Target master file: " + targetFileName);
            Log.Comment("Best matched master file: " + targetFileName);
            bool same = false;
            if (await IsFilePresent(fileName))
            {
            }
            if (!same)
            {
                WriteFile(targetFileName, content);
            }

        }

        protected async void VisualTreeCompare(UIElement root, String partName)
        {
            var fileNamePrefix = String.Format("{0}_{1}", partName);
            await _VisualTreeCompareAsync(root, fileNamePrefix);
        }

        protected async void VisualTreeCompare(UIElement root, CompareType type)
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
