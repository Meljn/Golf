using System;
using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] private float m_minAngelZ = -30;
        [SerializeField] private float m_maxAngelZ = 30;
        [SerializeField] [Min(0)] private float m_speed;
        
        private void Update()
        {
            
            var angels = transform.localEulerAngles;
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                angels.z = Rotate(angels.z, m_minAngelZ);
            }
            else
            {
                angels.z = Rotate(angels.z, m_maxAngelZ);
            }
            
            transform.localEulerAngles = angels;
        }

        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, Time.deltaTime * m_speed);
        }
    }
}
