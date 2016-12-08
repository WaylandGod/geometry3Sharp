﻿using System;
using System.Collections.Generic;
using System.Text;

#if G3_USING_UNITY
using UnityEngine;
#endif

namespace g3
{
    public struct Vector3d
    {
        private double[] v;

        public Vector3d(double f) { v = new double[3]; v[0] = v[1] = v[2] = f; }
        public Vector3d(double x, double y, double z) { v = new double[3]; v[0] = x; v[1] = y; v[2] = z; }
        public Vector3d(double[] v2) { v = new double[3]; v[0] = v2[0]; v[1] = v2[1]; v[2] = v2[2]; }
        public Vector3d(Vector3d copy) { v = new double[3]; v[0] = copy.v[0]; v[1] = copy.v[1]; v[2] = copy.v[2]; }
        public Vector3d(Vector3f copy) { v = new double[3]; v[0] = copy[0]; v[1] = copy[1]; v[2] = copy[2]; }

        static public readonly Vector3d Zero = new Vector3d(0.0f, 0.0f, 0.0f);
        static public readonly Vector3d One = new Vector3d(1.0f, 1.0f, 1.0f);
        static public readonly Vector3d AxisX = new Vector3d(1.0f, 0.0f, 0.0f);
        static public readonly Vector3d AxisY = new Vector3d(0.0f, 1.0f, 0.0f);
        static public readonly Vector3d AxisZ = new Vector3d(0.0f, 0.0f, 1.0f);

        public double x
        {
            get { return v[0]; }
            set { v[0] = value; }
        }
        public double y
        {
            get { return v[1]; }
            set { v[1] = value; }
        }
        public double z
        {
            get { return v[2]; }
            set { v[2] = value; }
        }
        public double this[int key]
        {
            get { return v[key]; }
            set { v[key] = value; }
        }




        public double LengthSquared
        {
            get { return v[0] * v[0] + v[1] * v[1] + v[2] * v[2]; }
        }
        public double Length
        {
            get { return (double)Math.Sqrt(LengthSquared); }
        }

        public double Normalize(double epsilon = MathUtil.Epsilon)
        {
            double length = Length;
            if (length > epsilon) {
                double invLength = 1.0 / length;
                v[0] *= invLength;
                v[1] *= invLength;
                v[2] *= invLength;
            } else {
                length = 0;
                v[0] = v[1] = v[2] = 0;
            }
            return length;
        }
        public Vector3d Normalized
        {
            get { Vector3d n = new Vector3d(v[0], v[1], v[2]); n.Normalize(); return n; }
        }


        public double Dot(Vector3d v2)
        {
            return v[0] * v2[0] + v[1] * v2[1] + v[2] * v2[2];
        }
        public static double Dot(Vector3d v1, Vector3d v2)
        {
            return v1.Dot(v2);
        }

        public Vector3d Cross(Vector3d v2)
        {
            return new Vector3d(
                v[1] * v2.v[2] - v[2] * v2.v[1],
                v[2] * v2.v[0] - v[0] * v2.v[2],
                v[0] * v2.v[1] - v[1] * v2.v[0]);
        }
        public static Vector3d Cross(Vector3d v1, Vector3d v2)
        {
            return v1.Cross(v2);
        }

        public Vector3d UnitCross(Vector3d v2)
        {
            Vector3d n = new Vector3d(
                v[1] * v2.v[2] - v[2] * v2.v[1],
                v[2] * v2.v[0] - v[0] * v2.v[2],
                v[0] * v2.v[1] - v[1] * v2.v[0]);
            n.Normalize();
            return n;
        }

        public double AngleD(Vector3d v2)
        {
            double fDot = MathUtil.Clamp(Dot(v2), -1, 1);
            return Math.Acos(fDot) * MathUtil.Rad2Deg;
        }
        public static double AngleD(Vector3d v1, Vector3d v2)
        {
            return v1.AngleD(v2);
        }
        public double AngleR(Vector3d v2)
        {
            double fDot = MathUtil.Clamp(Dot(v2), -1, 1);
            return Math.Acos(fDot);
        }
        public static double AngleR(Vector3d v1, Vector3d v2)
        {
            return v1.AngleR(v2);
        }


