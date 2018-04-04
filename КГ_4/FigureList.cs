using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_4
{
    class FigureList : List<Figure>
    {
        public void Input(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                while (sr.Peek() > -1)
                {
                    FigureType type = (FigureType)int.Parse(sr.ReadLine());
                    Figure figure;

                    switch (type)
                    {
                        case FigureType.SPHERE:
                            figure = new Sphere();
                            break;
                        case FigureType.BRICK:
                            figure = new Brick();
                            break;
                        case FigureType.PLATE:
                            figure = new Plate();
                            break;
                        default:
                            throw new Exception("Unknown figure type");
                    }

                    figure.InputCoords(sr);
                    figure.InputMaterial(sr);

                    Add(figure);
                }
            }
        }
    }
}
