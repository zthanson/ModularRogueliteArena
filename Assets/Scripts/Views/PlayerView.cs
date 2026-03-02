using UnityEngine;
using MRArena.Models;
using UnityEngine.U2D;

namespace MRArena.Views
{
    /// <summary>
    /// Applies model state to Unity components (Rigidbody2D, SpriteRenderer).
    /// Does NOT read input.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerView : MonoBehaviour
    {
        public PlayerModel Model { get; private set; }

        [SerializeField] private SpriteRenderer spriteRenderer;

        private Rigidbody2D rb;

        // Called by the composer (explicit wiring)
        public void Initialize(PlayerModel model)
        {
            Model = model;
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();

            // If not assigned in inspector, try to find one on the object
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            if (Model == null) return;

            rb.MovePosition(Model.Position);

            // Optional facing based on last movement direction
            if (spriteRenderer != null)
            {
                if (Model.MoveDirection.x < -0.01f) spriteRenderer.flipX = true;
                else if (Model.MoveDirection.x > 0.01f) spriteRenderer.flipX = false;
            }
        }
    }
}
