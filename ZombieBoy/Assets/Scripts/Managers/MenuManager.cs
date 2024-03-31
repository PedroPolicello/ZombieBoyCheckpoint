using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject instructionScreen;
    
    private Touch touch;
    private bool isActive;
    private float elapsedTime;
    void Update()
    {
        ActionTouch();

        if (isActive)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    void ActionTouch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                startScreen.SetActive(false);
                instructionScreen.SetActive(true);
                isActive = true;

                if (touch.phase == TouchPhase.Stationary && elapsedTime >= 3)
                {
                    SceneManager.LoadScene("Scenes/Game");
                }
            }
        }
    }
}
