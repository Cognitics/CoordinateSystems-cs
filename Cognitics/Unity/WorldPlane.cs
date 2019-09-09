
using UnityEngine;

namespace Cognitics.Unity
{
    public class WorldPlane
    {
        public readonly CoordinateSystems.ILocalTangentPlane LocalTangentPlane;
        public readonly double Scale;

        public WorldPlane(CoordinateSystems.ILocalTangentPlane local_tangent_plane, double scale = 1.0)
        {
            LocalTangentPlane = local_tangent_plane;
            Scale = scale;
        }

        public void ConvertFromGeodetic(double latitude, double longitude, double altitude, out Vector3 position)
        {
            LocalTangentPlane.GeodeticToLocal(latitude, longitude, altitude, out double east, out double north, out double up);
            position.x = (float)(east * Scale);
            position.y = (float)(up * Scale);
            position.z = (float)(north * Scale);
        }

        public void ConvertToGeodetic(Vector3 position, out double latitude, out double longitude, out double altitude)
        {
            LocalTangentPlane.LocalToGeodetic(position.x / Scale, position.z / Scale, position.y / Scale, out latitude, out longitude, out altitude);
        }

    }

}
