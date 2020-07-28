using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0;
    public float gravity = 3;

    public float jumpSpeed = 10;
    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;


    private Camera mainCamera;

    public PistolController pistol;

    public RifleController rifle;

    public ShotGunController shotGun;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if(controller.isGrounded)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection *= moveSpeed;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y += jumpSpeed;
            }

            controller.Move(moveDirection * Time.deltaTime);
        }

        moveDirection.y -= gravity;
        controller.Move(moveDirection * Time.deltaTime);

        //開始射擊處理
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLenght;  //Ray長度

        //Camera射Ray到地面 玩家面向Ray
        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        //射撃
        if (Input.GetMouseButtonDown(0))
        {
            pistol.isFiring = true;
            rifle.isFiring = true;
            shotGun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pistol.isFiring = false;
            rifle.isFiring = false;
            shotGun.isFiring = false;
        }
    }
}
