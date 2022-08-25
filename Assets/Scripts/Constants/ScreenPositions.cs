using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Constants
{
    public static class ScreenPositions
    {
        public static readonly float LeftLimit;
        public static readonly float RightLimit;
        public static readonly float BottomLimit;
        public static readonly float TopLimit;

        static ScreenPositions ()
        {
            Camera camera = Camera.main;

            Vector3 temp = new(0, 0, camera.transform.position.z);
            RightLimit = camera.ScreenToWorldPoint(temp).x;
            TopLimit = camera.ScreenToWorldPoint(temp).y;
            temp.x = Screen.width;
            temp.y = Screen.height;
            LeftLimit = camera.ScreenToWorldPoint(temp).x;
            BottomLimit = camera.ScreenToWorldPoint(temp).y;
        }
    }
}