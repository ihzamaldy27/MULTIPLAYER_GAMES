using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator anim;
    public Inventory inventory;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float mSpeedY = 0;
    float mGravity = -9.81f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        anim = GetComponent<Animator>();
        Debug.Log(anim);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (!controller.isGrounded)
        {
            mSpeedY += mGravity * Time.deltaTime;
        }
        else {
            mSpeedY = 0;
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 verticalMovement = Vector3.up * mSpeedY;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angel, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(verticalMovement + (moveDir * speed) * Time.deltaTime);
            anim.SetFloat("Speed", 1f);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 3f;
                anim.SetFloat("Speed", 0.6f);
            }
            else {
                speed = 6f;
            }
        }
        
        else {
            anim.SetFloat("Speed", 0);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("Speed", 0.3f);
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item") {
            Debug.Log("Ini Item");

            inventory.data_item[0] = other.GetComponent<ItemData>();
            if (controller && Input.GetKeyDown(KeyCode.E))
            {
                inventory.showItem();
            }

        }
    }
}
