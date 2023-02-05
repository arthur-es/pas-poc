using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class MouseInputProvider : MonoBehaviour
{
 
    public Vector3 WorldPosition { get; set; }
    Vector3 mos_pos;
    public event Action Clicked;

    private void OnLook(InputValue value)
    {
        Camera camera = FindCamera();
        mos_pos = Mouse.current.position.ReadValue();
        mos_pos.z = camera.nearClipPlane * 30;
        WorldPosition = camera.ScreenToWorldPoint(mos_pos);
    }

    private void OnAction(InputValue _)
    {
        Clicked?.Invoke();
    }

    Camera FindCamera()
    {
        Camera[] cameras = FindObjectsOfType<Camera>();
        Camera result = null;
        int camerasSum = 0;
        foreach (var camera in cameras)
        {
            if (camera.enabled)
            {
                result = camera;
                camerasSum++;
            }
        }
        return result;
    }
}