using System;
using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float m_power = 250f;
        [SerializeField] private Transform m_point;
        [SerializeField] private float m_minAngelZ = -30;
        [SerializeField] private float m_maxAngelZ = 30;
        [SerializeField] [Min(0)] private float m_speed;

        private bool m_isDown;
        private Vector3 m_direction;
        private Vector3 m_lastPointPosition;
        private void FixedUpdate()
        {
            var angels = transform.localEulerAngles;
            
            if (m_isDown)
            {
                angels.z = Rotate(angels.z, m_minAngelZ);
            }
            else
            {
                angels.z = Rotate(angels.z, m_maxAngelZ);
            }
            
            m_lastPointPosition = transform.position;
            m_direction = (m_point.position - m_lastPointPosition).normalized;
            transform.localEulerAngles = angels;
        }

        public void Down() => m_isDown = true;
        public void Up() => m_isDown = false;
        
        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, Time.deltaTime * m_speed);
        }
        
        private void OnCollisionEnter(Collision collision)
        {

            
            var direction = (m_point.position - m_lastPointPosition).normalized;
            if (collision.gameObject.TryGetComponent<StoneComponent>(out var stoneComponent))
            {
                stoneComponent.AddForce(m_power * direction);
            }
            

        }
    }
}
