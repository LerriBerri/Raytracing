namespace Raytracing
{
    class Camera
    {

        int resX;
        int resY;

        public double fOVX;
        public double fOVY;

        public Vector3 pos;

        public Camera(Point res, Vector3 pos, Vector3 dir, double fOV)
        {
            resX = res.X;
            resY = res.Y;

            this.pos = pos;

            this.fOVX = fOV;
            fOVY = fOVX * ((double) resX / resY);
        }

        public Vector3 GetPointingTo(double x, double y) {
            double angleZ = (-y / resY + .5) * fOVY;
            double angleY = (x / resX - .5) * fOVX;

            double cosY = Math.Cos(angleY);

            return new Vector3(cosY, Math.Tan(angleZ) * cosY, Math.Sin(angleY));
        }
    }
}