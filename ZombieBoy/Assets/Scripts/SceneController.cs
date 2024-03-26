using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject instructionScreen;
    [SerializeField] private GameObject startScreen;

    private float elapsedTime;


    void FixedUpdate()
    {
        if (/*clicou na tela*/ elapsedTime >10)
        {
            startScreen.SetActive(true);
            instructionScreen.SetActive(true);
            elapsedTime += Time.deltaTime;
        }

        else if (instructionScreen == true && elapsedTime >= 5 /*|| clicou na tela*/)
        {
            instructionScreen.SetActive(false);
            SceneManager.LoadScene("Game");
        }
    }
}
