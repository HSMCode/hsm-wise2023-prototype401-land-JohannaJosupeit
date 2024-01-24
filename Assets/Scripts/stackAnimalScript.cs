using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackAnimalScript : MonoBehaviour
{
    private float speed = 2f;
    private bool movingRight = true;
    private bool dropped, placed;
    private Rigidbody rb;
    public Texture[] textures;
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        dropped = false;
        placed = false;
        speed = 1 + spawnerScript.rounds;

        SkinnedMeshRenderer renderer = GetComponent<SkinnedMeshRenderer>();

        Texture randomTexture = textures[Random.Range(0, textures.Length)];

        renderer.material.mainTexture = randomTexture;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && spawnerScript.isAlive)
        {
            rb.useGravity = true;
            dropped = true;
        }

        else if (!dropped && spawnerScript.isAlive)
        {
            float movement = speed * Time.deltaTime;

            if (movingRight)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                transform.Translate(Vector3.forward * movement);

                if (transform.position.x >= spawnerScript.distance)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                transform.Translate(Vector3.forward * movement);

                if (transform.position.x <= -spawnerScript.distance)
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
            spawnerScript.isAlive = false;
        }
        if(!placed)
        {
            animator.SetBool("landed", true);
            transform.SetParent(col.transform);
            spawnerScript.spawning = true;
            placed = true;
        }
    }
}