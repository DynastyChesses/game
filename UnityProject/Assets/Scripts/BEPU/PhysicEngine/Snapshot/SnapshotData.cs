using System;
using System.Collections.Generic;
using BEPUphysics.EntityStateManagement;
using BEPUutilities;

namespace Simulation
{
    [Serializable]
    public struct SnapshotData
    {
        public long InstanceId;
        public MotionState MotionState;
        public Vector3 LinearMomentum;
        public Vector3 AngularMomentum;
    }
}