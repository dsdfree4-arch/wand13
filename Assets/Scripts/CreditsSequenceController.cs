using System.Collections;
using TMPro;
using UnityEngine;

namespace Ward13
{
    /// <summary>
    /// Demo-ending sequence:
    /// 1) Thanks for playing
    /// 2) Ward13 Chapter 2 Soon
    /// 3) Final creator credit text
    /// </summary>
    public class CreditsSequenceController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject creditsPanel;
        [SerializeField] private TextMeshProUGUI creditsText;

        [Header("Timings (seconds)")]
        [SerializeField] private float initialMessageDuration = 6f;
        [SerializeField] private float chapterSoonDuration = 4f;

        [Header("Messages")]
        [TextArea]
        [SerializeField] private string initialMessage =
            "WARD13\n\nThanks For Playing\nDemo Version";

        [TextArea]
        [SerializeField] private string chapterSoonMessage =
            "WARD13\n\nCHAPTER 2\nSOON";

        [TextArea]
        [SerializeField] private string finalMessage =
            "Thanks for playing the demo\nMade by JOE BIDEN / Jovanni";

        private Coroutine _sequenceRoutine;

        public void BeginSequence()
        {
            if (_sequenceRoutine != null)
            {
                StopCoroutine(_sequenceRoutine);
            }

            if (creditsPanel != null)
            {
                creditsPanel.SetActive(true);
            }

            _sequenceRoutine = StartCoroutine(PlaySequence());
        }

        private IEnumerator PlaySequence()
        {
            SetText(initialMessage);
            yield return new WaitForSecondsRealtime(initialMessageDuration);

            SetText(chapterSoonMessage);
            yield return new WaitForSecondsRealtime(chapterSoonDuration);

            SetText(finalMessage);
            _sequenceRoutine = null;
        }

        private void SetText(string value)
        {
            if (creditsText != null)
            {
                creditsText.text = value;
            }
        }
    }
}
