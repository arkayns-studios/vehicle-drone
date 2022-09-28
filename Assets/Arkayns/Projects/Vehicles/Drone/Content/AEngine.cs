using UnityEngine;

namespace Arkayns.Projects.Vehicles.Drone {
    
    [RequireComponent(typeof(BoxCollider))]
    public class AEngine : MonoBehaviour, IEngine {

        [Header("Engine Properties")]
        [SerializeField] private float m_maxPower = 4f;
        
        public void InitEngine() {
            
        } // InitEngine

        public void UpdateEngine(Rigidbody rb, ADroneInput input, sbyte engines) {
            // Debug.Log($"Running Engine: [{this.gameObject.name}]");
            
            Vector3 engineForce = Vector3.zero;
            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (input.Throttle * m_maxPower)) / engines;
            rb.AddForce(engineForce, ForceMode.Force);
        } // UpdateEngine
        
    } // Class AEngine
    
} // Namespace Arkayns Projects Vehicles