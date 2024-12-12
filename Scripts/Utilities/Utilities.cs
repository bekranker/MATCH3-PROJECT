using UnityEngine;

public static class Utilities
{
    //returning Screen Width and Height, Z is equel to 0;
    public static Vector3 GetScreenSize()
    {
        return new Vector3(Screen.width, Screen.height, 0);
    }
    private static Vector3 TopLeft(Camera cam) => cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0));
    private static Vector3 TopRight(Camera cam) => cam.ScreenToWorldPoint(GetScreenSize());
    private static Vector3 BottomLeft(Camera cam) => cam.ScreenToWorldPoint(new Vector3(0, 0));
    private static Vector3 BottomRight(Camera cam) => cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, 0));
    /* Get screen size as world position from given camera. Z is equel to 0;
    *  the X is just distance from left to right;
    *  the Y is just distance from top to bottom;
    */
    public static Vector2 GetScreenSize(Camera cam)
    {
        return new Vector2(Vector2.Distance(BottomLeft(cam), BottomRight(cam)), Vector2.Distance(TopLeft(cam), BottomLeft(cam)));
    }
}