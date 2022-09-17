using TMPro;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class PlayerUIView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI lifeText;
        [SerializeField]
        private TextMeshProUGUI scoreText;

        public void SyncLife (int life)
        {
            lifeText.text = $"x {life}";
        }

        public void SyncScore (int score) => scoreText.text = score.ToString();
    }
}