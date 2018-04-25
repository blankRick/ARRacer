using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    public float x, y, xDelta, yDelta;
    private int screenX, screenY;
    public Transform planeTransform;
    public Transform cameraTransform;
    public float offset;
    public float viewOffset;
    public float cameraOffset;
    public float lerpFactor;
    public float cameraLerpFactor;
    public float slerpFactor;
    public float angleOffsetX;
    public float angleOffsetY;
    public float angleTrimY;
    public float stabilityDist;
    public float stabilityFactor;

    // Use this for initialization
    void Start() {
        screenX = Screen.width;
        screenY = Screen.height;
    }

    // Update is called once per frame
    void Update() {
        x = cameraTransform.localPosition.x/cameraOffset;
        y = cameraTransform.localPosition.y/cameraOffset;
        xDelta = planeTransform.localPosition.x - x * offset;
        yDelta = planeTransform.localPosition.y - y * offset;
        if(new Vector3(xDelta,yDelta).magnitude < stabilityDist)
        {
            x /= stabilityFactor;
            y /= stabilityFactor;

            xDelta /= stabilityFactor;
            yDelta /= stabilityFactor;
        }
        planeTransform.localPosition = Vector3.Lerp(planeTransform.localPosition, new Vector3(x * offset, y * offset - viewOffset, 0), lerpFactor);
        planeTransform.localRotation = Quaternion.Slerp(planeTransform.localRotation, Quaternion.Euler(yDelta * angleOffsetY + angleTrimY, 0, xDelta * angleOffsetX), slerpFactor);

        //cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, new Vector3(x * cameraOffset, y * cameraOffset, 0), cameraLerpFactor);
    }

    public void Collision() {
        GameManager.instance.Collision();
    }

}
