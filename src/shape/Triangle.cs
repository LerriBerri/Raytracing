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

        public Triangle(Vector3 p0, Vector3 p1, Vector3 p2) {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
        }
    }
}