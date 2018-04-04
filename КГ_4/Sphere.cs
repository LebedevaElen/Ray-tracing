using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using static System.Math;

namespace CG_4
{
    class Sphere : Figure
    {
        public Vector3 Center { get; private set; }
        public double Radius { get; private set; }

        public override void InputCoords(StreamReader sr)
        {
            List<string> str = ((sr.ReadLine().Split(new char[] { ' ' })).
                Where(i => i.Length > 0)).ToList<string>();
            
            Center = new Vector3(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2]));
            Radius = double.Parse(sr.ReadLine());
        }

        public override void Draw()
        {
            double degree = PI / 180;
            double Pi2 = PI * 2;
            double r = Radius;

            for (double phi = 0; phi <= Pi2; phi += degree)
            {
                GL.Begin(BeginMode.QuadStrip);
                GL.Color3(Material.Colour);
                for (double psi = 0; psi <= PI; psi += degree)
                    for (int i = 0; i < 2; i++)
                    {
                        double x = Center.X + r * Sin(psi) * Cos(phi + i * degree);
                        double y = Center.Y + r * Sin(psi) * Sin(phi + i * degree);
                        double z = Center.Z + r * Cos(psi);

                        GL.Vertex3(x, y, z);
                    }
                GL.End();
            }
        }

        public override void Choose()
        {
            double degree = PI / 30;
            double Pi2 = PI * 2;
            double r = Radius;

            GL.LineWidth(2f);
            GL.Translate(Center);
            GL.Scale(new Vector3(1.01f));

            for (double phi = 0; phi <= Pi2; phi += degree)
            {
                GL.Begin(BeginMode.LineStrip);
                GL.Color3(System.Drawing.Color.White);
                for (double psi = 0; psi <= PI; psi += degree)
                    for (int i = 0; i < 2; i++)
                    {
                        double x = r * Sin(psi) * Cos(phi + i * degree);
                        double y = r * Sin(psi) * Sin(phi + i * degree);
                        double z = r * Cos(psi);

                        GL.Vertex3(x, y, z);
                    }
                GL.End();
            }
        }

        public override bool Hit(Ray ray, ref Intersection inter)
        {
            Ray genRay = new Ray(); // basic ray

            Matrix4 Scale = Matrix4.CreateScale((float)Radius);
            Matrix4 Translate = Matrix4.CreateTranslation(Center);
            
            Matrix4 invM = Matrix4.Mult(Scale, Translate).Inverted();

            genRay.S = Vector3.Transform(ray.S, invM);
            genRay.Dir = new Vector3(Vector4.Transform(new Vector4(ray.Dir, 0f), invM));

            double A, B, C;
            A = Vector3.Dot(genRay.Dir, genRay.Dir);
            B = Vector3.Dot(genRay.S, genRay.Dir);
            C = Vector3.Dot(genRay.S, genRay.S) - 1f;

            double D = B * B - A * C; // discriminant

            if (D < 0)
                return false;

            int num = 0;
            D = Sqrt(D);
            
            double t1 = (-B - D) / A;

            if (t1 > 0.00001)
            {
                inter.Hit[0] = new HitInfo();
                inter.Hit[0].HitTime = t1;
                inter.Hit[0].Fig = this;
                inter.Hit[0].IsEntering = true;
                inter.Hit[0].Surface = 0;
                Vector3 P = ray.GetPosition(t1);
                inter.Hit[0].HitPoint = P;
                P = genRay.GetPosition(t1);
                inter.Hit[0].HitNormal = new Vector3(Vector4.Transform(new Vector4(P, 0), Matrix4.Transpose(invM)));
                num = 1;
            }

            double t2 = (-B + D) / A;
            if (t2 > 0.00001)
            {
                inter.Hit[num] = new HitInfo();
                inter.Hit[num].HitTime = t2;
                inter.Hit[num].Fig = this;
                inter.Hit[num].IsEntering = false;
                inter.Hit[num].Surface = 0;
                Vector3 P = ray.GetPosition(t2);
                inter.Hit[num].HitPoint = P;
                P = genRay.GetPosition(t2);
                inter.Hit[num].HitNormal = new Vector3(Vector4.Transform(new Vector4(P, 0), Matrix4.Transpose(invM)));
                num++;
            }

            inter.NumHits = num;
            return (num > 0);
        }

        public override bool Hit(Ray ray)
        {
            Ray genRay = new Ray(); // basic ray

            Matrix4 Scale = Matrix4.CreateScale((float)Radius);
            Matrix4 Translate = Matrix4.CreateTranslation(Center);

            Matrix4 invM = Matrix4.Mult(Scale, Translate).Inverted();

            genRay.S = Vector3.Transform(ray.S, invM);
            genRay.Dir = new Vector3(Vector4.Transform(new Vector4(ray.Dir, 0f), invM));

            double A, B, C;
            A = Vector3.Dot(genRay.Dir, genRay.Dir);
            B = Vector3.Dot(genRay.S, genRay.Dir);
            C = Vector3.Dot(genRay.S, genRay.S) - 1f;

            double D = B * B - A * C; // discriminant

            if (D < 0)
                return false;
            
            D = Sqrt(D);

            double t1 = (-B - D) / A;
            double t2 = (-B + D) / A;

            return t1 > 0.00001 || t2 > 0.00001;
        }
    }
}
