using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwagLabs_Test_Framework
{
    public class TestData
    {
        private static readonly string XmlFilePath = @"C:\Users\wajiz.pk\source\repos\SwagLabs_Test_Framework\SwagLabs_Test_Framework\Data.xml";

        public static IEnumerable<object[]> GetLoginTestData(string testCaseName)
        {
            XDocument doc = XDocument.Load(XmlFilePath);
            var testCases = doc.Descendants(testCaseName);
            List<object[]> testData = new List<object[]>();

            foreach (var testCase in testCases)
            {
                string url = testCase.Element("url").Value;
                string username = testCase.Element("username").Value;
                string password = testCase.Element("password").Value;

                testData.Add(new object[] { url, username, password });
            }

            return testData;
        }
    }
}
