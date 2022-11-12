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
        Adds to the x, y and z coordinates the x, y and z coordinates of the vector parameter.
        </summary>
        <returns>
        Return itself after adding the vector parameter.
        </returns>
        */
        public Vector3 Add(Vector3 vector)
        {
            x += vector.x;
            y += vector.y;
            z += vector.z;

            return this;
        }

        /**
        <summary>
        Multiplies the x, y and z vlaue with the factor parameter.
        </summary>
        <returns>
        Returns itself after multiplying the values.
        </returns>
        */
        public Vector3 Mult(double fac)
        {
            x *= fac;
            y *= fac;
            z *= fac;

            return this;
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
    }
}
