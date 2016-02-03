using System;
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

        static Suite s = new Suite(); 
        static Suite s1 = new Suite();

        //read function for NEW data file
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
                    //Console.WriteLine("Data0: Result[0] is {0}.", result[0]);
                    //Console.WriteLine("Data0: Result[1] is {0}.", result[1]);
                   // Console.WriteLine("Data0: Result[2] is {0}.", result[2]);
                   // Console.WriteLine("Data0: Result[3] is {0}.", result[3]);

                    test = datas[1].InnerText;
                    test = System.Text.RegularExpressions.Regex.Replace(test, "{", string.Empty);
                    result = System.Text.RegularExpressions.Regex.Replace(test, "}", string.Empty).Split(',');
                    f.offsetX = Convert.ToSingle(result[0]);
                    f.offsetY = Convert.ToSingle(result[1]);
                    //Console.WriteLine("Data1: Result[0] is {0}.", result[0]);
                    //Console.WriteLine("Data1: Result[1] is {0}.", result[1]);


                    test = datas[2].InnerText;
                    test = System.Text.RegularExpressions.Regex.Replace(test, "{", string.Empty);
                    result = System.Text.RegularExpressions.Regex.Replace(test, "}", string.Empty).Split(',');
                    f.dstX = Convert.ToSingle(result[0]);
                    f.dstY = Convert.ToSingle(result[1]);
                    //Console.WriteLine("Data2: Result[0] is {0}.", result[0]);
                    //Console.WriteLine("Data2: Result[1] is {0}.", result[1]);

                    test = datas[3].InnerText;
                    test = System.Text.RegularExpressions.Regex.Replace(test, "{", string.Empty);
                    result = System.Text.RegularExpressions.Regex.Replace(test, "}", string.Empty).Split(',');
                    f.sourceSizeX = Convert.ToSingle(result[0]);
                    f.sourceSizeY = Convert.ToSingle(result[1]);
                    //Console.WriteLine("Data3: Result[0] is {0}.", result[0]);
                    //Console.WriteLine("Data3: Result[1] is {0}.", result[1]);

                    s.items.Add(f);

                }
            }

            int count = 0;
            foreach (Frame f in s1.items)
            {
                Console.Write(count++ + " " + f.width + " " + f.height + " " + f.dstX + " " + f.dstY + "\n");
            }

        }

		//read function for OLD data file
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

                Frame f = new Frame();
                f.id = Convert.ToInt16(xtr.GetAttribute("id"));
                f.width = Convert.ToSingle(xtr.GetAttribute("width"));
                f.height = Convert.ToSingle(xtr.GetAttribute("height"));
                f.srcX = Convert.ToSingle(xtr.GetAttribute("srcX"));
                f.srcY = Convert.ToSingle(xtr.GetAttribute("srcY"));
                f.dstX = Convert.ToSingle(xtr.GetAttribute("dstX"));
                f.dstY = Convert.ToSingle(xtr.GetAttribute("dstY"));

                f.offsetX = f.dstX + (float)Math.Floor(f.width / 2) - sourceSizeX / 2;
                f.offsetY = f.dstY + (float)Math.Floor(f.height / 2) - sourceSizeY / 2;

                f.dstX = 0;
                f.dstY = 0;

                s.items.Add(f);

                xtr.Read();
            }

            xtr.Close();
        }


        //dnqbybyjmain
        [STAThread]
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string[] fileEntries = Directory.GetFiles(path, "*.xml");
            Console.WriteLine("The number of files starting with c is {0}.", fileEntries.Length);

            foreach (string fileName in fileEntries)
            {
                s = new Suite();
                DeSerializePLST(fileName);

                string resultFilename = fileName;
                resultFilename = resultFilename.Remove(resultFilename.IndexOf(".xml"));


                CuttingImage(resultFilename);

            }
        }

        static Image cropPngImage(Bitmap img, Rectangle cropArea)
        {
            Bitmap bmpCrop = img.Clone(cropArea,
                                 img.PixelFormat);
            
            return (Image)(bmpCrop);
        }

        static void CuttingImage(string fileName)
        {
            Image img = Image.FromFile(fileName + ".png");
            int count = 0;


            foreach (Frame f in s.items)
            {
                
                string path = Directory.GetCurrentDirectory();
                // Create bitmap.
                Bitmap transparentCanvas = new Bitmap((int)f.sourceSizeX, (int)f.sourceSizeY, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(transparentCanvas))
                {
                    // Draws a black background
                    g.Clear(Color.Transparent);
                }
                string fc = string.Format("{0:000}", count);


                Bitmap bmpImage = new Bitmap(img);
                if (f.width == 0 || f.height == 0)
                {
                    transparentCanvas.Save(fileName + "_" + fc + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    Image resultImg = cropPngImage(bmpImage, new Rectangle((int)(f.srcX), (int)(f.srcY), (int)(f.width), (int)(f.height)));
                    System.Drawing.Image canvas = transparentCanvas;
                    Graphics gra = Graphics.FromImage(canvas);
                    Bitmap smallImg = new Bitmap(resultImg);
                    bmpImage.Dispose();
                    gra.DrawImage(smallImg, new Point((int)f.dstX, (int)f.dstY));
                    canvas.Save(fileName + "_" + fc + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                count++;
            }
          
        }


    } 
}
