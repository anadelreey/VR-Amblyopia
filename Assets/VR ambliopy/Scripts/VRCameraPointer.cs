using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraPointer : MonoBehaviour
{
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    protected virtual bool IsGazingObject(out RaycastHit hit)
    {
        return Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance);
    }

    protected virtual void TriggerOnPointerClick()
    {
        _gazedAtObject?.SendMessage("OnPointerClick", SendMessageOptions.DontRequireReceiver);
    }

    protected virtual void TriggerOnPointerExit()
    {
        // No GameObject detected in front of the camera.
        _gazedAtObject?.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
        _gazedAtObject = null;
    }
    protected virtual void OnGazingObject(RaycastHit hit)
    {
        // GameObject detected in front of the camera.
        if (_gazedAtObject != hit.transform.gameObject)
        {
            TriggerOnPointerExitEnter(hit);
        }
    }

    protected virtual void TriggerOnPointerExitEnter(RaycastHit hit)
    {
        // New GameObject.
        _gazedAtObject?.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
        _gazedAtObject = hit.transform.gameObject;
        _gazedAtObject.SendMessage("OnPointerEnter", SendMessageOptions.DontRequireReceiver);
    }

    protected virtual void CheckGazedObject()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (IsGazingObject(out hit))
        {
            OnGazingObject(hit);
        }
        else
        {
            TriggerOnPointerExit();
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            TriggerOnPointerClick();
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    protected virtual void FixedUpdate()
    {
        CheckGazedObject();
    }
}
