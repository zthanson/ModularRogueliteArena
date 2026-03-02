using UnityEngine;
using MRArena.Models;
using MRArena.Controllers;
using MRArena.Views;

namespace MRArena.Core
{
    /// <summary>
    /// Creates the model and injects it into controller + view.
    /// This prevents "who creates the model?" confusion.
    /// </summary>
    
    [DisallowMultipleComponent]
    public sealed class PlayerComposer : MonoBehaviour
    {
        [Header("Tuning")]
        [SerializeField] private float moveSpeed = 6f;
        [SerializeField] private int maxHealth = 100;

        private PlayerModel model;

        private void Awake()
        {
            // Pull required components
            var controller = GetComponent<PlayerController>();
            var view = GetComponent<PlayerView>();

            if (controller == null || view == null)
            {
                Debug.LogError("PlayerComposer requires PlayerController and PlayerView on the same GameObject.");
                enabled = false;
                return;
            }

            // Create model using current position as spawn point
            model = new PlayerModel(startPosition: transform.position, moveSpeed: moveSpeed, maxHealth: maxHealth);

            // Inject into controller + view
            controller.Initialize(model);
            view.Initialize(model);

            // If Rigidbody exists, sync model position exactly to physics position
            var rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                model.Position = rb.position;
        }
    }
}