using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject spawnObject;
    public Camera mainCamera;
    public static int rounds;
    public static bool spawning;
    private Vector3 camPos;
   

    // Start is called before the first frame update
    void Start()
    {
        rounds = 0;
        spawning = true;
        mainCamera.orthographicSize = 5;

    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            Instantiate(spawnObject, transform.position, Quaternion.identity);
            rounds++;
            spawning = false;
            mainCamera.orthographicSize += 1f;
            mainCamera.transform.position += new Vector3(0, 0.7f, 0);
            transform.position += new Vector3(0, 2f, 0);
        }
    }

}
