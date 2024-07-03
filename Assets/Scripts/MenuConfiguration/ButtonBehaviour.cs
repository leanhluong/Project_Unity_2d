using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuConfiguration
{
    public abstract class ButtonBehaviour : MonoBehaviour
    {
        public abstract void Selected();
        public abstract void Deselected();
        public abstract void HighLight();
        public abstract void UnHighLight();
    }
}