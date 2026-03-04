using UnityEngine;

namespace MRArena.Systems.Waves
{
    [CreateAssetMenu(menuName = "MRArena/Waves/Wave Config")]
    public class WaveConfigSO : ScriptableObject
    {
        [Min(1)] public int waveNumber = 1;
        [Min(0)] public int enemyCount = 5;
        [Min(0f)] public float spawnInterval = 1f;

        public GameObject enemyPrefab;
    }
}

