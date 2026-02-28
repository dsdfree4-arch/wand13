using UnityEngine;

namespace Ward13
{
    /// <summary>
    /// Unlocks a developer/admin panel when the correct code is entered.
    /// </summary>
    public class AdminPanelCodeUnlock : MonoBehaviour
    {
        [SerializeField] private GameObject adminPanel;
        [SerializeField] private string unlockCode = "admin1";
        [SerializeField] private bool caseSensitive = false;

        public void CheckCode(string input)
        {
            if (IsMatch(input))
            {
                if (adminPanel != null)
                {
                    adminPanel.SetActive(true);
                }

                Debug.Log("Admin panel unlocked.");
                return;
            }

            Debug.Log("Wrong code.");
        }

        private bool IsMatch(string input)
        {
            if (caseSensitive)
            {
                return input == unlockCode;
            }

            return string.Equals(input, unlockCode, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
