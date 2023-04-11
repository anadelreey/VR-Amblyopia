using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRAmbliopy
{
    public class MouseLook2camaras : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform cameraTRS1;
        [SerializeField] private Transform cameraTRS2;
        [SerializeField] private bool invertY = true;
        [SerializeField] private float mouseSensitivity = 100.0f;
        [SerializeField] private float clampAngle = 90.0f;

        // rotation around the up/y axis
        private float rotX = 0.0f; // rotation around the right/x axis

        // Start is called before the first frame update
        void Start()
        {
            rotX = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            float valX = mouseX * mouseSensitivity * Time.deltaTime;
            float valY = mouseY * mouseSensitivity * Time.deltaTime;

            rotX += valY * (invertY ? -1 : 1);
            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            cameraTRS1.localRotation = Quaternion.Euler(rotX, 0f, 0f);
            cameraTRS2.localRotation = Quaternion.Euler(rotX, 0f, 0f);

            player.Rotate(Vector3.up * valX);
        }
    }
}