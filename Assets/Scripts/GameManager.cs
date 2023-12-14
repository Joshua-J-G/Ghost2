using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<AI_Manager> AI = new();

    public static GameManager instance;

    public int maxPosessions = 6;

    public int currentPosession;


    public GuessMenu GuessMenu;

    public AI_Manager Possesed;

    [SerializeField] GameObject ScreenBlink;


    [SerializeField] TMP_Text ProgessAmount;
    [SerializeField] Slider value;

    public GameObject WinScreen;

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public GameObject EndScreen;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(gameObject);
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("AI"))
            {
                AI.Add(g.GetComponent<AI_Manager>());
            }
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
   
        
        GuessMenu = GameObject.FindGameObjectWithTag("GuessMenu").GetComponent<GuessMenu>();
        GuessMenu.gameObject.SetActive(false);
        ChooseEnemy();

        //InvokeRepeating("BlinkScreen", 1,0.8f);

    }

    IEnumerator MakeScreenBlink(float duration)
    {
        ScreenBlink.SetActive(true);
        yield return new WaitForSeconds(duration);
        ScreenBlink.SetActive(false);
    }

    public float currentPercentage;

    // Update is called once per frame
    void Update()
    {
        if(currentPosession == (maxPosessions+1))
        {
            WinScreen.SetActive(true);
        }

        currentPercentage += currentPosession/2 * Time.deltaTime/2;
        currentPercentage = Mathf.Clamp(currentPercentage, 0, 100);
        value.value = currentPercentage;
        if (currentPercentage >= 100)
        {
            EndScreen.SetActive(true);
            
        }
        ProgessAmount.text = $"{Mathf.RoundToInt(currentPercentage)}%";
        if (Input.GetMouseButtonDown(1))
        {
            GuessMenuSwap();
        }
    }

    public void GuessMenuSwap()
    {
        GuessMenu.gameObject.SetActive(!GuessMenu.gameObject.activeSelf);
    }

    public void BlinkScreen()
    {
        StartCoroutine(MakeScreenBlink(0.04f));
    }


    public void ChooseEnemy()
    {

        GuessMenu.SetText($"{currentPosession}/{maxPosessions}");
        Possesed = AI[Random.Range(0, AI.Count)];
        Possesed.Possessed = true;

        foreach (AI_Manager manager in AI)
        {
            manager.GhostSelected = true;
        }
        currentPosession++;
    }





}
