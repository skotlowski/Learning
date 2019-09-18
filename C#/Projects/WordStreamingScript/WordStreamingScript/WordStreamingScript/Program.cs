﻿using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WordStreamingScript
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"E:\Learning\C#\Projects\WordStreamingScript\WordStreamingScript\WordStreamingScript\bin\Debug", "str*.xml");
            foreach (string file in files)
            {
                ProcessFile(file);
            }
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i]);
                XmlDocument xml = new XmlDocument();
                xml.Load(files[i]);

                XmlNodeList xnList = xml.SelectNodes("/Names/Name");
                foreach (XmlNode xn in xnList)
                {
                    using (StreamWriter StreamW = new StreamWriter((@"E:\Learning\C#\Projects\WordStreamingScript\WordStreamingScript\WordStreamingScript\bin\Debug\lol.txt"), true))
                    {
                        StreamW.WriteLine(xn.InnerText);
                    }
                }
            }

            /*string[] files = Directory.GetFiles(@"E:\Learning\C#\Projects\WordStreamingScript\WordStreamingScript\WordStreamingScript\bin\Debug", "cos*.xml");
            foreach (string file in files)
            {
                ProcessFile(file);
            }

            for (int i = 0; i < files.Length; i++)
            {
                using (StreamReader StreamR = new StreamReader(files[i]))
                {
                    string oneLine;

                    using (StreamWriter StreamW = new StreamWriter((@"E:\Learning\C#\Projects\WordStreamingScript\WordStreamingScript\WordStreamingScript\bin\Debug\czyt.txt"), true))
                    {

                        while ((oneLine = StreamR.ReadLine()) != null)
                        {
                            StreamW.WriteLine(oneLine);
                            
                        }
                    }
                }
            }
        }*/
        }
        public static void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}',", path);
        }
        }
    }
