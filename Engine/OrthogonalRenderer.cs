using System;
using System.Linq;
using System.Text;

namespace ASCII_Donut.Engine
{
    public sealed class OrthogonalRenderer
    {
        private readonly int VIEWPORT_WIDTH;
        private readonly int VIEWPORT_HEIGHT;
        private char[,] _frameBuffer;
        private int[,] _depthBuffer;
        private readonly char[] _DEPTH_GRADIENT = @"MËWQB#NEHKRXgqApmG8$ëdbFDZPhkS9UTe6Oyxf45&a2wY0VL3C@nsuzJItocrjv1l=<>i7[?}*{+()\|!÷¦^~­;:,.".ToCharArray().Reverse().ToArray();

        public OrthogonalRenderer(int viewportWidth, int viewportHeight)
        {
            VIEWPORT_WIDTH = viewportWidth;
            VIEWPORT_HEIGHT = viewportHeight;
            _frameBuffer = new char[viewportWidth, viewportHeight];
            _depthBuffer = new int[viewportWidth, viewportHeight];
        }

        public void ClearBuffers()
        {
            _frameBuffer = new char[VIEWPORT_WIDTH, VIEWPORT_HEIGHT];
            _depthBuffer = new int[VIEWPORT_WIDTH, VIEWPORT_HEIGHT];
        }
        public void Render(IVoxelModel model)
        {
            // Filling depth buffer
            foreach(Voxel v in model.PreRendered)
            {
                // Copying v.Position
                Point newPosition = new()
                {
                    X = v.Position.X,
                    Y = v.Position.Y,
                    Z = v.Position.Z
                };

                // Rotating on vertical space
                double newX = newPosition.X;

                newPosition.X = newPosition.Y;
                newPosition.Y = newPosition.Z;
                newPosition = Calcs.RotatePoint2D(newPosition, model.Rotation.X);

                newPosition.Z = newPosition.Y;
                newPosition.Y = newPosition.X;
                newPosition.X = newX;

                // Rotating on horizontal space
                newPosition = Calcs.RotatePoint2D(newPosition, model.Rotation.Y);

                newPosition += model.Position;

                // Checking is newPosition fits in viewport's borders
                int x = (int)Math.Floor(newPosition.X);
                int y = (int)Math.Floor(newPosition.Y);
                int z = (int)Math.Floor(newPosition.Z);

                if (x >= 0 && x < VIEWPORT_WIDTH && y >= 0 && y < VIEWPORT_HEIGHT)
                {
                    // Checking is newPosition higher than last value in depth buffer
                    if (_depthBuffer[x, y] < z)
                    {
                        _depthBuffer[x, y] = z;

                        // Rendering voxel in frame buffer
                        if (z < _DEPTH_GRADIENT.Length && z != 0)
                            _frameBuffer[x, y] = _DEPTH_GRADIENT[z];
                    }
                }
            }

            // Creating output string
            StringBuilder sb = new();
            for(int y = 0; y < VIEWPORT_HEIGHT; y++)
            {
                for(int x = 0; x < VIEWPORT_WIDTH; x++)
                {
                    char tile = _frameBuffer[x, y];
                    if(tile == '\0')
                        sb.Append(' ');
                    else
                        sb.Append(tile);
                }
                sb.Append('\n');
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(sb);
        }
    }
}
