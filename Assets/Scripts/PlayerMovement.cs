using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController player;
    public GameObject cam;
    private Vector3 playerVelocity;
    private float moveSpeed = 15.0f;
    private float jumpSpeed = 3.0f;
    private float gravity = -9.81f;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = player.isGrounded;
        if (onGround && playerVelocity.y < 0.0f)
            playerVelocity.y = -2.0f;
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            playerVelocity.y = Mathf.Sqrt(jumpSpeed * -2.0f * gravity);
        if (Input.GetKeyDown(KeyCode.LeftShift) && onGround)
            moveSpeed *= 1.2f;
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 move = player.transform.right * inputX + player.transform.forward * inputZ;
        move = cam.transform.rotation * move;
        player.Move(move * Time.deltaTime * moveSpeed);

        playerVelocity.y += gravity * Time.deltaTime;
        player.Move(playerVelocity * Time.deltaTime * jumpSpeed);
    }
}
