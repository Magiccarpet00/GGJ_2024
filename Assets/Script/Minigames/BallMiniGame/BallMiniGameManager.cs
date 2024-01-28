using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallMiniGameManager : MiniGameManager
{
    public static BallMiniGameManager instance;
    [SerializeField] private bool win;
    public bool lose;
    public float miniGameTime;

    [HideInInspector] public bool gameStarted;

    [SerializeField] private BallMcFirst ball;

    [SerializeField] private GameObject prefabBras;
    [SerializeField] private GameObject brasIdle;
    [SerializeField] private Animator brasIldeAnim;

    [SerializeField] private int nbBras;
    [SerializeField] private float offSetTime;

    [SerializeField] private float[] speedTab;

    private void Awake()
    {
        instance = this;
        ball.speed = speedTab[difficultyParameter];
    }

    public void StartGame()
    {
        gameStarted = true;
        StartCoroutine(Chronos());
    }
    
    public void PreLose()
    {
        if (win == false)
        {
            lose = true;
            Lose();
        }
    }   

    private IEnumerator Chronos()
    {
        yield return new WaitForSeconds(miniGameTime);
        
        if(lose == false)
        {
            win = true;
            Win();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) // CODE TMP
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;

        brasIdle.transform.position = new Vector3(worldPosition.x, brasIdle.transform.position.y, 0);



        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CreateBras(worldPosition));
        }

        if (nbBras == 0)
            brasIldeAnim.SetBool("Hide", false);
        else
            brasIldeAnim.SetBool("Hide", true);

    }

    private IEnumerator CreateBras(Vector3 pos)
    {
        Instantiate(prefabBras, pos, Quaternion.identity);
        nbBras++;
        yield return new WaitForSeconds(offSetTime);
        nbBras--;
    }

    
}
