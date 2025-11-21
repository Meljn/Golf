using UnityEngine;
using System;

namespace Golf
{
    public class ScoreManager:MonoBehaviour
    {
        public event Action<int> ScoreChanged;
        public event Action<int> RecordChanged;

        private int m_score;

        public int record
        {
            get => PlayerPrefs.GetInt(GlobalConstants.Record, 0);
            private set
            {
                var temp = PlayerPrefs.GetInt(GlobalConstants.Record, 0);
                if (temp < value)
                {
                    PlayerPrefs.SetInt(GlobalConstants.Record, value);
                    RecordChanged?.Invoke(value);
                }
            }
        }
        public int score
        {
            get => m_score;
            private set
            {
                m_score = value;
                Debug.Log($"Score: {value}");
                ScoreChanged?.Invoke(value);
            }
        }
        
        public void Increase()
        {
            score++;
        }

        public void Reset()
        {
            score = 0;
        }

        public void UpdateRecord()
        {
            var record = PlayerPrefs.GetInt(GlobalConstants.Record, 0);
            if (record < score)
            {
                PlayerPrefs.SetInt(GlobalConstants.Record, score);
            }
        }
    }
}