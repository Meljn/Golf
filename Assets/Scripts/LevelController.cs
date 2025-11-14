using System;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private int m_missedCount;
        [SerializeField] [Min(0)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stoneSpawner;

        private float m_time;
        private int m_currentMissedCount;

        private void Awake()
        {
            m_currentMissedCount = m_missedCount;
        }
        
        private void Start()
        {
            m_time = m_spawnRate;
        }

        private void Update()
        {
            m_time += Time.deltaTime;
            
            if (m_time >= m_spawnRate)
            {
                StoneComponent stoneComponent = m_stoneSpawner.Spawn();

                stoneComponent.Hit += OnHitStone;
                stoneComponent.Missed += OnMissed;
                
                m_time = 0;
            }
                
        }

        private void OnHitStone(StoneComponent stoneComponent)
        {
            stoneComponent.Hit -= OnHitStone;
            stoneComponent.Missed -= OnMissed;
            
            Debug.Log("Score");
        }
        
        private void OnMissed(StoneComponent stoneComponent)
        {
            stoneComponent.Hit -= OnHitStone;
            stoneComponent.Missed -= OnMissed;
            
            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("Game Over");
            }
            
            
        }
    }
}