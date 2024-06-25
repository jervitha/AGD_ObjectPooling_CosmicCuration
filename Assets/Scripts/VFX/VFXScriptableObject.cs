using System;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    [CreateAssetMenu(fileName = "VFXScriptableObject", menuName = "ScriptableObjects/VFXScriptableObject")]
    public class VFXScriptableObject : ScriptableObject
    {
        public List<VFXData> vfxData;
    }

    
}