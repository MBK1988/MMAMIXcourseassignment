using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public float currentHealth;
    public TextMesh healthUI;

    void Start()
    {
        currentHealth = startingHealth;
        healthUI.text = currentHealth + " Health";
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        healthUI.text = "Health: " + currentHealth;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        StartCoroutine(GameOver(7f));
    }

    public static IEnumerator GameOver(float delayBeforeReload)
    {
        Time.timeScale = 0;
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + delayBeforeReload)
        {
            yield return null;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

}
