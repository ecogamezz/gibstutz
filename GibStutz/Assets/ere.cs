﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ere : MonoBehaviour
{
	public float speed = 1;
	public XRNode inputSource;
	public float gravity = -9.81f;
	public LayerMask groundLayer;
	public float additionalHeight = 0.2f;
	private float fallingspeed;
	private XRRig rig;
    private Vector2 inputAxis;
	private CharacterController character;

    // Start is called before the first frame update
    void Start()
	{
		character = GetComponent<CharacterController>();
		rig = GetComponent<XRRig>();
	}

	

	// Update is called once per frame
	void Update()
	{
		InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
		device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
	}

	private void FixedUpdate()
    {
		CapsuleFollowHeadset();
		Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
		Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

		
		character.Move(direction * Time.fixedDeltaTime * speed);


		// Gravity
		bool isGrounded = CheckifonGround();
		if (isGrounded)
			fallingspeed = 0;
		else
			fallingspeed += gravity * Time.fixedDeltaTime;
		character.Move(Vector3.up * fallingspeed * Time.fixedDeltaTime);
    }

	void CapsuleFollowHeadset()
    {
		character.height = rig.cameraInRigSpaceHeight + additionalHeight;
		Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
		character.center = new Vector3(capsuleCenter.x, character.height/2 + character.skinWidth, capsuleCenter.z);
    }

	bool CheckifonGround()
    {
		Vector3 rayStart = transform.TransformPoint(character.center);
		float rayLenght = character.center.y + 0.01f;
		bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLenght, groundLayer);
		return hasHit;
    }
}