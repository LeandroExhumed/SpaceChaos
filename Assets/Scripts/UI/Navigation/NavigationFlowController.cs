using LeandroExhumed.SpaceChaos.Input;
using LeandroExhumed.SpaceChaos.Services.Audio;
using System;

namespace LeandroExhumed.UI.Navigation
{
    public class NavigationFlowController : IDisposable
    {
        protected readonly INavigationFlowModel model;

        protected readonly IInput input;

        private readonly AudioProvider audioProvider;

        public NavigationFlowController (INavigationFlowModel model, IInput input, AudioProvider audioProvider)
        {
            this.model = model;
            this.input = input;
            this.audioProvider = audioProvider;
        }

        public void Setup ()
        {
            model.OnNavigation += HandleNavigation;
            input.OnPausePerformed += HandleCursorUnlockInputStarted;
        }

        private void HandleNavigation ()
        {
            audioProvider.PlayOneShot(SoundType.Navigation);
        }

        private void HandleCursorUnlockInputStarted ()
        {
            model.RequestBack();
        }

        public void Dispose ()
        {
            model.OnNavigation -= HandleNavigation;
            input.OnPausePerformed -= HandleCursorUnlockInputStarted;
        }
    }
}