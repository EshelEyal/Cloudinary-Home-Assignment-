using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestForTest
{
    public class Utiils
    {
        public static Dictionary<string, string> TestData = new Dictionary<string, string>();

        public static void GetTestData()
        {
            string[] lines = File.ReadAllLines(".\\DataForTest.txt");

            var pairs = lines.Select(l => new { Line = l, Pos = l.IndexOf("=") });

            var dictionary = pairs.ToDictionary(p => p.Line.Substring(0, p.Pos), p => p.Line.Substring(p.Pos + 1));

            foreach (var item in dictionary)
            {
                TestData.Add(item.Key, item.Value);
            }
        }

        public static string GetScreenShot(string imageName,IWebDriver driver)
        {
            if (String.IsNullOrEmpty(imageName))
            {
                imageName = "blank";
            }

            var shotPath = "Target/ScreenShots/";
            string ScreenShotPath = Assembly.GetCallingAssembly().CodeBase;
            string shotPathActualPath = ScreenShotPath.Substring(0, ScreenShotPath.LastIndexOf("bin"));
            string reporProjectPath = new Uri(shotPathActualPath).LocalPath;
            string reportDirectoryPath = reporProjectPath + shotPath;


            string path = reportDirectoryPath + imageName + " - " + GetCurrentDateAndTime() + ".png";
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }

        public static string GetCurrentDateAndTime()
        {
            System.Globalization.DateTimeFormatInfo dti = new System.Globalization.DateTimeFormatInfo();
            DateTime dateTime = DateTime.Now;
            string CurrentDateAndTime = dateTime.ToString("dd-MM-yyyy HH_mm_ss", dti);
            return CurrentDateAndTime;
        }

    }
}
