using System;
using UnityEngine;

namespace Golf
{
    public class StoneComponent : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.CompareTag("club"))
            {
                print("stone was collide with CLUB");
            }

            else
            {
                print("stone was collide with GROUND");
            }

        }
    }
}
