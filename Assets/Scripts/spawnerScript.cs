using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEditor.SceneManagement;

public class spawnerScript : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject gameOverScreen;
    public GameObject tutorial;
    public Camera mainCamera;
    public GameObject background;
    public static int rounds;
    public static bool spawning;
    private float camPos;
    private Vector3 bgScale;
    public static bool isAlive;
    private int score;
    public TextMeshProUGUI scoreText;
    public static float distance;


    // Start is called before the first frame update
    void Start()
    {
        distance = 5f;
        score = 0;
        isAlive = true;
        rounds = 0;
        spawning = true;
        mainCamera.orthographicSize = 5;
        camPos = 5;
        bgScale = background.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, camPos, 3f * Time.deltaTime);
        
        if (spawning && isAlive)
        {
            Instantiate(spawnObject, transform.position, Quaternion.identity);
            rounds++;
            distance++;
            spawning = false;
            bgScale -= new Vector3(0.3f, 0.3f, 0.3f);
            camPos += 1f;
            mainCamera.transform.position += new Vector3(0, 0.7f, 0);
            transform.position += new Vector3(0, 2f, 0);
        }

        score = rounds - 1;
        scoreText.text = score.ToString();

        if (!isAlive)
        {
            gameOverScreen.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isAlive)
        {
            EditorSceneManager.LoadScene("LandGame");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorial.SetActive(false);
        }
    }

}
