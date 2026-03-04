using System;
using System.Collections.Generic;
using UnityEngine;

// Wave Manager: Manages enemy spawning and waves

namespace MRArena.Systems.Waves
{
    public sealed class WaveManager : MonoBehaviour
    {
        [Header("Wave Configs")]
        [SerializeField] private List<WaveConfigSO> waves = new();

        [Header("Debug Controls")]
        [SerializeField] private bool autoStartWaveOnPlay = true;

        public event Action<int> OnWaveStarted;
        public event Action<int> OnWaveEnded;

        public int CurrentWaveIndex { get; private set; } = -1;
        public bool IsWaveRunning { get; private set; }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            if (autoStartWaveOnPlay)
                StartNextWave();
        }

        // Update is called once per frame
        private void Update()
        {
            // Debug: press N to end current wave and start next 
            if (KeyboardNPressed())
            {
                if (IsWaveRunning)
                    EndCurrentWave();

                StartNextWave();
            }
        }

        public void StartNextWave()
        {
            if (waves == null || waves.Count == 0)
            {
                Debug.LogWarning("WaveManager: No wave configs assigned.");
                return;
            }

            CurrentWaveIndex++;

            if (CurrentWaveIndex >= waves.Count)
            {
                Debug.Log("Wave: All Waves Completed.");
                IsWaveRunning = false;
                return;
            }

            var wave = waves[CurrentWaveIndex];
            IsWaveRunning = true;

            Debug.Log($"Wave {wave.waveNumber} started (EnemyCount={wave.enemyCount}, Interval={wave.spawnInterval})");
            OnWaveStarted?.Invoke(wave.waveNumber);
        }

        public void EndCurrentWave()
        {
            if (!IsWaveRunning) return;

            var waveNumber = waves[CurrentWaveIndex].waveNumber;
            IsWaveRunning = false;

            Debug.Log($"Wave {waveNumber} ended");
            OnWaveEnded?.Invoke(waveNumber);
        }

        private static bool KeyboardNPressed()
        {
            // Using the new Input System without needing InputActions yet.
            var kb = UnityEngine.InputSystem.Keyboard.current;
            return kb != null && kb.nKey.wasPressedThisFrame;
        }
    }
}

