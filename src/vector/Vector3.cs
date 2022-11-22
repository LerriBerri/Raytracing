using System;

namespace Raytracing
{
    /**
    <summary>
    Represents a three dimensional vector.
    </summary>
    */
    class Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /**
        <summary>
        Initializes the vector with x, y and z set to 0.
        </summary>
        */
        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        /**
        <summary>
        Return a copy of the vector object.
        </summary>
        */
        public Vector3 Copy() {
            return new Vector3(x, y, z);
        }

        /**
        <summary>
        Adds the x, y and z values of the two vectors and returns a new one.
        </summary>
        */
        public static Vector3 Add(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
        }

        /**
        <summary>
        Subtracts the x, y and z values of the the first vector from the x, y and z values of the second vector and returns a new vector.
        </summary>
        */
        public static Vector3 Sub(Vector3 vector1, Vector3 vector2) {
            return new Vector3(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
        }

        /**
        <summary>
        Multiplies the x, y and z vlaue with the factor parameter and returns a new Vector.
        </summary>
        */
        public Vector3 Mult(double fac)
        {
            return new Vector3(x * fac, y * fac, z * fac);
        }

        /**
        <summary>
        Returns the dot product of two vectors. It is computed by multiplying the x value from both vectors the y values from both vectors and the z values from both vectors and adding the results.
        For any two vectors the formula for the dot product is:
        a * b = ||a||*||b||*cos(angle)
        ||a|| is the magnitude of the first vector. ||b|| is the magnitude of the second vector.
        If the dot product is 0 the two vectors are PI / 2 radians apart.
        </summary>
        */
        public static double DotProduct(Vector3 vector1, Vector3 vector2)
        {
            return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
        }

        /**
        <summary>
        Returns the cross product of the two passed vectors. It is the Vector perpendicular to vector1 and vector2. If the vectors are parallel the cross product is 0.
        The formula for computing the cross product of any two vectors is:
        a x b = ||a||*||b||*sin(angle)*n
        ||a|| is the magnitude of the first vector. ||b|| is the magnitude of the second vector.
        the angle is the angle between vector a and b.
        n is the Vector perpendicular to a and b.
        the cross product is anticommutativ
        <example>
        which means if a x b = c then b x a = -c
        </example>
        </summary>
        */
        public static Vector3 CrossProduct(Vector3 vector1, Vector3 vector2)
        {
            double s1 = vector1.y * vector2.z - vector1.z * vector2.y;
            double s2 = vector1.z * vector2.x - vector1.x * vector2.z;
            double s3 = vector1.x * vector2.y - vector1.y * vector2.x;

            return new Vector3(s1, s2, s3);
        }

        /**
        <summary>
        Rotates the vector around the x axes.
        </summary>
        */
        public void RotateX(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            double prevY = y;
            double prevZ = z;

            y = prevY * cos - prevZ * sin;
            z = prevY * sin + prevZ * cos;
        }

        /**
        <summary>
        Rotates the vector around the y axes.
        </summary>
        */
        public void RotateY(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            double prevX = x;
            double prevZ = z;

            x = prevX * cos - prevZ * sin;
            z = prevX * sin + prevZ * cos;
        }

        /**
        <summary>
        Rotates the vector around the y axes.
        </summary>
        */
        public void RotateZ(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            double prevX = x;
            double prevY = y;

            x = prevX * cos - prevY * sin;
            y = prevX * sin + prevY * cos;
        }
    }
}
