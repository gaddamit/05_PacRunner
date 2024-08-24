using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

// Handle the pause menu functionality
public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private HighscoreRanking highscoreRanking;
    private Vector3 _initialPosition;
    [SerializeField]
    private GameObject _pauseMenu; 
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _highscoreText;
    private void Awake()
    {
        _initialPosition = gameObject.GetComponent<RectTransform>().localPosition;
    }
    private void Start()
    {
        
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        ShowPauseMenu();
        Time.timeScale = 0; 
    }

    public void Home()
    {
        GameManager.Instance.ResetScore();

        HidePauseMenu();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        HidePauseMenu();

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        GameManager.Instance.ResetScore();

        HidePauseMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    private void ShowPauseMenu()
    {
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }

    private void HidePauseMenu()
    {
        gameObject.GetComponent<RectTransform>().localPosition = _initialPosition;
    }

    public void UpdateHighscores(int score)
    {
        highscoreRanking.AddScore(score);
        _scoreText.text = "";
        _highscoreText.text = "";
        Debug.Log(highscoreRanking.index);
        for(int i = 0; i < highscoreRanking.highscores.Count; i++)
        {
            _scoreText.text += $"{highscoreRanking.highscores[i]}\n";
            if(i == highscoreRanking.index)
            {
                _highscoreText.text += $"{score}\n";
            }
            else
            {
                _highscoreText.text += "\n";
            }
        }
    }
}
