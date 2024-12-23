using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class OnLevelLoaderCommand
    {
        private Transform _levelHolder;

        public OnLevelLoaderCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public void Execute(byte levelIndex)
        {
            Object.Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefabs/level{levelIndex}"), _levelHolder);
        }
    }
}