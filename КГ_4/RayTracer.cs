using System.Threading.Tasks;
using static System.Math;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace CG_4
{
    class Intersection
    {
        public int NumHits { set; get; }
        public HitInfo[] Hit = new HitInfo[8];
    }

    class Ray
    {
        public Vector3 S { set; get; }
        public Vector3 Dir { set; get; }
        public int RecurseLevel { set; get; }

        public Vector3 GetPosition(double t)
        {
            return Vector3.Add(S, Vector3.Multiply(Dir, (float)t));
        }
        public Ray()
        {

        }
        public Ray(Vector3 _S)
        {
            S = _S;
            RecurseLevel = 0;
        }
    }

    class HitInfo
    {
        public double HitTime { set; get; } 
        public Figure Fig { set; get; }
        public bool IsEntering { set; get; }
        public int Surface { set; get; }
        public Vector3 HitPoint { set; get; }
        public Vector3 HitNormal { set; get; }
    }

    class RayTracer
    {
        public void RayTrace(Scene scn, int Nx, int Ny, int BlockSize)
        {
            Vector3 n = (scn.Eye - scn.Target).Normalized();
            Vector3 u = Vector3.Cross(scn.UpVector, n).Normalized();
            Vector3 v = Vector3.Cross(n, u).Normalized();
            
            float H = scn.zNear * (float) Tan(scn.Teta / 2);
            float W = H * scn.Aspect;
            float zNear = scn.zNear;

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 Ortho = Matrix4.CreateOrthographicOffCenter(0, Nx, 0, Ny, -1, 1);
            GL.LoadMatrix(ref Ortho);

            GL.Disable(EnableCap.Lighting);

            var Wu = W * u;
            var Hv = H * v;
            var zNearn = zNear * n;
            var nx2 = (float)2 / Nx;
            var ny2 = (float)2 / Ny;
            Vector3[,] colors = new Vector3[Nx, Ny];
            Parallel.For(0, Nx, i =>
            {
                Parallel.For(0, Ny, j =>
                {
                    Ray rayy = new Ray(scn.Eye);
                    rayy.Dir = Wu * (nx2 * i - 1) + Hv * (ny2 * j - 1) - zNearn;
                    colors[i,j] = scn.Shade(rayy);
                });
            });
            
            for (int i = 0; i < Nx; ++i)
                for (int j = 0; j < Ny; ++j)
                {
                    GL.Color3(colors[i, j]);
                    GL.Rect(i, j, i + 1, j + 1);
                }
        }
    }
}
