using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using static System.Math;
using System.ComponentModel;

namespace CG_4
{
    class LightInfo
    {
        public Vector3 Position { set; get; }    // Light position in eye coords.
        public Vector3 La { set; get; }          // Ambient light intensity
        public Vector3 Ld { set; get; }          // Diffuse light intensity
        public Vector3 Ls { set; get; }          // Specular light intensity
    }

    class Scene
    {
        // camera params
        public Vector3 Eye { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 UpVector { get; set; }

        // light params
        public LightInfo Light { set; get; }

        // projection params
        public float Teta { set; get; }
        public float Aspect { set; get; }
        public float zNear { set; get; }

        // displayed objects
        public FigureList FList;

        // tracing params
        public int MaxRecursionLevel { set; get; }
        float eps = 0.0001f;

        ///<summary>
        /// Returns true if the ray intersects with any of the figures of the scene.
        ///</summary>
        private bool isInShadow(Ray ray)
        {
            foreach (var figure in FList)
                if (figure.Hit(ray))
                    return true;
            return false;
        }

        ///<summary>
        /// Returns the closest figure the ray intesects with.
        ///</summary>
        private void GetFirstHit(Ray ray, ref Intersection best)
        {
            best.NumHits = 0;

            foreach (var figure in FList)
            {
                Intersection inter = new Intersection();
                if (figure.Hit(ray, ref inter))
                    if (best.NumHits == 0 || best.Hit[0].HitTime > inter.Hit[0].HitTime)
                        best = inter;
            }
        }

        ///<summary>
        /// Returns the colour of the area.
        ///</summary>
        public Vector3 Shade(Ray ray)
        {
            Vector3 clr;
            Intersection best = new Intersection();
            GetFirstHit(ray, ref best);
            if (best.NumHits == 0)
                return new Vector3(0f);

            Vector3 n = best.Hit[0].HitNormal.Normalized();

            MaterialInfo Material = best.Hit[0].Fig.Material;

            Vector3 Ia = Vector3.Multiply(Material.Ka, Light.La);

            clr = Material.Colour + Ia;

            // shadow areas detection
            Ray shf = new Ray(); // shadow finder
            shf.S = best.Hit[0].HitPoint - eps * ray.Dir;
            shf.RecurseLevel = 1;
            shf.Dir = Light.Position - best.Hit[0].HitPoint;

            if (!isInShadow(shf))
            {
                Vector3 v = (-ray.Dir).Normalized();
                Vector3 s = (Light.Position - best.Hit[0].HitPoint).Normalized();

                Vector3 h = (s + v).Normalized();

                float sn = Max(Vector3.Dot(s, n), 0);
                float hn = Max(Vector3.Dot(h, n), 0);
                hn = (float)Pow(hn, Material.Shininess);

                Vector3 Id = Vector3.Multiply(Material.Kd, sn * Light.Ld);
                Vector3 Is = Vector3.Multiply(Material.Ks, hn * Light.Ls);

                clr += Id + Is;
            }

            if (ray.RecurseLevel == MaxRecursionLevel)
                return clr;

            if (Material.Shininess > 1)
            {
                Ray refl = new Ray();
                refl.S = best.Hit[0].HitPoint - eps * ray.Dir;
                refl.Dir = ray.Dir - 2 * Vector3.Dot(ray.Dir, n) * n;
                refl.RecurseLevel = ray.RecurseLevel + 1;
                clr += Vector3.Multiply(Material.Ks, Shade(refl));
            }

            return clr;
        }
    }
}
