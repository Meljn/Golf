using System;
using UnityEngine;

namespace Golf
{
    public class StoneComponent : MonoBehaviour
    {
        public event Action<StoneComponent> Hit;
        public event Action<StoneComponent> Missed;
        
         
        
        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.GetComponent<Stick>())
            {
                Hit?.Invoke(this);
            }

            else
            {
                Missed?.Invoke(this);
            }

        }
    }
}
