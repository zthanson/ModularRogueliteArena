using UnityEngine;
using TMPro;
using MRArena.Systems.Waves;

namespace MRArena.Views
{
    public class HUDView : MonoBehaviour
    {
        [SerializeField] private TMP_Text waveText;
        [SerializeField] private WaveManager waveManager;

        private void OnEnable()
        {
            if (waveManager != null)
                waveManager.OnWaveStarted += HandleWaveStarted;
        }

        private void OnDisable()
        {
            if (waveManager != null)
                waveManager.OnWaveStarted -= HandleWaveStarted;
        }

        private void HandleWaveStarted(int waveNumber)
        {
            if (waveText != null)
                waveText.text = $"Wave: {waveNumber}";
        }
    }
}