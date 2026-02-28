using UnityEngine;

namespace Ward13
{
    /// <summary>
    /// Activates the credits flow when the player reaches the end trigger.
    /// </summary>
    public class LevelCompleteTrigger : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";
        [SerializeField] private CreditsSequenceController creditsSequence;
        [SerializeField] private bool freezeTimeOnComplete = true;

        private bool _completed;

        private void OnTriggerEnter(Collider other)
        {
            if (_completed || !other.CompareTag(playerTag) || creditsSequence == null)
            {
                return;
            }

            _completed = true;

            if (freezeTimeOnComplete)
            {
                Time.timeScale = 0f;
            }

            creditsSequence.BeginSequence();
        }

        private void OnDisable()
        {
            // Safety reset in case this object gets disabled while paused.
            if (freezeTimeOnComplete && Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
            }
        }
    }
}
