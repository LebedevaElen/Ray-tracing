using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OpenTK;

namespace CG_4
{
    enum FigureType
    {
        SPHERE,
        BRICK,
        PLATE
    }

    struct MaterialInfo
    {
        public Vector3 Colour;      // Color
        public Vector3 Ka;          // Ambient reflectivity
        public Vector3 Kd;          // Diffuse reflectivity
        public Vector3 Ks;          // Specular reflectivity
        public float Shininess;     // Specular shininess factor

        public MaterialInfo(Vector3 c, Vector3 a, Vector3 d, Vector3 s, float sh)
        {
            Colour = c;
            Ka = a;
            Kd = d;
            Ks = s;
            Shininess = sh;
        }
    }

    abstract class Figure
    {
        public MaterialInfo Material { get; protected set; }
        
        ///<summary>
        /// Gets coordinates of the figure from StreamReader.
        ///</summary>
        public abstract void InputCoords(StreamReader sr);

        ///<summary>
        /// Gets material information from StreamReader.
        ///</summary>
        public void InputMaterial(StreamReader sr)
        {
            Vector3[] P = new Vector3[4];

            for (int i = 0; i < 4; i++)
            {
                List<string> str = ((sr.ReadLine().Split(new char[] { ' ' })).
                  Where(substr => substr.Length > 0)).ToList<string>();

                P[i] = new Vector3(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2]));
            }

            float sh = float.Parse(sr.ReadLine());

            MaterialInfo mat = new MaterialInfo(P[0], P[1], P[2], P[3], sh);
            Material = mat;
        }

        ///<summary>
        /// Draws the figure.
        ///</summary>
        public abstract void Draw();

        ///<summary>
        /// Returns true if the ray hits the figure and false otherwise. If there's an intersection, returns its parameters into inter.
        ///</summary>
        public abstract bool Hit(Ray ray, ref Intersection inter);

        ///<summary>
        /// Returns true if the ray hits the figure and false otherwise.
        ///</summary>
        public abstract bool Hit(Ray ray);

        ///<summary>
        /// Highlights the edges of the figure.
        ///</summary>
        public abstract void Choose();
    }
}
