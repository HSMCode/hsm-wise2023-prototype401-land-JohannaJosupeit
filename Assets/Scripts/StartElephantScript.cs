using UnityEngine;

public class StartElephantScript : MonoBehaviour
{
    public float speed = 2f; // Adjust the speed as needed
    public bool movingRight = true;
    public Texture[] textures;

    private void Start()
    {
        SkinnedMeshRenderer renderer = GetComponent<SkinnedMeshRenderer>();

        Texture randomTexture = textures[Random.Range(0, textures.Length)];

        renderer.material.mainTexture = randomTexture;
    }

    void Update()
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