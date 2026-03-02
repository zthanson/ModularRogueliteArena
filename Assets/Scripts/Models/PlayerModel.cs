using UnityEngine;

namespace MRArena.Models
{
    /// <summary>
    ///  Runtime state only.
    /// </summary>
    public class PlayerModel
    {
        public Vector2 Position;
        public Vector2 MoveInput; // raw input vector
        public Vector2 MoveDirection; // last non-zero direction (for facing/aim)
        public float MoveSpeed;

        public int MaxHealth;
        public int CurrentHealth;

        public PlayerModel(Vector2 startPosition, float moveSpeed, int maxHealth) 
        {
            Position = startPosition;
            MoveSpeed = moveSpeed;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            MoveInput = Vector2.zero;
            MoveDirection = Vector2.right;
        }
    }
}

