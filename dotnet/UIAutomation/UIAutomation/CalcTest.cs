using Microsoft.Test.Input;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Automation;

namespace UIAutomation
{
    public class CalcTest
    {
        string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\app\calculator.exe");
        Process _process;
        AutomationElement _main;
        IEnumerable<AutomationElement> _buttons;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            foreach (var process in Process.GetProcessesByName("calculator"))
            {
                process.Kill();
            }

            _process = Process.Start(_path);
            GetMainWindow();
            _buttons = _main.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button))
                .Cast<AutomationElement>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _process.Kill();
        }

        [SetUp]
        public void SetUp()
        {
            Do(new[] { "C" });
        }

        [TestCase(new[] { "1", "+", "1", "0", "=" }, "11")]
        [TestCase(new[] { "1", "0", "1", "-", "5", "1", "/", "2", "=" }, "25")]
        [TestCase(new[] { "9", "*", "9", "9", "-", "9", "1", "/", "1", "0", "0", "=" }, "8")]
        public void CalcalateTest(string[] keys, string result)
        {
            Do(keys);
            ValidateResult(result);
        }

        private void MouseClickAtPoint(System.Windows.Point point, MouseButton mouseButton = MouseButton.Left)
        {
            MouseClickAtPoint(new System.Drawing.Point((int)point.X, (int)point.Y));
        }

        private void MouseClickAtPoint(System.Drawing.Point point, MouseButton mouseButton = MouseButton.Left)
        {
            Mouse.MoveTo(point);
            Mouse.Click(mouseButton);
        }

        private void Do(IEnumerable<string> inputs)
        {
            foreach (var i in inputs)
            {
                var b = _buttons.First(_ => _.Current.Name.Equals(i));
                MouseClickAtPoint(b.GetClickablePoint());
            }
        }

        private void ValidateResult(string expected)
        {
            var eE = _main.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit))
                .GetCurrentPattern(ValuePatternIdentifiers.Pattern) as ValuePattern;

            Assert.AreEqual(expected, eE.Current.Value);
        }

        private void GetMainWindow()
        {
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    _main = AutomationElement.FromHandle(_process.MainWindowHandle);
                    break;
                }
                catch(ArgumentException)
                { }

                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
