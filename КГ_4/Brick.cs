using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using static System.Math;

namespace CG_4
{
    class Brick : Figure
    {
        public Vector3 Center { set; get; }
        public Vector3 Scale { set; get; }
        public Vector3 Rotation { set; get; }
        private Vector3[] Vertices = new Vector3[24];

        public override void Draw()
        {            
            GL.Begin(BeginMode.Quads);
            GL.Color3(Material.Colour);
            for (int i = 0; i < 24; i++)
                GL.Vertex3(Vertices[i]);
            GL.End();
        }

        public override void Choose()
        {
            for (int i = 0; i < 6; i++)
            {
                GL.LineWidth(2f);
                GL.Begin(BeginMode.LineLoop);
                GL.Color3(System.Drawing.Color.White);
                for (int j = 0; j < 4; j++)
                    GL.Vertex3(Vertices[4 * i + j]);
                GL.End();
            }
        }

        public override void InputCoords(StreamReader sr)
        {
            List<string> str;
            str = ((sr.ReadLine().Split(new char[] { ' ' })).
              Where(substr => substr.Length > 0)).ToList<string>();

            Center = new Vector3(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2]));

            str = ((sr.ReadLine().Split(new char[] { ' ' })).
              Where(substr => substr.Length > 0)).ToList<string>();

