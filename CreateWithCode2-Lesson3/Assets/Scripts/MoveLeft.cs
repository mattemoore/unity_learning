using System;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.gameOver && !playerController.playerIntro.isActive)
            this.transform.Translate(Vector3.left * Time.deltaTime * (speed + (Convert.ToInt16(playerController.isPlayerDashing) * speed / 2)));
    }
}
