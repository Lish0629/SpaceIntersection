using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceIntersection {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        
        GlobalFile global = new GlobalFile();
        private void 读取文件ToolStripMenuItem_Click(object sender, EventArgs e) {
            /*PicData picData1 = new PicData(-165.370335, -2.99449, 98.313214, -6911.427876, 4181.15686125969, 157.7731874, 0.348309888, -0.309135767, 0.081363007);
            PicData picData2 = new PicData(-165.370335, 115.30009, 106.807568, -6922.011458, 4203.665077, 151.6220453, 0.382310345, -0.335320345, 0.082770169);
            ProjectionData projectiondata = new ProjectionData(picData1, picData2);*/
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                global.Read(openFileDialog1.FileName,groupBox1);
            }
        }

        private void 坐标计算ToolStripMenuItem_Click(object sender, EventArgs e) {
            textBox19.Text = global.projectiondata.X.ToString();
            textBox20.Text = global.projectiondata.Y.ToString();
            textBox21.Text = global.projectiondata.Z.ToString();
        }

        private void 投影ToolStripMenuItem_Click(object sender, EventArgs e) {
            textBoxbv.Text=global.projectiondata.BV.ToString();
            textBoxbu.Text = global.projectiondata.BU.ToString();
            textBoxbw.Text = global.projectiondata.BW.ToString();
            textBoxn1.Text = global.projectiondata.N1.ToString();
            textBoxn2.Text = global.projectiondata.N2.ToString();
        }

        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e) {
            saveFileDialog1.Filter = "文本文件|*.txt";
            saveFileDialog1.Title = "保存文本文件";
            string filename = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                filename = saveFileDialog1.FileName;
            }
            try {
                using (StreamWriter sw1 = new StreamWriter(filename)) {
                    sw1.Write(global.projectiondata.X.ToString()+",");
                    sw1.Write(global.projectiondata.Y.ToString() + ",");
                    sw1.Write(global.projectiondata.Z.ToString());
                }
            }
            catch {
                MessageBox.Show("保存有误，请重试！");
            }
        }
    }
}
