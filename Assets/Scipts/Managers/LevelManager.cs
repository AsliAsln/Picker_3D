using System;
using UnityEngine;
using Commands;
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Member Variables

        #region Private Variables

        private OnLevelLoaderCommand _levelLoaderCommand;
        private OnLevelDestroyerCommand _levelDestroyerCommand;
        private byte _currentLevel;
        private LevelData _levelData;

        #endregion

        #region Serialized Variables

        [SerializeField]
        private Transform levelHolder;

        [SerializeField]
        private byte totalLevelCount;

        #endregion

        #endregion

        private void Awake()
        {
            _levelData = GetLevelData();
            _currentLevel = GetActiveLevel();
            Init();
        }
        private void Start()
        {
            CoreGameSignals.Instance.onInitializeLevel?.Invoke((byte) (_currentLevel % totalLevelCount));
        }
        private void OnEnable()
        {
            SubscribeEvents();
        }
        private void OnDisable()
        {
            UnSubscribeEvents();
        }
        private void Init()
        {
            _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
            _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder);
        }
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onInitializeLevel += _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.onClearActiveLevel += _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.onGetLevelValue += OnGetLevelValue;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
        }
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onInitializeLevel -= _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.onClearActiveLevel -= _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.onGetLevelValue -= OnGetLevelValue;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
        }
        private void OnNextLevel()
        {
            _currentLevel++;
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onInitializeLevel?.Invoke((byte)(_currentLevel % totalLevelCount));
        }
        private void OnRestartLevel()
        {
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onInitializeLevel?.Invoke((byte)(_currentLevel % totalLevelCount));
        }
        
        private byte OnGetLevelValue()
        {
            return (byte)_currentLevel;
        }
        private byte GetActiveLevel()
        {
            throw new NotImplementedException();
        }

        private LevelData GetLevelData()
        {
            return Resources.Load<CD_Level>("Data/CD_Level").Levels[_currentLevel];
        }
        
    }
}