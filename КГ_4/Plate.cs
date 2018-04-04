using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using static System.Math;

namespace CG_4
{
    class Plate : Figure
    {
        public Vector3 Normal { set; get; }
        public Vector3 Point { set; get; }
        private Vector3[] Points = new Vector3[4];

        public override void InputCoords(StreamReader sr)
        {
            List<string> str;
            str = ((sr.ReadLine().Split(new char[] { ' ' })).
              Where(substr => substr.Length > 0)).ToList<string>();

            Normal = new Vector3(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2])).Normalized();

            str = ((sr.ReadLine().Split(new char[] { ' ' })).
              Where(substr => substr.Length > 0)).ToList<string>();

            Point = new Vector3(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2]));

            Vector3 v;
            if (Normal != Vector3.UnitX && Normal != -Vector3.UnitX)
                v = Vector3.Cross(Normal, Vector3.UnitX);
            else v = Vector3.UnitY;
            
            Points[0] = Point + 10000f * v;
            Points[2] = Point - 10000f * v;

            v = Vector3.Transform(v, Matrix4.CreateFromAxisAngle(Normal, (float)PI / 2));

            Points[1] = Point + 10000f * v;
            Points[3] = Point - 10000f * v;
            GL.End();
        }

        public override void Draw()
        {
            GL.Begin(BeginMode.Quads);
            GL.Color3(Material.Colour);
            for (int i = 0; i < 4; i++)
                GL.Vertex3(Points[i]);
            GL.End();
        }

        public override bool Hit(Ray ray, ref Intersection inter)
        {
            Ray genRay = new Ray();
            inter.NumHits = 0;

            Matrix4 Rotation;
            if (Normal != Vector3.UnitZ && Normal != -Vector3.UnitZ)
            {
                float angle = Vector3.CalculateAngle(Vector3.UnitZ, Normal);
                Rotation = Matrix4.CreateFromAxisAngle(Vector3.Cross(Vector3.UnitZ, Normal), angle);
            }
            else
                Rotation = Matrix4.Identity;

            Matrix4 Translate = Matrix4.CreateTranslation(Point);

            Matrix4 invM = Matrix4.Invert(Matrix4.Mult(Rotation, Translate));

            genRay.S = Vector3.Transform(ray.S, invM);
            genRay.Dir = new Vector3(Vector4.Transform(new Vector4(ray.Dir, 0f), invM));
            
            double denom = genRay.Dir.Z;

            if (Abs(denom) < 1e-16)
                return false; // the ray is parallel to the plate

            double time = -genRay.S.Z / denom;

            if (time <= 0)
                return false; // the plate is out of sight

            inter.NumHits = 1;

            inter.Hit[0] = new HitInfo();
            inter.Hit[0].Fig = this;
            inter.Hit[0].HitTime = time;
            inter.Hit[0].IsEntering = true;
            inter.Hit[0].Surface = 0;
            inter.Hit[0].HitPoint = ray.GetPosition(time);
            inter.Hit[0].HitNormal = new Vector3(Vector4.Transform(new Vector4(Vector3.UnitZ, 0), Matrix4.Transpose(invM)));
            return true;
        }

        public override bool Hit(Ray ray)
        {
            Ray genRay = new Ray();

            Matrix4 Rotation;
            if (Normal != Vector3.UnitY && Normal != -Vector3.UnitY)
            {
                float angle = Vector3.CalculateAngle(Vector3.UnitY, Normal);
                Rotation = Matrix4.CreateFromAxisAngle(Vector3.Cross(Vector3.UnitY, Normal), angle);
            }
            else
                Rotation = Matrix4.Identity;

            Matrix4 Translate = Matrix4.CreateTranslation(Point);

            Matrix4 invM = Matrix4.Invert(Matrix4.Mult(Rotation, Translate));

            genRay.S = Vector3.Transform(ray.S, invM);
            genRay.Dir = new Vector3(Vector4.Transform(new Vector4(ray.Dir, 0f), invM));
            
            double denom = genRay.Dir.Y;

            if (Abs(denom) < 1e-16)
                return false; // the ray is parallel to the plate

            double time = -genRay.S.Y / denom;

            if (time <= 0)
                return false; // the plate is out of sight

            return true;
        }

        public override void Choose()
        {
            float h1 = (Points[0] - Points[1]).Length / 1000f;
            float h2 = (Points[1] - Points[2]).Length / 1000f;

            GL.Begin(BeginMode.Lines);
            GL.Color3(System.Drawing.Color.White);
            for (int i = 0; i < 1000; i++)
            {
                GL.Vertex3(Points[0] + i * h1 * (Points[1] - Points[0]).Normalized());
                GL.Vertex3(Points[3] + i * h1 * (Points[2] - Points[3]).Normalized());
            }

            for (int i = 0; i < 10000; i++)
            {
                GL.Vertex3(Points[1] + i * h2 * (Points[2] - Points[1]).Normalized());
                GL.Vertex3(Points[0] + i * h2 * (Points[3] - Points[0]).Normalized());
            }
            GL.End();

        }
    }
}
