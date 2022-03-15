using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
   [SyncVar(hook = nameof(NumCountChange))]
   int numCount = 0;

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
            PlayerToHigh();
        }*/
    }

    
    [Command]
    void MessageCheck()
    {
        Debug.Log("Received message from client!");
        numCount += 1;
        ServerAcklowledgement();
    }

    //Update change only on target client
    //ex: pickup item inventory update information
    [TargetRpc]
    void ServerAcklowledgement()
    {
        Debug.Log("Receiverd message from server!");
    }

    //(update changes can be seen on all the clients)
    [ClientRpc]
    void PlayerToHigh()
    {
        Debug.Log("Too high!");
    }

    
    void NumCountChange(int oldCount, int newCount)
    {
        Debug.Log($"We had {oldCount} num , now we have {newCount} num ");
    }

}
