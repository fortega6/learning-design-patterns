using Common;
using Patterns.Decoupling.ServiceLocator;
using Ships.Common;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _text;

        public void Reset()
        {
            UpdateScore(0);
        }

        public void UpdateScore(int newScore)
        {
            _text.SetText(newScore.ToString());
        }
    }
}