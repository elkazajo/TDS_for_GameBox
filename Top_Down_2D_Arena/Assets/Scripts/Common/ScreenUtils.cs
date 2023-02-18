using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{
    private static Camera mainCamera;

    public static void Initialize()
    {
        mainCamera = Camera.main;
    }

    public static float GetScreenWidth()
    {
        return Screen.width;
    }

    public static float GetScreenHeight()
    {
        return Screen.height;
    }

    public static float GetWorldWidth()
    {
        return 2f * mainCamera.orthographicSize * mainCamera.aspect;
    }

    public static float GetWorldHeight()
    {
        return 2f * mainCamera.orthographicSize;
    }

    public static Vector3 ScreenToWorldPoint(Vector3 screenPoint)
    {
        return mainCamera.ScreenToWorldPoint(screenPoint);
    }

    public static Vector3 WorldToScreenPoint(Vector3 worldPoint)
    {
        return mainCamera.WorldToScreenPoint(worldPoint);
    }
}
