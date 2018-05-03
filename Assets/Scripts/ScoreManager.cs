using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int score;

    public TextMesh text;


    void Start()
    {
        score = 0;
    }


    void Update()
    {
        text.text = "Score: " + score;
    }
}
