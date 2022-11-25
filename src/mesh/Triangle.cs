namespace Raytracing
{
    /**
    <summary>
    A triangle is defined by three points, which represent the edges of the triangle.
    the points should be defined anticlockwise.
    <example>
    a triangle should be defined (0, 0, 0); (0, 1, 0); (0, 0, 1),
    when it is supposed to face towards positive x.
    </example>
    </summary>
    */
    class Triangle
    {
        public Vector3 p0;
        public Vector3 p1;
        public Vector3 p2;
        private Vector3 p01;
        private Vector3 p02;

        private Vector3 normal;

        public Triangle(Vector3 p0, Vector3 p1, Vector3 p2)
        {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;

            p01 = Vector3.Sub(p1, p0);
            p02 = Vector3.Sub(p2, p0);
        }

        /**
        <summary>
        Calculates the intersectionpoint of the given line with the triangle.
        </summary>
        <param name="l0">The startpoint of the line</param>
        <param name="l1">A point on the line</param>
        <returns>
        If there is no intersection -1 is returned.
        The method returns a double. To get the coordinates of the intersectionpoint use the formula
        p = l0 + l01 * d
        where l01 is the vector pointing from l0 to l1 and
        d is the returned value.
        </returns>
        */
        public double GetIntersection(Vector3 l0, Vector3 l1)
        {
            Vector3 l01 = Vector3.Sub(l1, l0);

            double den = Vector3.DotProduct(l01.Mult(-1), Vector3.CrossProduct(p01, p02));

            double uNum = Vector3.DotProduct(Vector3.CrossProduct(p02, l01.Mult(-1)), Vector3.Sub(l0, p0));
            double u = uNum / den;


            double vNum = Vector3.DotProduct(Vector3.CrossProduct(l01.Mult(-1), p01), Vector3.Sub(l0, p0));
            double v = vNum / den;

            if (u < 0 || v < 0)
                return -1;
            if (u + v > 1)
                return -1;

            double tNum = Vector3.DotProduct(Vector3.CrossProduct(p01, p02), Vector3.Sub(l0, p0));
            double t = tNum / den;

            if (t < 0)
                return -1;

            return t;
        }

        private void CalculateNormal()
        {
            normal = Vector3.CrossProduct(p01, p02);

            double fac = 1 / Math.Sqrt(normal.x * normal.x + normal.y * normal.y + normal.z * normal.z);

            normal.x *= fac;
            normal.y *= fac;
            normal.z *= fac;
        }

        /**
        <summary>
        Rotates the triangle around the x axes.
        </summary>
        */
        public void RotateX(double angle)
        {
            p0.RotateX(angle);
            p1.RotateX(angle);
            p2.RotateX(angle);

            p01 = Vector3.Sub(p1, p0);
            p02 = Vector3.Sub(p2, p0);
        }

        /**
        <summary>
        Rotates the triangle around the y axes.
        </summary>
        */
        public void RotateY(double angle)
        {
            p0.RotateY(angle);
            p1.RotateY(angle);
            p2.RotateY(angle);

            p01 = Vector3.Sub(p1, p0);
            p02 = Vector3.Sub(p2, p0);
        }

        /**
        <summary>
        Rotates the triangle around the z axes.
        </summary>
        */
        public void RotateZ(double angle)
        {
            p0.RotateZ(angle);
            p1.RotateZ(angle);
            p2.RotateZ(angle);

            p01 = Vector3.Sub(p1, p0);
            p02 = Vector3.Sub(p2, p0);
        }
    }
}