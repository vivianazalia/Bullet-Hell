using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using BulletHell.ObjectPool;

namespace BulletHell.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;

        public static UnityAction<int> OnAddScore;
        public static UnityAction<bool> OnGameOver;
        public static UnityAction OnRetryGame;

        private int _score;

        public bool GameOver { get; private set; }

        private void OnEnable()
        {
            OnAddScore += AddScore;
            OnGameOver += SetGameOver;
            OnRetryGame += RetryGame;
        }

        private void OnDisable()
        {
            OnAddScore -= AddScore;
            OnGameOver -= SetGameOver;
            OnRetryGame -= RetryGame;
        }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            GameOver = false;
        }

        public void AddScore(int score)
        {
            _score += score;
            UIManager.OnChangeScore?.Invoke(_score);
        }

        public void SetGameOver(bool isGameOver)
        {
            GameOver = isGameOver;
            UIManager.OnGameOver?.Invoke(GameOver);
        }

        public void RetryGame()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
