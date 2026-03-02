using UnityEngine;

namespace MRArena.Systems
{
    /// <summary>
    /// Defines rectangular arena limits.
    /// </summary>
    public class ArenaBounds : MonoBehaviour
    {
        [SerializeField] private Vector2 minBounds = new Vector2(-8f, -4f);
        [SerializeField] private Vector2 maxBounds = new Vector2(8f, 4f);

        public Vector2 Clamp(Vector2 position)
        {
            float clampedX = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);
            return new Vector2(clampedX, clampedY);
        }
    }
}

