using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    private float spawnRate=3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    private int score;

    public bool isActive;
    public Button restartButton;
    public GameObject TitleScreen;
    void Start()
    {

        
    }

    public void StartGame(int diff)
    {
        spawnRate /= diff;
        isActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        TitleScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
