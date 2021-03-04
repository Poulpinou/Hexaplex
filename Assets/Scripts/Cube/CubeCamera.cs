using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hexaplex.Cube {
    [RequireComponent(typeof(Camera))]
	public class CubeCamera : MonoBehaviour
    {
        [Header("Speed")]
        [SerializeField]
        private float translationSpeed = 1;

        [SerializeField]
        private float rotationSpeed = 45;

        [SerializeField]
        private float zoomSpeed = 10;

        [SerializeField]
        private float mouseDragSensitivity = 5;


        [Header("Limits")]
        [SerializeField]
        private float minZoom = 20;

        [SerializeField]
        private float maxZoom = 1;


        [Header("Default")]
        [SerializeField]
        private float defaultZoom = 10;


        private Camera camera;
        private Cube cube;
        private Vector3 up = Vector3.up;


        private void Start()
        {
            camera = GetComponent<Camera>();
            cube = Cube.Current;

            if (!cube)
            {
                throw new Exception("No Cube found in the scene, a Cube is required to use this camera");
            }

            transform.position = new Vector3(cube.Size / 2, cube.Size / 2, -(defaultZoom + cube.Size / 2));
            transform.eulerAngles = Vector3.zero;
        }

        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                transform.RotateAround(cube.Center, up, Input.GetAxis("Mouse X") * mouseDragSensitivity * rotationSpeed * Time.deltaTime);
                transform.RotateAround(cube.Center, Vector3.left, Input.GetAxis("Mouse Y") * mouseDragSensitivity * rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.RotateAround(cube.Center, up, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.RotateAround(cube.Center, up, -rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.UpArrow) && Vector3.Distance(transform.position, cube.Center) > cube.Size / 2 + maxZoom)
            {
                transform.Translate(new Vector3(0, 0, zoomSpeed * Time.deltaTime), Space.Self);
            }

            if (Input.GetKey(KeyCode.DownArrow) && Vector3.Distance(transform.position, cube.Center) < cube.Size / 2 + minZoom)
            {
                transform.Translate(new Vector3(0, 0, - zoomSpeed * Time.deltaTime), Space.Self);
            }
        }
    }
}