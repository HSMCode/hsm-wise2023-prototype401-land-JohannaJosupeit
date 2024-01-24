using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackAnimalScript : MonoBehaviour
{
    private float speed = 3f; // Adjust the speed as needed
    private bool movingRight = true;
    private bool dropped, placed;
    private Rigidbody rb;
    private GameObject elephant;
    public Texture[] textures;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        speed = 2f;
        dropped = false;
        placed = false;

        SkinnedMeshRenderer renderer = GetComponent<SkinnedMeshRenderer>();

        Texture randomTexture = textures[Random.Range(0, textures.Length)];

        renderer.material.mainTexture = randomTexture;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
            dropped = true;
        }

        else if (!dropped)
        {
            float movement = speed * Time.deltaTime;

            if (movingRight)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                transform.Translate(Vector3.forward * movement);

                if (transform.position.x >= 4f)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                transform.Translate(Vector3.forward * movement);

                if (transform.position.x <= -4f)
                {
                    movingRight = true;
                }
            }
        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            Debug.LogError("GAME OVER");
        }
        if(!placed)
        {
            transform.SetParent(col.transform);
            spawnerScript.spawning = true;
            placed = true;
        }
    }
}