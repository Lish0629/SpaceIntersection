using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceIntersection {
    internal class ProjectionData {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double BU { get; set; }
        public double BV { get; set; }
        public double BW { get; set; }
        public double N1 { get; set; }
        public double N2 { get; set; }
        public PicData P1 { get; set; }
        public PicData P2 { get; set; }
        public ProjectionData(PicData p1,PicData p2) {
            P1 = p1;
            P2 = p2;
            CalBN();
            CalLoc();
        }
        private void CalBN() {
            BU = P2.XS - P1.XS;
            BV = P2.YS - P1.YS;
            BW = P2.ZS - P1.ZS;
            N1 = (BU * P2.w - BW * P2.u) / (P1.u * P2.w - P2.u * P1.w);
            N2 = (BU * P1.w - BW * P1.u) / (P1.u * P2.w - P2.u * P1.w);
        }
        private void CalLoc() {
            X = P1.XS + N1 * P1.u;
            Y = 0.5 * ((P1.YS+N1*P1.v)+(P2.YS+N2* P2.v));
            Z = P1.ZS + N1 * P1.w;
            MessageBox.Show($"{X}, {Y}, {Z}");
        }
    }
}
