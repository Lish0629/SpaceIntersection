using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Integration;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using static System.Math;

namespace SpaceIntersection {
    internal class PicData {
        public double F {  get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double XS { get; set; }
        public double YS { get; set; }
        public double ZS {  get; set; }
        //偏角
        public double QP {  get; set; }
        //倾角
        public double WP {  get; set; }
        //旋角
        public double K { get; set; }
        public double u { get; set; }
        public double v { get; set; }
        public double w { get; set; }

        public PicData(double f, double x, double y, double xS, double yS, double zS, double qP, double wP, double k) {
            F = f;
            X = x;
            Y = y;
            XS = xS;
            YS = yS;
            ZS = zS;
            QP = qP;
            WP = wP;
            K = k;
            Caluvw();
        }
        public PicData(string f, string x, string y, string xS, string yS, string zS, string qP, string wP, string k) {
            F = double.Parse(f);
            X = double.Parse(x);
            Y = double.Parse(y);
            XS = double.Parse(xS);
            YS = double.Parse(yS);
            ZS = double.Parse(zS);
            QP = double.Parse(qP);
            WP = double.Parse(wP);
            K = double.Parse(k);
            Caluvw();
        }

        private void Caluvw() {
            double a1 = Cos(T(QP)) * Cos(T(K)) - Cos(T(QP)) * Sin(T(WP)) * Sin(T(K));
            double a2 = -Cos(T(QP)) * Sin(T(K)) - Sin(T(QP)) * Sin(T(WP)) * Sin(T(K));
            double a3 = -Sin(T(QP)) * Cos(T(WP));
            double b1 = Cos(T(WP)) * Sin(T(K));
            double b2 = Cos(T(WP)) * Cos(T(K));
            double b3 = -Sin(T(WP));
            double c1 = Sin(T(QP)) * Cos(T(K)) + Cos(T(QP)) * Sin(T(WP)) * Sin(T(K));
            double c2 = -Sin(T(WP)) * Cos(T(K)) + Cos(T(QP)) * Sin(T(WP)) * Sin(T(K));
            double c3 = Cos(T(QP)) * Cos(T(WP));
            var matrixA = Matrix<double>.Build.DenseOfArray(new double[,] {
                {a1,a2 ,a3}, {b1,b2,b3}, {c1,c2,c3}
            });
            /*var matrixA = Matrix<double>.Build.DenseOfArray(new double[,] {
                {a1,b1 ,c1}, {a2,b2,c2}, {a3,b2,c3}
            });*/
            var matrixB = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                {X },{Y},{F}
            });
            var matrixC=matrixA*matrixB;
            u = matrixC[0,0];
            v = matrixC[1,0];
            w = matrixC[2,0];
            MessageBox.Show($"{matrixC[0,0]}, {matrixC[1,0]}, {matrixC[2,0]}");
        }
        public double T(double r) {
            return r/360*2*PI;
        }
    }
}
