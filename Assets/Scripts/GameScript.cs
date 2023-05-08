using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameScript : MonoBehaviour
{
    int number;
    int tries;
    [SerializeField] GameObject Main;
    [SerializeField] GameObject Game;
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text inputField;


    private void Awake()
    {
        Main.SetActive(true);
        Game.SetActive(false);
    }

    public void StartEasy()
    {
        number = Random.Range(1, 10);
        tries = 3;
        Play();
    }

    public void StartNormal()
    {
        number = Random.Range(1, 100);
        tries = 5;
        Play();
    }

    public void StartHard()
    {
        number = Random.Range(-100, 100);
        tries = 5;
        Play();
    }

    void Play()
    {
        text.text = tries + " tries left";
        Main.SetActive(false);
        Game.SetActive(true);
    }

    public void Guess()
    {
        var value = inputField.text;
        value = value.Substring(0, value.Length - 1);
        if (int.TryParse(value, out int temp))
        {
            tries--;
            if (tries >= 0)
            {

                if (number == temp)
                {
                    text.text = "Congratulations you found it!";
                    StartCoroutine(restart());
                }
                else if (number > temp)
                {
                    text.text = tries + " Tries Left \nGuess is too Low ";
                }
                else if (number != temp && tries == 0)
                {
                    text.text = " You have lost ";
                    StartCoroutine(restart());
                }
                else
                {
                    text.text = tries + " Tries Left \nGuess is too High ";
                }
            }


        }
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
