﻿using System;
using System.Xml;
using System.Collections;
using System.Text;
using System.IO;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net.Mime;

public class Frame
{
    public int id;
    public float width;
    public float height;
    public float srcX;
    public float srcY;
    public float dstX;
    public float dstY;
    public float offsetX;
    public float offsetY;
    public float sourceSizeX;
    public float sourceSizeY;
}

public class Suite
{
    public ArrayList items = new ArrayList();
    public void Display()
    {
        foreach (Frame f in items)
        {
            Console.Write(f.id + " " + f.width + " " + f.height + " " + f.srcX + " " + f.srcY + "\n");
        }
    }
}


namespace Run
{
    class Class1
    {
        static float sourceSizeX = 177;
        static float sourceSizeY = 142;

        static float offSetX = 0;
        static float offSetY = 0;

        static int skipCount = 0;

        static Suite s = new Suite();
        static Suite s1 = new Suite();
        public static void DeSerializeFile(string filename)
        {
            XmlTextReader xtr = new XmlTextReader(filename);
            xtr.WhitespaceHandling = WhitespaceHandling.None;
            xtr.Read();

            while (!xtr.EOF) //load loop
            {
                if (xtr.Name == "frameset" && !xtr.IsStartElement())
                    break;

                while (xtr.Name != "frame" || !xtr.IsStartElement())
                    xtr.Read();

                while (xtr.Name != "frame" || !xtr.IsStartElement())
                    xtr.Read();
                
                Frame f = new Frame();
                f.id = Convert.ToInt16(xtr.GetAttribute("id"));
                f.width = Convert.ToSingle(xtr.GetAttribute("width"));
                f.height = Convert.ToSingle(xtr.GetAttribute("height"));
                f.srcX = Convert.ToSingle(xtr.GetAttribute("srcX"));
                f.srcY = Convert.ToSingle(xtr.GetAttribute("srcY"));
                f.dstX = Convert.ToSingle(xtr.GetAttribute("dstX"));
                f.dstY = Convert.ToSingle(xtr.GetAttribute("dstY"));
                f.sourceSizeX = f.width;
                f.sourceSizeY = f.height;

                f.offsetX = f.dstX + (float)Math.Floor(f.width / 2) - sourceSizeX / 2;
                f.offsetY = f.dstY + (float)Math.Floor(f.height / 2) - sourceSizeY / 2;

                //f.dstX = 0;
                //f.dstY = 0;

                s.items.Add(f);

                xtr.Read();
            }

            xtr.Close();
        }

        public static void DeSerializePLST(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/plist/dict/dict");
 
            foreach (XmlNode node in nodes)
            {
                XmlNodeList dicts = node.SelectNodes("dict");
                foreach (XmlNode dict in dicts)
                {
                    XmlNodeList datas = dict.SelectNodes("string");
                    Frame f = new Frame();

                    string test = datas[0].InnerText;
                    test = System.Text.RegularExpressions.Regex.Replace(test, "{", string.Empty);
                    string[] result = System.Text.RegularExpressions.Regex.Replace(test, "}", string.Empty).Split(',');
                    f.srcX = Convert.ToSingle(result[0]);
                    f.srcY = Convert.ToSingle(result[1]);
                    f.width = Convert.ToSingle(result[2]);
                    f.height = Convert.ToSingle(result[3]);

                    test = datas[1].InnerText;
                    test = System.Text.RegularExpressions.Regex.Replace(test, "{", string.Empty);
                    result = System.Text.RegularExpressions.Regex.Replace(test, "}", string.Empty).Split(',');
                    f.offsetX = Convert.ToSingle(result[0]);
                    f.offsetY = Convert.ToSingle(result[1]);

                    test = datas[2].InnerText;
                    test = System.Text.RegularExpressions.Regex.Replace(test, "{", string.Empty);
                    result = System.Text.RegularExpressions.Regex.Replace(test, "}", string.Empty).Split(',');
                    f.dstX = Convert.ToSingle(result[0]);
                    f.dstY = Convert.ToSingle(result[1]);
                    //f.width = Convert.ToSingle(result[2]);
                    //f.height = Convert.ToSingle(result[3]);
                    f.dstX = Convert.ToSingle(result[0]) + offSetX;
                    f.dstY = Convert.ToSingle(result[1]) + offSetY;

                    test = datas[3].InnerText;
                    test = System.Text.RegularExpressions.Regex.Replace(test, "{", string.Empty);
                    result = System.Text.RegularExpressions.Regex.Replace(test, "}", string.Empty).Split(',');
                    f.sourceSizeX = Convert.ToSingle(result[0]);
                    f.sourceSizeY = Convert.ToSingle(result[1]);


                    s1.items.Add(f);
                }
            }

            int count = 0;
            foreach (Frame f in s1.items)
            {
                Console.Write(count++ + " " + f.width + " " + f.height + " " + f.dstX + " " + f.dstY + "\n");
            }

        }

        public static void SerializeFile(string filename, int skipcount)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            XmlWriter xmlWriter = XmlWriter.Create(filename);           
            xmlWriter.WriteStartDocument();
            //xmlWriter.WriteRaw("\n<!DOCTYPE plist PUBLIC \"-//Apple Compuhmxdcc ter//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">");