            Scale = new Vector3(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2]));

            str = ((sr.ReadLine().Split(new char[] { ' ' })).
              Where(substr => substr.Length > 0)).ToList<string>();

            Rotation = new Vector3(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2]));

            Vertices[0] = new Vector3(Scale.X / 2, Scale.Y / 2, Scale.Z / 2);
            Vertices[1] = new Vector3(Scale.X / 2, Scale.Y / 2, -Scale.Z / 2);
            Vertices[2] = new Vector3(Scale.X / 2, -Scale.Y / 2, -Scale.Z / 2);
            Vertices[3] = new Vector3(Scale.X / 2, -Scale.Y / 2, Scale.Z / 2);

            Vertices[4] = new Vector3(Scale.X / 2, Scale.Y / 2, Scale.Z / 2);
            Vertices[5] = new Vector3(Scale.X / 2, Scale.Y / 2, -Scale.Z / 2);
            Vertices[6] = new Vector3(-Scale.X / 2, Scale.Y / 2, -Scale.Z / 2);
            Vertices[7] = new Vector3(-Scale.X / 2, Scale.Y / 2, Scale.Z / 2);

            Vertices[8] = new Vector3(Scale.X / 2, Scale.Y / 2, Scale.Z / 2);
            Vertices[9] = new Vector3(Scale.X / 2, -Scale.Y / 2, Scale.Z / 2);
            Vertices[10] = new Vector3(-Scale.X / 2, -Scale.Y / 2, Scale.Z / 2);
            Vertices[11] = new Vector3(-Scale.X / 2, Scale.Y / 2, Scale.Z / 2);

            Vertices[12] = new Vector3(Scale.X / 2, Scale.Y / 2, -Scale.Z / 2);
            Vertices[13] = new Vector3(Scale.X / 2, -Scale.Y / 2, -Scale.Z / 2);
            Vertices[14] = new Vector3(-Scale.X / 2, -Scale.Y / 2, -Scale.Z / 2);
            Vertices[15] = new Vector3(-Scale.X / 2, Scale.Y / 2, -Scale.Z / 2);

            Vertices[16] = new Vector3(-Scale.X / 2, Scale.Y / 2, Scale.Z / 2);
            Vertices[17] = new Vector3(-Scale.X / 2, Scale.Y / 2, -Scale.Z / 2);
            Vertices[18] = new Vector3(-Scale.X / 2, -Scale.Y / 2, -Scale.Z / 2);
            Vertices[19] = new Vector3(-Scale.X / 2, -Scale.Y / 2, Scale.Z / 2);

            Vertices[20] = new Vector3(Scale.X / 2, -Scale.Y / 2, Scale.Z / 2);
            Vertices[21] = new Vector3(Scale.X / 2, -Scale.Y / 2, -Scale.Z / 2);
            Vertices[22] = new Vector3(-Scale.X / 2, -Scale.Y / 2, -Scale.Z / 2);
            Vertices[23] = new Vector3(-Scale.X / 2, -Scale.Y / 2, Scale.Z / 2);

            Matrix4 Rotate = Matrix4.CreateRotationX(Rotation.X) *
                Matrix4.CreateRotationY(Rotation.Y) * Matrix4.CreateRotationZ(Rotation.Z);

            for (int i = 0; i < 24; i++)
                Vertices[i] = Center + Vector3.Transform(Vertices[i], Rotate);

        }
        ///<summary>
        /// Returns a normal of the cube face
        ///</summary>
        private Vector3 CubeNormal(int i)
        {
            switch (i)
            {
                case 0:
                    return Vector3.UnitY;
                case 1:
                    return -Vector3.UnitY;
                case 2:
                    return Vector3.UnitX;
                case 3:
                    return -Vector3.UnitX;
                case 4:
                    return Vector3.UnitZ;
                case 5:
                    return -Vector3.UnitZ;
                default:
                    throw new Exception();
            }
        }

        public override bool Hit(Ray ray, ref Intersection inter)
        {
            double tHit = -1, numer = 0, denom = 0;
            double tIn = -100000, tOut = 100000;
            Ray genRay = new Ray();
            int inSurf = 0, outSurf = 0;

            Matrix4 ScaleMatrix = Matrix4.CreateScale(Scale / 2);
            Matrix4 Translate = Matrix4.CreateTranslation(Center);
            Matrix4 Rotate = Matrix4.CreateRotationX(Rotation.X) *
                Matrix4.CreateRotationY(Rotation.Y) * Matrix4.CreateRotationZ(Rotation.Z);

            Matrix4 M = Matrix4.Invert(Matrix4.Mult(Matrix4.Mult(ScaleMatrix, Rotate),Translate));

            genRay.S = new Vector3(Vector4.Transform(new Vector4(ray.S, 1), M));
            genRay.Dir = new Vector3(Vector4.Transform(new Vector4(ray.Dir, 0), M));
            

            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        numer = 1 - genRay.S.Y;
                        denom = genRay.Dir.Y;
                        break;
                    case 1:
                        numer = 1 + genRay.S.Y;
                        denom = -genRay.Dir.Y;
                        break;
                    case 2:
                        numer = 1 - genRay.S.X;
                        denom = genRay.Dir.X;
                        break;
                    case 3:
                        numer = 1 + genRay.S.X;
                        denom = -genRay.Dir.X;
                        break;
                    case 4:
                        numer = 1 - genRay.S.Z;
                        denom = genRay.Dir.Z;
                        break;
                    case 5:
                        numer = 1 + genRay.S.Z;
                        denom = -genRay.Dir.Z;
                        break;
                }

                if (Abs(denom) < 1e-12) // the ray is parallel
                {
                    if (numer < 0) return false;
                }
                else
                {
                    tHit = numer / denom;
                    if (denom > 0)
                    {
                        if (tHit < tOut)
                        {
                            tOut = tHit;
                            outSurf = i;
                        }
                    }
                    else
                    {
                        if (tHit > tIn)
                        {
                            tIn = tHit;
                            inSurf = i;
                        }
                    }
                }
                if (tIn >= tOut) return false;
            }

            int num = 0;

            if (tIn > 0)
            {
                inter.Hit[0] = new HitInfo();
                inter.Hit[0].HitTime = tIn;
                inter.Hit[0].Surface = inSurf;
                inter.Hit[0].IsEntering = true;
                inter.Hit[0].Fig = this;
                inter.Hit[0].HitPoint = ray.GetPosition(tIn);
                inter.Hit[0].HitNormal = new Vector3(Vector4.Transform(new Vector4(CubeNormal(inSurf), 0), Matrix4.Transpose(M)));
                num++;
            }

            if (tOut > 0)
            {
                inter.Hit[num] = new HitInfo();
                inter.Hit[num].HitTime = tOut;
                inter.Hit[num].Surface = outSurf;
                inter.Hit[num].IsEntering = false;
                inter.Hit[num].Fig = this;
                inter.Hit[num].HitPoint = ray.GetPosition(tOut);
                inter.Hit[num].HitNormal = new Vector3(Vector4.Transform(new Vector4(CubeNormal(outSurf), 0), Matrix4.Transpose(M)));
                num++;
            }

            inter.NumHits = num;
            return (num > 0);
        }

        public override bool Hit(Ray ray)
        {
            double tHit = -1, numer = 0, denom = 0;
            double tIn = -100000, tOut = 100000;
            Ray genRay = new Ray();

            Matrix4 ScaleMatrix = Matrix4.CreateScale(Scale / 2);
            Matrix4 Translate = Matrix4.CreateTranslation(Center);
            Matrix4 Rotate = Matrix4.CreateRotationX(Rotation.X) *
                Matrix4.CreateRotationY(Rotation.Y) * Matrix4.CreateRotationZ(Rotation.Z);

            Matrix4 M = Matrix4.Invert(Matrix4.Mult(Matrix4.Mult(ScaleMatrix, Rotate), Translate));

            genRay.S = new Vector3(Vector4.Transform(new Vector4(ray.S, 1), M));
            genRay.Dir = new Vector3(Vector4.Transform(new Vector4(ray.Dir, 0), M));

            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        numer = 1 - genRay.S.Y;
                        denom = genRay.Dir.Y;
                        break;
                    case 1:
                        numer = 1 + genRay.S.Y;
                        denom = -genRay.Dir.Y;
                        break;
                    case 2:
                        numer = 1 - genRay.S.X;
                        denom = genRay.Dir.X;
                        break;
                    case 3:
                        numer = 1 + genRay.S.X;
                        denom = -genRay.Dir.X;
                        break;
                    case 4:
                        numer = 1 - genRay.S.Z;
                        denom = genRay.Dir.Z;
                        break;
                    case 5:
                        numer = 1 + genRay.S.Z;
                        denom = -genRay.Dir.Z;
                        break;
                }

                if (Abs(denom) < 1e-12) // the ray is parallel
                {
                    if (numer < 0) return false;
                }
                else
                {
                    tHit = numer / denom;
                    if (denom > 0)
                    {
                        if (tHit < tOut)
                            tOut = tHit;
                    }
                    else
                    {
                        if (tHit > tIn)
                            tIn = tHit;
                    }
                }
                if (tIn >= tOut) return false;
            }

            return tIn > 0 || tOut > 0;
        }
    }
}
