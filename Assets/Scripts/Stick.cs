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

        private Vector3 m_direction;
        private Vector3 m_lastPointPosition;
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
            
            m_lastPointPosition = transform.position;
            m_direction = (m_point.position - m_lastPointPosition).normalized;
            transform.localEulerAngles = angels;
        }

        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, Time.deltaTime * m_speed);
        }
        
        private void OnCollisionEnter(Collision collision)
        {

            
            var direction = (m_point.position - m_lastPointPosition).normalized;
            if (collision.gameObject.TryGetComponent<StoneComponent>(out var stoneComponent))
            {
                stoneComponent.GetComponent<Rigidbody>().AddForce(m_power * direction, ForceMode.Impulse);
            }
            

        }
    }
}
