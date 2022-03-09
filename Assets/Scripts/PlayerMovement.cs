using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
   private void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float moveHorizontol = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontol * 0.1f, moveVertical * 0.1f, 0);
            transform.position = transform.position + movement;
        }
    }

    private void Update()
    {
        HandleMovement();

        if(isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Sending message to server");
            MessageCheck();
        }

        /*if(isServer && transform.position.y > 20)
        {
            PlayerToHight();
        }*/
    }

    [Command]
    void MessageCheck()
    {
        Debug.Log("Received message from client!");
    }

    [ClientRpc]
    void PlayerToHight()
    {
        Debug.Log("Too higth!");
    }


}
