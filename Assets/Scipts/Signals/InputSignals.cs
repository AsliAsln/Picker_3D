using System;
using UnityEngine;

namespace Signals
{
    internal class InputSignals : MonoBehaviour
    {
        #region Singleton
        public static InputSignals Instance;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance);
                return;
            }
            Instance = this;
        }
        #endregion
    }
}