        public void Set(Vector3d o)
        {
            v[0] = o[0]; v[1] = o[1]; v[2] = o[2];
        }
        public void Set(double fX, double fY, double fZ)
        {
            v[0] = fX; v[1] = fY; v[2] = fZ;
        }
        public void Add(Vector3d o)
        {
            v[0] += o[0]; v[1] += o[1]; v[2] += o[2];
        }
        public void Subtract(Vector3d o)
        {
            v[0] -= o[0]; v[1] -= o[1]; v[2] -= o[2];
        }



        public static Vector3d operator -(Vector3d v)
        {
            return new Vector3d(-v[0], -v[1], -v[2]);
        }

        public static Vector3d operator *(double f, Vector3d v)
        {
            return new Vector3d(f * v[0], f * v[1], f * v[2]);
        }
        public static Vector3d operator *(Vector3d v, double f)
        {
            return new Vector3d(f * v[0], f * v[1], f * v[2]);
        }
        public static Vector3d operator /(Vector3d v, double f)
        {
            return new Vector3d(v[0] / f, v[1] / f, v[2] / f);
        }


        public static Vector3d operator *(Vector3d a, Vector3d b)
        {
            return new Vector3d(a[0] * b[0], a[1] * b[1], a[2] * b[2]);
        }
        public static Vector3d operator /(Vector3d a, Vector3d b)
        {
            return new Vector3d(a[0] / b[0], a[1] / b[1], a[2] / b[2]);
        }


        public static Vector3d operator +(Vector3d v0, Vector3d v1)
        {
            return new Vector3d(v0[0] + v1[0], v0[1] + v1[1], v0[2] + v1[2]);
        }
        public static Vector3d operator +(Vector3d v0, double f)
        {
            return new Vector3d(v0[0] + f, v0[1] + f, v0[2] + f);
        }

        public static Vector3d operator -(Vector3d v0, Vector3d v1)
        {
            return new Vector3d(v0[0] - v1[0], v0[1] - v1[1], v0[2] - v1[2]);
        }
        public static Vector3d operator -(Vector3d v0, double f)
        {
            return new Vector3d(v0[0] - f, v0[1] - f, v0[2] - f);
        }



        public static bool operator ==(Vector3d a, Vector3d b)
        {
            return (a[0] == b[0] && a[1] == b[1] && a[2] == b[2]);
        }
        public static bool operator !=(Vector3d a, Vector3d b)
        {
            return (a[0] != b[0] || a[1] != b[1] || a[2] != b[2]);
        }
        public override bool Equals(object obj)
        {
            return this == (Vector3d)obj;
        }
        public override int GetHashCode()
        {
            return v.GetHashCode();
        }



        public static Vector3d Lerp(Vector3d a, Vector3d b, double t)
        {
            double s = 1 - t;
            return new Vector3d(s * a[0] + t * b[0], s * a[1] + t * b[1], s * a[2] + t * b[2]);
        }



        public override string ToString() {
            return string.Format("{0:F8} {1:F8} {2:F8}", v[0], v[1], v[2]);
        }
        public string ToString(string fmt) {
            return string.Format("{0} {1} {2}", v[0].ToString(fmt), v[1].ToString(fmt), v[2].ToString(fmt));
        }



        public static implicit operator Vector3d(Vector3f v)
        {
            return new Vector3d(v[0], v[1], v[2]);
        }
        public static explicit operator Vector3f(Vector3d v)
        {
            return new Vector3f((float)v[0], (float)v[1], (float)v[2]);
        }


#if G3_USING_UNITY
        public static implicit operator Vector3d(UnityEngine.Vector3 v)
        {
            return new Vector3d(v[0], v[1], v[2]);
        }
        public static explicit operator Vector3(Vector3d v)
        {
            return new Vector3((float)v[0], (float)v[1], (float)v[2]);
        }
#endif


    }
}
