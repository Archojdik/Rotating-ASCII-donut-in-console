using System.Collections.Generic;

using ASCII_Donut.Engine;

namespace ASCII_Donut.Primitives
{
    class Donut : IVoxelModel
    {
        public Point Position { get; set; } = new();
        public Rotation Rotation { get; set; } = new();
        public Voxel[] PreRendered { get; private set; }

        public Donut(double largeRadius, double smallRadius, double angleStep)
        {
            List<Voxel> voxelList = new();
            
            for(double a1 = 0; a1 < 360; a1 += angleStep)
            {
                for(double a2 = 0; a2 < 360; a2 += angleStep)
                {
                    Point surface = new() { X = smallRadius };
                    surface = Calcs.RotatePoint2D(surface, a2);

                    Point center = new() { X = largeRadius + surface.X };
                    center = Calcs.RotatePoint2D(center, a1);

                    Voxel voxel = new() 
                    { 
                        Position = new Point() 
                        {
                            X = center.X,
                            Y = center.Y,
                            Z = surface.Y
                        }
                    };
                    voxelList.Add(voxel);
                }
            }

            PreRendered = voxelList.ToArray();
        }
    }
}
