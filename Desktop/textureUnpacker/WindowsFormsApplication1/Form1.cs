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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mime;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Suite s = new Suite();
        static Suite s1 = new Suite();

        static Boolean existing = false;
        static int index;

        OpenFileDialog ofd = new OpenFileDialog();
        FolderBrowserDialog fbd = new FolderBrowserDialog();

        static string ofdImageFileName;
        static string ofdDataFileName;
        static string fbdDirectoryName;
        static string ofdOutputDirectoryName;
        static string fbdOutputFileName;
        static string uniqueDataFile;

        Image showingImage;
        private void buttonSourceImage_Click(object sender, EventArgs e)
        {
            ofd.Filter = "PNG|*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //source imgae file
                ofdImageFileName = ofd.FileName;
                textBox1.Text = ofdImageFileName;

                //view image source
                if(showingImage != null) showingImage.Dispose();
                showingImage = Image.FromFile(ofdImageFileName);
                if (showingImage.Width >= 356)
                    showingImage = resizeImage(showingImage, new Size(356, showingImage.Height));
                if(showingImage.Height >= 216)
                    showingImage = resizeImage(showingImage, new Size(showingImage.Width, 216));
                pictureBox1.Image = showingImage;

                if (autoFill.Checked == true)
                {
                    //source data file
                    ofdDataFileName = ofdImageFileName.Remove(ofdImageFileName.Length - 4);
                    ofdDataFileName = ofdDataFileName + ".xml";
                    textBox2.Text = ofdDataFileName;

                    //output directory name
                    ofdOutputDirectoryName = ofdImageFileName.Remove(ofdImageFileName.Length - ofd.SafeFileName.Length);
                    textBox4.Text = ofdOutputDirectoryName;

                    //output file name
                    fbdOutputFileName = ofd.SafeFileName.Remove(ofd.SafeFileName.Length - 4);
                    textBox5.Text = fbdOutputFileName;
                }
            }
        }
        private void btnSourceData_Click(object sender, EventArgs e)
        {
            ofd.Filter = "XML|*.XML";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //source data file
                ofdDataFileName = ofd.FileName;
                textBox2.Text = ofdDataFileName;

                if (autoFill.Checked == true)
                {
                    //source imgae file
                    ofdImageFileName = ofdDataFileName.Remove(ofdDataFileName.Length - 4);
                    ofdImageFileName = ofdImageFileName + ".png";
                    textBox1.Text = ofdImageFileName;
                    pictureBox1.ImageLocation = ofdImageFileName;

                    //output directory name
                    ofdOutputDirectoryName = ofdDataFileName.Remove(ofdDataFileName.Length - ofd.SafeFileName.Length);
                    textBox4.Text = ofdOutputDirectoryName;

                    //output file name
                    fbdOutputFileName = ofd.SafeFileName.Remove(ofd.SafeFileName.Length - 4);
                    textBox5.Text = fbdOutputFileName;
                }
            }
        }
        private void buttonSourceDirectory_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //source directory
                fbdDirectoryName = fbd.SelectedPath;
                textBox3.Text = fbdDirectoryName;

                if (autoFill.Checked == true)
                {
                    //output directory name
                    ofdOutputDirectoryName = fbdDirectoryName;
                    textBox4.Text = ofdOutputDirectoryName;
                }
            }
        }
        private void btnOutputDirectory_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //source directory
                ofdOutputDirectoryName = fbd.SelectedPath;
                textBox4.Text = ofdOutputDirectoryName;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ofdImageFileName = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ofdDataFileName = textBox2.Text;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            fbdDirectoryName = textBox3.Text;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ofdOutputDirectoryName = textBox4.Text;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            fbdOutputFileName = textBox5.Text;
        }


        private void radioButtonFile_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;

            textBox3.Enabled = false;
        }
        private void radioButtonFolder_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = true;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }
        private void checkBoxAutoFill_CheckedChanged(object sender, EventArgs e)
        {}
        private void checkBoxNoRepeat_CheckedChanged(object sender, EventArgs e)
        {}


        private void pictureBox1_Click(object sender, EventArgs e)
        {}
        private void Form1_Load(object sender, EventArgs e)
        {}


        private void btnCut_Click(object sender, EventArgs e)
        {
            if (fileType.Checked)
            {
                if (ofdImageFileName == null || !File.Exists(ofdImageFileName))
                    System.Windows.Forms.MessageBox.Show("Can't Find Image File");
                else if (ofdDataFileName == null || !File.Exists(ofdDataFileName))
                    System.Windows.Forms.MessageBox.Show("Can't Find Data File");
                else
                {
                    s = new Suite();
                    if (cocos2DAtlas.Checked)
                    {
                        DeSerializeNewDataFile(ofdDataFileName);
                    }
                    else
                    {
                        DeSerializeOldDataFile(ofdDataFileName);
                    }

                    if(s.items.Count > 0)
                        CuttingImage(ofdImageFileName);
                }
            }
            else
            {
                if (!Directory.Exists(fbdDirectoryName))
                    System.Windows.Forms.MessageBox.Show("Can't Find Path");
                else
                {
                    string path = fbdDirectoryName;
                    string[] fileEntries = Directory.GetFiles(path, "*.xml");

                    foreach (string fileName in fileEntries)
                    {
                        s = new Suite();
                        if (cocos2DAtlas.Checked)
                        {
                            DeSerializeNewDataFile(fileName);
                        }
                        else
                        {
                            DeSerializeOldDataFile(fileName);
                        }

                        if (s.items.Count > 0)
                            CuttingImage(ofdImageFileName);

                    }
                }
            }

        }
        private void buttonFormRepeatImg_Click(object sender, EventArgs e)
        {
            if (fileType.Checked)
            {
                if (ofdImageFileName == null || !File.Exists(ofdImageFileName))
                    MessageBox.Show(string.Format("Can't Find Image File: {0}", ofdImageFileName), "Warning", MessageBoxButtons.OK);
                else if (ofdDataFileName == null || !File.Exists(ofdDataFileName))
                    MessageBox.Show(string.Format("Can't Find Data File: {0}", ofdDataFileName), "Warning", MessageBoxButtons.OK);
                else
                {
                    CreateImg();
                }
            }
            else
            {
                /*
                if (ofdImageFileName == null || !File.Exists(ofdImageFileName))
                    System.Windows.Forms.MessageBox.Show("Can't Find Path");
                else
                {
                    string path = fbdDirectoryName;
                    string[] fileEntries = Directory.GetFiles(path, "*.xml");

                    foreach (string fileName in fileEntries)
                    {
                        ofdImageFileName = fileName.Remove(ofdImageFileName.IndexOf(".xml"));
                        ofdImageFileName = ofdImageFileName + ".png";
                        CreateImg();

                    }
                }
                */
                System.Windows.Forms.MessageBox.Show("Please select file source type!");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public static Image cropPngImage(Bitmap img, Rectangle cropArea)
        {
            Bitmap bmpCrop = img.Clone(cropArea,
                                 img.PixelFormat);

            return (Image)(bmpCrop);
        }


        public void DeSerializeNewDataFile(string fileName)
        {
            XmlDocument doc = new XmlDocument();

            ofdImageFileName = fileName;
            ofdImageFileName = ofdImageFileName.Remove(ofdImageFileName.IndexOf(".xml"));
            ofdImageFileName = ofdImageFileName + ".png";

            doc.Load(fileName);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/plist/dict/dict");
            if (nodes.Count == 0)
            {
                MessageBox.Show(string.Format("File doesnot contain valid data: {0}", fileName), "Warning", MessageBoxButtons.OK);
                return;
            }


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

                    test = datas[2].InnerText;
                    test = System.Text.RegularExpressions.Regex.Replace(test, "{", string.Empty);
                    result = System.Text.RegularExpressions.Regex.Replace(test, "}", string.Empty).Split(',');
                    f.dstX = Convert.ToSingle(result[0]);
                    f.dstY = Convert.ToSingle(result[1]);

                    test = datas[3].InnerText;
                    test = System.Text.RegularExpressions.Regex.Replace(test, "{", string.Empty);
                    result = System.Text.RegularExpressions.Regex.Replace(test, "}", string.Empty).Split(',');
                    f.sourceSizeX = Convert.ToSingle(result[0]);
                    f.sourceSizeY = Convert.ToSingle(result[1]);

                    s.items.Add(f);

                }
            }

            int count = 0;
            foreach (Frame f in s1.items)
            {
                Console.Write(count++ + " " + f.width + " " + f.height + " " + f.dstX + " " + f.dstY + "\n");
            }

        }
        public void DeSerializeOldDataFile(string fileName)
        {
            XmlTextReader xtr = new XmlTextReader(fileName);
            xtr.WhitespaceHandling = WhitespaceHandling.None;
            xtr.Read();

            if (xtr.Name != "frameset")
            {
                MessageBox.Show(string.Format("File format is not valid: {0}", fileName), "Warning", MessageBoxButtons.OK);
                return;
            }


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

                f.sourceSizeX = f.dstX * 2 + f.width;
                f.sourceSizeY = f.dstY * 2 + f.height;

                //f.dstX = 0;
                //f.dstY = 0;

                s.items.Add(f);

                xtr.Read();
            }

            xtr.Close();
        }

        static void IsRepeating(Frame f, List<uniqueFrame> uf)
        {
            existing = uf.Any(x => x.x == f.srcX && x.y == f.srcY && x.width == f.width && x.height == f.height);
            if (existing == true)
                index = uf.FindIndex(x => x.x == f.srcX && x.y == f.srcY && x.width == f.width && x.height == f.height);
        }

        public void CuttingImage(string fileName)
        {
            fbdOutputFileName = fileName.Remove(fileName.Length - 4);

            if (noRepeat.Checked == true)
            {
                uniqueDataFile = fbdOutputFileName;
                uniqueDataFile = uniqueDataFile + ".txt";
                if (File.Exists(uniqueDataFile))
                    File.Delete(uniqueDataFile);
            }

            Console.WriteLine(fileName);


            Directory.CreateDirectory(fbdOutputFileName);

            Bitmap bmpImage = new Bitmap(Image.FromFile(fileName));
            int count = 0;

            List<uniqueFrame> uf = new List<uniqueFrame>();
            foreach (Frame f in s.items)
            {
                //suffix
                string suffix = string.Format("{0:000}", count);
                string indexFrame;

                //check if the current frame already exist previously
                if (noRepeat.Checked == true)
                {
                    existing = false;
                    IsRepeating(f, uf);
                    if (existing == true)
                    {
                        //edit notes
                        indexFrame = string.Format("{0:000}", index);

                        File.AppendAllText(uniqueDataFile, suffix);
                        File.AppendAllText(uniqueDataFile, " ");
                        File.AppendAllText(uniqueDataFile, indexFrame);
                        File.AppendAllText(uniqueDataFile, Environment.NewLine);

                        count++;
                        continue;
                    }
                    else
                    {
                        //save structure into structure array
                        uniqueFrame temp = new uniqueFrame();
                        temp.x = (int)f.srcX;
                        temp.y = (int)f.srcY;
                        temp.width = (int)f.width;
                        temp.height = (int)f.height;

                        uf.Add(temp);
                    }
                }

                // Create canvas.
                Bitmap transparentCanvas = new Bitmap((int)f.sourceSizeX, (int)f.sourceSizeY, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(transparentCanvas);
                g.Clear(Color.Transparent);

                string outputFileName = fbdOutputFileName + "\\" + fbdOutputFileName.Remove(0, fbdOutputFileName.LastIndexOf('\\')) + "_" + suffix + ".png";

                if (f.width == 0 || f.height == 0)
                {
                    transparentCanvas.Save(outputFileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    Image resultImg = cropPngImage(bmpImage, new Rectangle((int)(f.srcX), (int)(f.srcY), (int)(f.width), (int)(f.height)));
                    System.Drawing.Image canvas = transparentCanvas;
                    g.DrawImage(resultImg, new Point((int)f.dstX, (int)f.dstY));
                    canvas.Save(outputFileName, System.Drawing.Imaging.ImageFormat.Png);
                    resultImg.Dispose();
                    resultImg = null;
                }
                g.Dispose();
                //transparentCanvas.Dispose();
                count++;
            }
            bmpImage.Dispose();
            GC.Collect();
        }

        public void CreateImg()
        {
            uniqueDataFile = ofdImageFileName.Remove(ofdImageFileName.Length - 4);
            uniqueDataFile = uniqueDataFile + ".txt";
            if (!File.Exists(uniqueDataFile))
                MessageBox.Show(string.Format("Can't Find UniqueData File: {0}", uniqueDataFile), "Warning", MessageBoxButtons.OK);
            else
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(uniqueDataFile);
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] copyInfo = line.Split(' ');
                    string fromFile = ofdImageFileName.Remove(ofdImageFileName.Length - 4);
                    fromFile = fromFile + "_" + copyInfo[1] + ".png";
                    if (!File.Exists(fromFile))
                    {
                        string safeFromFile = uniqueDataFile.Remove(uniqueDataFile.Length - 4);
                        safeFromFile = safeFromFile + "_" + copyInfo[1] + ".png";
                        MessageBox.Show(string.Format("Missing File: {0}", safeFromFile), "Warning", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string toFile = ofdImageFileName.Remove(ofdImageFileName.Length - 4);
                        toFile = toFile + "_" + copyInfo[0] + ".png";
                        System.IO.File.Copy(fromFile, toFile);
                    }
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cocos2DAtlas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void originalName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void noDataFile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ignoreOffset_CheckedChanged(object sender, EventArgs e)
        {

        }

    }


    public class Frame
    {
        public int id;
        public float width;
        public float height;
        public float srcX;
        public float srcY;
        public float dstX;
        public float dstY;
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


    struct uniqueFrame
    {
        public int x, y, width, height;
    }

}
