using System;

namespace LeandroExhumed.SpaceChaos.Input
{
    public class PlayerInput : IInput
    {
        public event Action OnShotPerformed;
        public event Action OnPausePerformed;

        public float Steer => actions.Gameplay.Steer.ReadValue<float>();
        public float Thrust => actions.Gameplay.Thrust.ReadValue<float>();

        private readonly PlayerActions actions;

        public PlayerInput (PlayerActions actions)
        {
            this.actions = actions;

            actions.Gameplay.Shot.performed += (ctx) => OnShotPerformed?.Invoke();
            actions.Gameplay.Pause.performed += (ctx) => OnPausePerformed?.Invoke();
        }

        public void SetActive (bool value)
        {
            if (value)
            {
                actions.Enable();
            }
            else
            {
                actions.Disable();
            }
        }
    }
}