namespace Raytracing
{
    class Camera
    {

        int resX;
        int resY;

        double fOV;

        Vector3 pos;
        Vector3 dir;

        public Camera(Point res, Vector3 pos, Vector3 dir, double fOV)
        {
            resX = res.X;
            resY = res.Y;

            this.pos = pos;
            this.dir = dir;

            this.fOV = fOV;
        }
    }
}