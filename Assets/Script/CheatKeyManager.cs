using TMPro;
using UnityEngine;

public class CheatKeyManager : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerScrips;

    public TMP_InputField levelInput;
    public GameObject BulletLevel;

    public TMP_InputField painInput;
    public GameObject painChanger;

    public TMP_InputField healthInput;
    public GameObject healthChanger;

    public GameObject gameManager;
    public GameObject uiManager;
    private GameManager gm;
    private UI um;



    void Awake()
    {
        player = GameObject.Find("Player");
        playerScrips = player.GetComponent<PlayerController>();
        gm = gameManager.GetComponent<GameManager>();
        um = uiManager.GetComponent<UI>();
    }
    public void ChangeLevel()
    {
        if (levelInput != null)
        {
            if (levelInput.text == "1")
            {
                playerScrips.bulletLevel = 1;
            }
            else if (levelInput.text == "2")
            {
                playerScrips.bulletLevel = 2;
            }
            else if (levelInput.text == "3")
            {
                playerScrips.bulletLevel = 3;
            }
            else if (levelInput.text == "4")
            {
                playerScrips.bulletLevel = 4;
            }
            else if (levelInput.text == "5")
            {
                playerScrips.bulletLevel = 5;
            }
            else
            {
                BulletLevel.SetActive(false);
            }
            BulletLevel.SetActive(false);
        }
        gm.isPaused = false;
    }

    public void ChangePain()
    {
        int painInt = int.Parse(painInput.text);
        if (painInt <=300&&painInt >= 0)
        {
            um.CurPain = painInt;
        }
        else
        {
            BulletLevel.SetActive(false);
        }
        painChanger.SetActive(false);
        gm.isPaused = false;
    }

    public void ChangeHealth()
    {
        int health = int.Parse(healthInput.text);
        if (health <= 200 && health >= 0)
        {
            um.CurHp = health;
        }
        else
        {
            healthChanger.SetActive(false);
        }
        healthChanger.SetActive(false);
        gm.isPaused = false;
    }
}
