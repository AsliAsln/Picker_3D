using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class OnLevelDestroyerCommand
    {
        private Transform _levelHolder;

        public OnLevelDestroyerCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public void Execute()
        {
            if (_levelHolder.childCount <= 0) return;

            Object.Destroy(_levelHolder.GetChild(0).gameObject);
        }
    }
}