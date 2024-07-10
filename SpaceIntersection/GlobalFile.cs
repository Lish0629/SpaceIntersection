using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceIntersection {
    internal class GlobalFile {
        public PicData picData1;
        public PicData picData2;
        public ProjectionData projectiondata;
        
        public void Read(string filename) {
            var reader = new StreamReader(filename);
            PicData picData1 = new PicData(reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine());
            PicData picData2 = new PicData(reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine());
            projectiondata = new ProjectionData(picData1, picData2);
            reader.Close();
        }
        public void Read(string filename, GroupBox groupBox) {
            var reader = new StreamReader(filename);
            picData1 = new PicData(reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine());
            picData2 = new PicData(reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine());
            projectiondata = new ProjectionData(picData1, picData2);
            reader.Close();
            groupBox.Controls["textBoxf1"].Text = picData1.F.ToString();
            groupBox.Controls["textBoxx1"].Text = picData1.X.ToString();
            groupBox.Controls["textBoxy1"].Text = picData1.Y.ToString();
            groupBox.Controls["textBoxxs1"].Text = picData1.XS.ToString();
            groupBox.Controls["textBoxys1"].Text = picData1.YS.ToString();
            groupBox.Controls["textBoxzs1"].Text = picData1.ZS.ToString();
            groupBox.Controls["textBoxpj1"].Text = picData1.QP.ToString();
            groupBox.Controls["textBoxqj1"].Text = picData1.WP.ToString();
            groupBox.Controls["textBoxxj1"].Text = picData1.K.ToString();
            groupBox.Controls["textBoxf2"].Text = picData2.F.ToString();
            groupBox.Controls["textBoxx2"].Text = picData2.X.ToString();
            groupBox.Controls["textBoxy2"].Text = picData2.Y.ToString();
            groupBox.Controls["textBoxxs2"].Text = picData2.XS.ToString();
            groupBox.Controls["textBoxys2"].Text = picData2.YS.ToString();
            groupBox.Controls["textBoxzs2"].Text = picData2.ZS.ToString();
            groupBox.Controls["textBoxpj2"].Text = picData2.QP.ToString();
            groupBox.Controls["textBoxqj2"].Text = picData2.WP.ToString();
            groupBox.Controls["textBoxxj2"].Text = picData2.K.ToString();
        }
    }
}
