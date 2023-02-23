using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace BulletHell.Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthPlayerText;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _gameoverText;
        [SerializeField] private Button _retryButton;

        public static UIManager Instance = null;

        public static UnityAction<int> OnChangeHealthPlayer;
        public static UnityAction<int> OnChangeScore;
        public static UnityAction<bool> OnGameOver;

        private void OnEnable()
        {
            OnChangeHealthPlayer += ChangeHealthPlayer;
            OnChangeScore += ChangeScore;
            OnGameOver += ShowPanelGameOver;
        }

        private void OnDisable()
        {
            OnChangeHealthPlayer -= ChangeHealthPlayer;
            OnChangeScore -= ChangeScore;
            OnGameOver -= ShowPanelGameOver;
        }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            SetButtonListeners();
        }

        public void ChangeHealthPlayer(int health)
        {
            _healthPlayerText.SetText("Player Health : " + health);
        }

        public void ChangeScore(int score)
        {
            _scoreText.SetText("Score : " + score);
        }

        public void ShowPanelGameOver(bool active)
        {
            _gameoverText.gameObject.SetActive(active);
            _retryButton.gameObject.SetActive(true);
        }

        private void SetButtonListeners()
        {
            _retryButton.onClick.RemoveAllListeners();
            _retryButton.onClick.AddListener(delegate { GameManager.OnRetryGame?.Invoke(); });
        }
    }
}
