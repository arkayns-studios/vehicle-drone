using UnityEngine.InputSystem;
using UnityEngine;

namespace Arkayns.Projects.Vehicles.Drone {
    
    [RequireComponent(typeof(PlayerInput))]
    public class ADroneInput : MonoBehaviour {
        private Vector2 m_cyclic;
        private float m_pedal;
        private float m_throttle;

        public Vector2 Cyclic => m_cyclic;
        public float Pedal => m_pedal;
        public float Throttle => m_throttle;

        private void OnCyclic(InputValue value) {
            m_cyclic = value.Get<Vector2>();
        } // OnCyclic
        
        private void OnPedal(InputValue value) {
            m_pedal = value.Get<float>();
        } // OnPedal
        
        private void OnThrottle(InputValue value) {
            m_throttle = value.Get<float>();
        } // OnThrottle
        
    } // Class ADroneInput
    
} // Namespace Arkayns Projects Vehicles
