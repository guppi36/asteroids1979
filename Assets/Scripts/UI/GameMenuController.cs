using GameSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameMenuController : MonoBehaviour
    {
        [SerializeField] private Button _retryButton;
        [SerializeField] private GameObject _gameOverScreen;
        private void Start()
        {
            _retryButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            ScoreController.ResetScore();
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

        public void GameOverScreen()
        {
            _gameOverScreen.SetActive(true);
        }
    }
}
