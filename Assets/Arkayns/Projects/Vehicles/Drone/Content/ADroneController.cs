using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkayns.Projects.Vehicles.Drone {
    
    [RequireComponent(typeof(ADroneInput))]
    public class ADroneController : ABaseRigidbody {

        [Header("Control Properties")] 
        [SerializeField] private float m_minMaxPitch = 30f;
        [SerializeField] private float m_minMaxRoll = 30f;
        [SerializeField] private float m_yawPower = 4f;
        [SerializeField] private float m_lerpSpeed = 2f;

        private ADroneInput m_input;
        private List<IEngine> m_engines = new List<IEngine>();

        private float m_finalPitch;
        private float m_finalRoll;
        private float m_finalYaw;
        private float m_yaw;
        
        public void Start() {
            m_input = GetComponent<ADroneInput>();
            m_engines = GetComponentsInChildren<IEngine>().ToList();
        } // Start

        protected override void HandlePhysics() {
            HandleEngine();
            HandleControl();
        } // HandlePhysics

        protected virtual void HandleEngine() {
            foreach (var engine in m_engines) engine.UpdateEngine(m_rb, m_input, (sbyte)m_engines.Count);
        } // HandleEngine
        
        protected virtual void HandleControl() {
            var time = Time.deltaTime * m_lerpSpeed;
            var pitch = m_input.Cyclic.y * m_minMaxPitch;
            var roll = m_input.Cyclic.x * m_minMaxRoll;
            m_yaw += m_input.Pedal * m_yawPower;
            
            m_finalPitch = Mathf.Lerp(m_finalPitch, pitch, time);
            m_finalRoll = Mathf.Lerp(m_finalRoll, roll, time);
            m_finalYaw = Mathf.Lerp(m_finalYaw, m_yaw, time);
            
            var rot = Quaternion.Euler(m_finalPitch, m_finalYaw, m_finalRoll);
            m_rb.MoveRotation(rot);
        } // HandleControl
        
    } // Class ADroneController
    
} // Namespace Arkayns Projects Vehicles