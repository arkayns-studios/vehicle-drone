using UnityEngine;

namespace Arkayns.Projects.Vehicles.Drone {
    
    [RequireComponent(typeof(BoxCollider))]
    public class AEngine : MonoBehaviour, IEngine {

        [Header("Engine Properties")]
        [SerializeField] private float m_maxPower = 4f;
        
        public void InitEngine() {
            
        } // InitEngine

        public void UpdateEngine(Rigidbody rb, ADroneInput input, sbyte engines) {
            var upVector = transform.up;
            upVector.x = 0f;
            upVector.z = 0f;

            var diff = 1 - upVector.magnitude;
            var finalDiff = Physics.gravity.magnitude * diff;
            
            var engineForce = Vector3.zero;
            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude + finalDiff) + (input.Throttle * m_maxPower)) / engines;
            rb.AddForce(engineForce, ForceMode.Force);
        } // UpdateEngine
        
    } // Class AEngine
    
} // Namespace Arkayns Projects Vehicles