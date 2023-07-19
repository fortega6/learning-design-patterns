using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Patterns.Behaviour.Command
{
    public class CanvasFadeCommand : Command
    {
        private readonly CanvasGroup _canvasGroup;
        private readonly float _newAlpha;
        private readonly float _duration;

        public CanvasFadeCommand(CanvasGroup canvasGroup, float newAlpha, float duration)
        {
            _canvasGroup = canvasGroup;
            _newAlpha = newAlpha;
            _duration = duration;
        }

        public async Task Execute()
        {
            var initialAlpha = _canvasGroup.alpha;
            var alphaDifference = _newAlpha - initialAlpha;
            var alphaIncrement = alphaDifference / _duration;
            while (Math.Abs(_canvasGroup.alpha - _newAlpha) > 0.01f)
            {
                _canvasGroup.alpha += alphaIncrement * Time.deltaTime;
                await Task.Yield();
            }
        }
    }
}