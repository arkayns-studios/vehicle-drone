using UnityEngine;

namespace Arkayns.Projects.Vehicles.Drone {
    
    [RequireComponent(typeof(Rigidbody))]
    public class ABaseRigidbody : MonoBehaviour {

        [Header("Rigidbody Properties")] 
        [SerializeField] private float m_weight = 1f;
        public bool isWeightPounds;
        private const float LbsToKg = 0.454f;
        
        protected Rigidbody m_rb;
        protected float StartDrag;
        protected float StartAngularDrag;
        
        private void Awake() {
            m_rb = GetComponent<Rigidbody>();
            if (!m_rb) return;
            if (isWeightPounds) m_rb.mass = m_weight * LbsToKg;
            StartDrag = m_rb.drag;
            StartAngularDrag = m_rb.angularDrag;
        } // Awake

        private void FixedUpdate() {
            if (!m_rb) return;
            HandlePhysics();
        } // FixedUpdate

        protected virtual void HandlePhysics() { } // HandlePhysics
        
    } // Class ABaseRigidbody
    
} // Namespace Arkayns Projects Vehicles