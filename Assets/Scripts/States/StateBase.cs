using UnityEngine;

namespace Golf
{
    public abstract class StateBase : MonoBehaviour
    {
        public abstract void Initialize(GameStateMechine gameStateMechine);

        public abstract void Enter();
        
        public abstract void Exit();
    }
}