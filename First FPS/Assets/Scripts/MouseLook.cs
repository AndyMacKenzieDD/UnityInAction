﻿using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotateAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    public RotateAxes axes = RotateAxes.MouseXAndY;
    public float sensitivityHor = 3.0f;
    public float sensitivityVert = 3.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0.0f;

	void Start ()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        {
            body.freezeRotation = true;
        }
	}
	
	void Update ()
    {
		if(axes == RotateAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
		else if(axes == RotateAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            
            float rotationY = transform.localEulerAngles.y;
            
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
		else if(axes == RotateAxes.MouseXAndY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
	}
}
