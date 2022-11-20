namespace Raytracing
{
    class Camera
    {

        int resX;
        int resY;

        double fOVX;
        double fOVY;
        double distance;

        public Vector3 pos;
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
            fOVY = fOVX * ((double) resX / resY);

            CalculateScreenVectors();
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

        public Vector3 GetPointingTo(double x, double y) {
            x -= resX / 2;
            y -= resY / 2;

            double facX = x / (resX / 2);
            double facY = y / (resY / 2);

            return Vector3.Add(Vector3.Add(pos, dir.Mult(distance)), Vector3.Add(pX.Mult(facX), pY.Mult(facY)));
        }
    }
}