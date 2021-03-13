using System.Collections.Generic;
using GameSystems;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBarHolder : MonoBehaviour
    {
        [SerializeField] private List<Image> _healthBar = new List<Image>();
        [SerializeField] private Text scoreText;
        
        public void ChangeHealthPointsBar(int health)
        {
            if (health >= 3) return;
            foreach (var image in _healthBar)
            {
                image.gameObject.SetActive(false);
            }
            
            for (int i = 0; i < health; i++)
            {
                _healthBar[i].gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            ScoreView();
        }

        private void ScoreView()
        {
            string score = "";
            int scoreInt = ScoreController.Score;
            if (scoreInt < 10) score = "00";
            else if (scoreInt < 100) score = "0";

            scoreText.text = score + scoreInt;
        }
    }
}
