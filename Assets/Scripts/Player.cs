using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera camera;
    private bool run;
    private float moveHorizontal;
    private Rigidbody2D rigidBody;
    private GameManager gameManager;

    public float speed = 10f;
    public GameObject platformPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        run = false;
        rigidBody = GetComponent<Rigidbody2D>();
        camera = UnityEngine.Camera.main;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = moveHorizontal;
        rigidBody.velocity = newVelocity;
    }

    void OnEnable()
    {
        transform.position = new Vector3(camera.transform.position.x,camera.transform.position.y,0.5f);
        rigidBody.gravityScale = 0.97f;
        Instantiate(platformPrefab,new Vector3(transform.position.x,transform.position.y-2,transform.position.z),Quaternion.identity); 
        run = true;
    }

    void OnDisable()
    {
        rigidBody.gravityScale = 0;
        run = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * speed;
        Vector3 viewPos = camera.WorldToViewportPoint(transform.position);
        if(viewPos.y < 0 && run){
          gameManager.GameOver();
        }

        if(transform.position.x <= -2.7f){
          transform.position = new Vector3(-2.7f,transform.position.y,transform.position.z);
        }

        if(transform.position.x >= 2.7f){
          transform.position = new Vector3(2.7f,transform.position.y,transform.position.z);
        }
    }
}
