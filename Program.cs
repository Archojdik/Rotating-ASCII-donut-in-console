using System;
using System.Threading;

using ASCII_Donut.Engine;
using ASCII_Donut.Primitives;

namespace ASCII_Donut
{
    class Program
    {
        const double DONUT_MAIN_RING_RADIUS = 20;
        const double DONUT_SECOND_RING_RADIUS = 8;
        const double DONUT_FORMING_ANGLE_STEP = 2;

        static readonly Point DONUT_POSITION = new(30, 30, 28);

        const int VIEWPORT_WIDTH = 60;
        const int VIEWPORT_HEIGHT = 60;

        const double ROTATING_ANGLE_X = 3;
        const double ROTATING_ANGLE_Y = 1;

        const int FRAME_LATENCY_MS = 10;

        static void Main()
        {
            try
            {
                Donut donut = new(DONUT_MAIN_RING_RADIUS, DONUT_SECOND_RING_RADIUS, DONUT_FORMING_ANGLE_STEP);
                donut.Position = DONUT_POSITION;

                OrthogonalRenderer renderer = new(VIEWPORT_WIDTH, VIEWPORT_HEIGHT);
                while (true)
                {
                    renderer.ClearBuffers();
                    renderer.Render(donut);

                    donut.Rotation += new Rotation(ROTATING_ANGLE_X, ROTATING_ANGLE_Y);

                    Thread.Sleep(FRAME_LATENCY_MS);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
