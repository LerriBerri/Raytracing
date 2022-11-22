namespace Raytracing
{
    class Mesh
    {
        Triangle[] triangles;

        public Mesh(Triangle[] triangles)
        {
            this.triangles = triangles;
        }

        /**
        <summary>
        Determines the triangle whose intersection point with the line is the closest to l0.
        If there is no intersection with any triangle the return value is null.
        </summary>
        */
        public Triangle GetNearesIntersection(Vector3 l0, Vector3 l1)
        {
            double smallestDistance = -1;
            Triangle nearestTriangle = null;
            for (int i = 0; i < triangles.Length; i++)
            {
                double d = triangles[i].GetIntersection(l0, l1);
                if(d == -1)
                    continue;
                if(smallestDistance == -1 || d < smallestDistance)
                {
                    smallestDistance = d;
                    nearestTriangle = triangles[i];
                }
            }
            return nearestTriangle;
        }

        /**
        <summary>
        Rotates the mesh around the x axes.
        </summary>
        */
        public void RotateX(double angle)
        {
            for(int i = 0; i < triangles.Length; i++)
            {
                triangles[i].RotateX(angle);
            }
        }

        /**
        <summary>
        Rotates the mesh around the y axes.
        </summary>
        */
        public void RotateY(double angle)
        {
            for(int i = 0; i < triangles.Length; i++)
            {
                triangles[i].RotateY(angle);
            }
        }

        /**
        <summary>
        Rotates the mesh around the z axes.
        </summary>
        */
        public void RotateZ(double angle)
        {
            for(int i = 0; i < triangles.Length; i++)
            {
                triangles[i].RotateZ(angle);
            }
        }
    }
}