﻿using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WordStreamingScript
{
    class Program
    {
        static void Main(string[] args)
        {

             int num;
             Console.WriteLine("Enter xml directory");
             string path = Console.ReadLine();
             string[] files = Directory.GetFiles(@path, "*.xml", SearchOption.AllDirectories);
             foreach (string file in files)
             {
                 ProcessFile(file);
             }

             foreach (string dirPath in Directory.GetDirectories(@path, "*", SearchOption.AllDirectories))
             
                Directory.CreateDirectory(dirPath.Replace(@path, @path + @"\temp\"));
             
 
            foreach (string newPath in Directory.GetFiles(@path, "*.xml*", SearchOption.AllDirectories))
             
                File.Copy(newPath, newPath.Replace(@path, @path + @"\temp\"), true);
             

             Console.WriteLine("Zrzucenie nazw obiektów do txt - wciśnij 1");
             Console.WriteLine("Zamiana nazw obiektów - wciśnij 2");
             Console.WriteLine("First letter to Uppercase");
             num = Convert.ToInt32(Console.ReadLine());

             string name = null;
             string newName = null;

             if (num == 2)
             {
                 Console.WriteLine("Enter element value to change");
                 name = Console.ReadLine();
                 Console.WriteLine("Enter new element value");
                 newName = Console.ReadLine();
             }
             for (int i = 0; i < files.Length; i++)
             {

                 Console.WriteLine(files[i]);
                 XmlDocument xml = new XmlDocument();
                 xml.Load(files[i]);
                 XmlNodeList xnList = xml.SelectNodes("/Names/Name");

                 switch (num)
                 {

                     case 1:
                         foreach (XmlNode xn in xnList)
                         {
                             using (StreamWriter StreamW = new StreamWriter((@path+@"/temp/temp.txt"), true))

                             {
                                 StreamW.WriteLine(xn.InnerText);
                             }
                         }
                         File.WriteAllLines(@path+" ClassNames.txt", File.ReadAllLines(@path+@"/temp/temp.txt").Distinct());
                         break;

                     case 2:


                         var doc = XDocument.Load(files[i]);
                         var elementsToUpdate = doc.Descendants()
                                                   .Where(o => o.Value == name && !o.HasElements); ;

                         foreach (XElement element in elementsToUpdate)
                         {
                             element.Value = newName;
                         }
                         doc.Save(files[i]);
                         break;

                    /* case 3:

                         foreach (XmlNode xn in xnList)
                         {
                             UppercaseFirst(xn.Value);
                         }
                         xml.Save(files[i]);
                         break; */
                 }
             }
             File.Delete(@path+@"/temp/temp.txt");
         }
         static void ProcessFile(string path)
         {
             Console.WriteLine("Processed file '{0}',", path);
         }
         /*static string UppercaseFirst(string s)
         {
             if (string.IsNullOrEmpty(s))
             {
                 return string.Empty;
             }
             return char.ToUpper(s[0]) + s.Substring(1);
         } */
        }
    }