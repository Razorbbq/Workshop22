using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class IntroText : MonoBehaviour
{
    [SerializeField] float changeTimer;
    float timer;
    [SerializeField] string[] textPrompts;
    int index = 0;
    TextMeshProUGUI text;
    private bool survive;
    [SerializeField] GameObject winSound;
    [SerializeField] GameObject menuButton;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);

        if (index >= textPrompts.Length) return;

        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = changeTimer;
            text.text = textPrompts[index];
            index++;

            if(survive && index == textPrompts.Length)
            {
                Win();

                DestroyEnemies();
            }
        }
    }

    public void Win()
    {
        index = textPrompts.Length + 1;

        text.text = "You won!";

        Instantiate(winSound, transform.position, Quaternion.identity);

        menuButton.SetActive(true);
    }

    public void NewTextPrompts(string[] prompts, bool survive)
    {
        textPrompts = prompts;
        index = 0;

        timer = changeTimer;
        text.text = textPrompts[index];
        index++;

        if (survive) changeTimer = 1;
        this.survive = survive;
    }

    public void GameOver()
    {
        DestroyEnemies();

        index = textPrompts.Length + 1;

        text.text = "Game Over!";
    }

    private void DestroyEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject e in enemies)
        {
            Destroy(e);
        }
    }
    public void MenuButton()
    {
        FindObjectOfType<SoundManager>().Play("Click");
        SceneManager.LoadScene(0);
    }
}
