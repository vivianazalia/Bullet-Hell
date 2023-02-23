using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BulletHell.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;

        public static UnityAction<int> OnAddScore;
        public static UnityAction<bool> OnGameOver;

        private int _score;

        public bool GameOver { get; private set; }

        private void OnEnable()
        {
            OnAddScore += AddScore;
            OnGameOver += SetGameOver;
        }

        private void OnDisable()
        {
            OnAddScore -= AddScore;
            OnGameOver -= SetGameOver;
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
        }
    }
}
