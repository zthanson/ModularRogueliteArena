using UnityEngine;
using MRArena.Models;

namespace MRArena.Controllers
{
    /// <summary>
    /// Reads input + updates the model. Does NOT touch Rigidbody2D.
    /// </summary>
    public sealed class PlayerController : MonoBehaviour
    {
        public PlayerModel Model { get; private set; }

        [SerializeField] private MRArena.Systems.ArenaBounds arenaBounds;

        // Called by the composer (explicit wiring)
        public void Initialize(PlayerModel model)
        {
            Model = model; 
        }

        private void Update()
        {
            if (Model == null) return;

            // Old Input system (simple, works out of the box)
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            var input = new Vector2(x, y);
            Model.MoveInput = input;

            if (input.sqrMagnitude > 0.0001f)
                Model.MoveDirection = input.normalized;
        }

        private void FixedUpdate()
        {
            if (Model == null) return;

            Vector2 dir = Model.MoveInput.normalized;
            Vector2 delta = dir * Model.MoveSpeed * Time.fixedDeltaTime;

            Model.Position += delta;

            if (arenaBounds != null)
            {
                Model.Position = arenaBounds.Clamp(Model.Position);
            }
        }
    }

}

