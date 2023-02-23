using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace BulletHell.Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthPlayerText;
        [SerializeField] private TMP_Text _scoreText;

        public static UIManager Instance = null;

        public static UnityAction<int> OnChangeHealthPlayer;
        public static UnityAction<int> OnChangeScore;

        private void OnEnable()
        {
            OnChangeHealthPlayer += ChangeHealthPlayer;
            OnChangeScore += ChangeScore;
        }

        private void OnDisable()
        {
            OnChangeHealthPlayer -= ChangeHealthPlayer;
            OnChangeScore -= ChangeScore;
        }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }

        public void ChangeHealthPlayer(int health)
        {
            _healthPlayerText.SetText("Player Health : " + health);
        }

        public void ChangeScore(int score)
        {
            _scoreText.SetText("Score : " + score);
        }
    }
}
