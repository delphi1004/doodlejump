using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Camera camera;
    private GameManager gameManager;
    public float jumpForce = 5f;

    void Awake() 
    {
        camera = UnityEngine.Camera.main;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.relativeVelocity.y <= 0f){
            Rigidbody2D rigidBody = other.gameObject.GetComponent<Rigidbody2D>();
            if(rigidBody != null){
                Vector2 newVelocity = rigidBody.velocity;
                newVelocity.y = jumpForce;
                rigidBody.velocity = newVelocity;
                gameManager.AddScore();
                gameManager.CreatePlatform();
            }
        }
    }

    void Update() 
    {
        Vector3 viewPos = camera.WorldToViewportPoint(transform.position);
        if(viewPos.y < 0){
          gameManager.DescreasePlatform();
          Destroy(gameObject);
        }
    }
}
