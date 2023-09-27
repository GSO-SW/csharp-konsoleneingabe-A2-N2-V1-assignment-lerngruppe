using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Tests_Aufgabe1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("Avinash", "Nilay", (Int16)17, 1.76, true)]
        public void Test_InOut1(string value_1, string value_2, short value_3, double value_4, bool value_5)
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);


            var textReader = new StringReader(@$"{value_1}
{value_2}
{value_3}
{value_4}
{value_5}");

            Console.SetIn(textReader);

            // Act
            Aufgabe_1.Aufgabe1();

            // Assert

            List<string> lines_list_check = new List<string> { $"{"Vorname:",-10}{value_1}", $"{"Nachname:",-10}{value_2}", $"{"Alter:",-10}{value_3}", $"{"Größe:",-10}{value_4}", $"{"ProgErf:",-10}{value_5}" };

            AssertTest(writer, lines_list_check);

        }



        [TestMethod, TestCategory("CategoryB")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("Avinash", "Nilay", (Int16)17, 1.76, true)]

        public void Test_InOut2(string value_1, string value_2, short value_3, double value_4, bool value_5)
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

  
            var textReader = new StringReader(@$"{value_1}
{value_2}
{value_3}
{value_4}
{value_5}");

            Console.SetIn(textReader);

            // Act
            var results = Aufgabe_1.Aufgabe1();
            List<object> list_res = new List<object>() { results.Item1, results.Item2, results.Item3, results.Item4, results.Item5 };
            List<object> list_test = new List<object>() { value_1, value_2, value_3, value_4, value_5 };

            // Assert


            for (int i = 0; i < list_res.Count; i++)
            {

                try
                {
                    if (list_res[i].GetType() == list_test[i].GetType())
                    {
                        Assert.AreEqual(list_res[i], list_test[i]);
                    }
                    else
                    {
                        string[] var_namen = new string[] { "'vorname'", "'nachname'", "'alter'", "'groesse'", "'erste_ps'" };

                        Trace.WriteLine($"Fehler: Datentyp nicht korrekt!");
                        Trace.WriteLine($"Datentyp von {var_namen[i]} -> {list_res[i].GetType()} ist ungleich {list_test[i].GetType()}");
                        Assert.Fail();
                    }
                }
                catch (NullReferenceException e)
                {
                    string[] var_namen = new string[] { "'vorname'", "'nachname'", "'alter'", "'groesse'", "'erste_ps'" };

                    Trace.WriteLine($"Fehler: Datentyp nicht korrekt!");
                    Trace.WriteLine($"Datentyp von {var_namen[i]} -> Null ist ungleich {list_test[i].GetType()}");
                    Trace.WriteLine($"Exception: {e}");
                    Assert.Fail();
                }



            }

        }


        [TestMethod, TestCategory("CategoryC")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("Avinash", "Nilay", "test", 1.76, true)]
        public void Test_InOut3(string value_1, string value_2, string value_3, double value_4, bool value_5)
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);


            var textReader = new StringReader(@$"{value_1}
{value_2}
{value_3}
{value_4}
{value_5}");

            Console.SetIn(textReader);

            // Act
            Aufgabe_1.Aufgabe1();

            // Assert

            List<string> lines_list_check = new List<string> { "Falsche Eingabe!" };
            AssertTest(writer, lines_list_check);


        }
        [TestMethod, TestCategory("CategoryC")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("Avinash", "Nilay", (Int16)17, "test", true)]
        public void Test_InOut4(string value_1, string value_2, short value_3, string value_4, bool value_5)
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);


            var textReader = new StringReader(@$"{value_1}
{value_2}
{value_3}
{value_4}
{value_5}");

            Console.SetIn(textReader);

            // Act
            Aufgabe_1.Aufgabe1();

            // Assert

            List<string> lines_list_check = new List<string> { "Falsche Eingabe!" };
            AssertTest(writer,lines_list_check);


        }
        
        [TestMethod, TestCategory("CategoryC")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("Avinash", "Nilay", (Int16)17, 1.76, "test")]
        public void Test_InOut5(string value_1, string value_2, short value_3, double value_4, string value_5)
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);


            var textReader = new StringReader(@$"{value_1}
{value_2}
{value_3}
{value_4}
{value_5}");

            Console.SetIn(textReader);

            // Act
            Aufgabe_1.Aufgabe1();

            // Assert

            List<string> lines_list_check = new List<string> { "Falsche Eingabe!" };
            AssertTest(writer, lines_list_check);


        }
        public static void AssertTest(StringWriter writer, List<string> lines_list_check)
        {

            // Assert

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            List<string> lines_list = new List<string>();

            //Bedingung nötig da 'Enviroment.NewLine' in Git Actions nicht funktioniert.
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    lines_list.Add(lines[i]);
                    Debug.WriteLine($"{lines[i]}");
                }
            }





            lines_list = lines_list.Intersect(lines_list_check).ToList();


            for (int i = 0; i < lines_list_check.Count; i++)
            {

                try
                {
                    if (lines_list[i] != lines_list_check[i]) Trace.WriteLine($"\nFehler: '{lines_list_check[i]}' nicht gefunden");
                    Assert.AreEqual(lines_list[i], lines_list_check[i]);
                }
                catch
                {
                    Trace.WriteLine($"Fehler: Zeile fehlt");
                    Trace.WriteLine($"{lines_list_check[i]}");
                    Assert.Fail(); ;

                }

            }
        }

    }
}
