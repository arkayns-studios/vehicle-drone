using UnityEngine;

namespace Arkayns.Projects.Vehicles.Drone {
    
    public interface IEngine {
        
        void InitEngine();
        void UpdateEngine(Rigidbody rb, ADroneInput input, sbyte engines);
        
    } // Interface IEngine
    
} // Namespace Arkayns Projects Vehicles
