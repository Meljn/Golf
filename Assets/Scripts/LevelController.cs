using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public event Action Finished;

        [SerializeField] private int m_missedCount;
        [SerializeField] [Min(0.1f)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private ScoreManager m_scoreManager;
      
        private float m_time;
        private List<StoneComponent> m_stones;
        private int m_currentMissedCount;

        private void Awake()
        {
            m_currentMissedCount = m_missedCount;
            m_stones = new List<StoneComponent>();
        }
        

        private void Update()
        {
            m_time += Time.deltaTime;
            
            if (m_time >= m_spawnRate)
            {
                StoneComponent stoneComponent = m_stoneSpawner.Spawn();
                m_stones.Add(stoneComponent);

                stoneComponent.Hit += OnHitStone;
                stoneComponent.Missed += OnMissed;
                
                m_time = 0;
            }
                
        }

        private void OnHitStone(StoneComponent stoneComponent)
        {
            Unsubscribe(stoneComponent);
            m_scoreManager.Increase();
        }
        
        private void OnMissed(StoneComponent stoneComponent)
        {
            Unsubscribe(stoneComponent);

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("Game Over");
                Finished?.Invoke();

                foreach (var item in m_stones)
                {
                    Destroy(item.gameObject);
                }
                m_stones.Clear();
                m_currentMissedCount = m_missedCount;
            }
            
            
        }

        private void Unsubscribe(StoneComponent stoneComponent)
        {
            stoneComponent.Hit -= OnHitStone;
            stoneComponent.Missed -= OnMissed;
        }
    }
}