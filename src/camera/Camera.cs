namespace Raytracing
{
    class Camera
    {

        int resX;
        int resY;

        double fOVX;
        double fOVY;
        double distance;

        Vector3 pos;
        Vector3 dir;

        Vector3 pX;
        Vector3 pY;

        public Camera(Point res, Vector3 pos, Vector3 dir, double fOV, double distance)
        {
            resX = res.X;
            resY = res.Y;

            this.pos = pos;
            this.dir = dir;

            this.distance = distance;

            this.fOVX = fOV;
            fOVY = fOVX * (resX / resY);
        }

        private void CalculateScreenVectors() {
            Vector3 up = new Vector3(0, 1, 0);

            pX = Vector3.CrossProduct(dir, up);
            pY = Vector3.CrossProduct(dir, pX);

            double magNum = Math.Pow(Vector3.DotProduct(up, dir), 2);
            double magDen = 1 + dir.x * dir.x + dir.y * dir.y + dir.z * dir.z;

            double mag = Math.Sqrt(1 - (magNum / magDen));

            pX.Mult((distance * Math.Tan(fOVX / 2)) / mag);
            pY.Mult((distance * Math.Tan(fOVY / 2)) / mag);
        }
    }
}