            xmlWriter.WriteRaw("\n");
            xmlWriter.WriteStartElement("plist");

            xmlWriter.WriteString("\n\t");
            xmlWriter.WriteStartElement("dict");
            xmlWriter.WriteString("\n\t\t");

            xmlWriter.WriteStartElement("key");
            xmlWriter.WriteString("frames");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t");
            xmlWriter.WriteStartElement("dict");

            int i = 0;
            int j = 0;

            foreach (Frame f1 in s.items)
            {
                if (i % (skipcount + 1) == 0 || i == s.items.Count - 1)
                {                
                    Frame f = (Frame)s1.items[j];
                    j++;
                    xmlWriter.WriteString("\n\t\t\t");
                    xmlWriter.WriteStartElement("key");
                    xmlWriter.WriteString(f.id.ToString());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n\t\t\t");

                    xmlWriter.WriteStartElement("dict");
                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteStartElement("key");
                    xmlWriter.WriteString("frame");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteStartElement("string");
                    xmlWriter.WriteString("{{" + f.srcX.ToString() + "," + f.srcY.ToString() + "},{" + f.width.ToString() + "," + f.height.ToString() + "}}");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteStartElement("key");
                    xmlWriter.WriteString("offset");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteStartElement("string");
                    xmlWriter.WriteString("{" + f.offsetX.ToString() + "," + f.offsetY.ToString() + "}");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteStartElement("key");
                    xmlWriter.WriteString("rotated");
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteRaw("<false/>");

                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteStartElement("key");
                    xmlWriter.WriteString("sourceColorRect");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteStartElement("string");
                    xmlWriter.WriteString("{{" +f1.dstX.ToString() + "," + f1.dstY.ToString() + "},{" + f.width.ToString() + "," + f.height.ToString() + "}}");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteStartElement("key");
                    xmlWriter.WriteString("sourceSize");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n\t\t\t\t");
                    xmlWriter.WriteStartElement("string");
                    xmlWriter.WriteString("{" + f.sourceSizeX.ToString() + "," + f.sourceSizeY.ToString() + "}");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n\t\t\t");
                    xmlWriter.WriteEndElement();
                }

                i++;
            }

            xmlWriter.WriteString("\n\t\t");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t");
            xmlWriter.WriteStartElement("key");
            xmlWriter.WriteString("metadata");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t");
            xmlWriter.WriteStartElement("dict");

            //<key>format</key>
            //<integer>2</integer>
            //<key>realTextureFileName</key>
            //<string>btn_auto_reveal.png</string>
            //<key>size</key>
            //<string>{75,182}</string>
            //<key>smartupdate</key>
            //<string>$TexturePacker:SmartUpdate:1844f17c593efd66a17e1b8f8927f70b:92bb3766691a5860fc902b3337f0300e:6adee6037a497b339c291882744e9406$</string>
            //<key>textureFileName</key>
            //<string>btn_auto_reveal.png</string>

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("key");
            xmlWriter.WriteString("format");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("integer");
            xmlWriter.WriteString("2");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("key");
            xmlWriter.WriteString("realTextureFileName");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("string");
            xmlWriter.WriteString("finalfilename.png");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("key");
            xmlWriter.WriteString("size");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("string");
            xmlWriter.WriteString("{}");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("key");
            xmlWriter.WriteString("smartupdate");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("string");
            xmlWriter.WriteString("{}");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("key");
            xmlWriter.WriteString("textureFileName");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t\t");
            xmlWriter.WriteStartElement("string");
            xmlWriter.WriteString("finalfilename.png");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t\t");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteString("\n\t");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteString("\n");
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        [STAThread]
        static void Main(string[] args)
        {


            string path = Directory.GetCurrentDirectory();

            string[] configFileEntries = Directory.GetFiles(path, "convertConfig*");
            if (configFileEntries.Length != 0)
            {
                XmlTextReader xtr = new XmlTextReader(configFileEntries[0]);
                xtr.WhitespaceHandling = WhitespaceHandling.None;
                xtr.Read();
                skipCount = 1;// Convert.ToInt16(xtr.GetAttribute("SkipFrames"));
                offSetX = Convert.ToInt16(xtr.GetAttribute("offSetX"));
                offSetY = Convert.ToInt16(xtr.GetAttribute("offSetY"));
                xtr.Close();
            }
            
            string[] xmlfileEntries = Directory.GetFiles(path, "test*");
            string[] fileEntries = Directory.GetFiles(path, "frames*");

            Directory.CreateDirectory(path + "\\test");
            Console.WriteLine("The number of files starting with c is {0}.", fileEntries.Length);
            foreach (string fileName in xmlfileEntries)
            {
                DeSerializeFile(fileEntries[0]);
                DeSerializePLST(fileName);
                int index = fileName.LastIndexOf("\\");
                string resultFilename = fileName.Insert(index + 1, "test\\");

                //s.Display();
                SerializeFile(resultFilename, skipCount);
                s = new Suite();
            }

            //DeSerializeFile("..\\..\\..\\..\\testCases.xml");
            //SerializeFile("test1.xml");
            
        }     


    } 
}
