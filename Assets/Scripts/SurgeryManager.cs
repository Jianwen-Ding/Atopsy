using UnityEngine;

using System.Collections.Generic;

/**
 * Represents the overall state of the surgery and how the surgery has progressed.
 */
public class SurgeryManager : MonoBehaviour
{
    // Single instance of the surgery manager allowed
    private static SurgeryManager instance = null;

    // >>> Health bar fields <<<
    [SerializeField]
    private int triesLeft;

    [SerializeField]
    FailureManager failureManager;

    // >>> Success fields <<<
    [SerializeField]
    SuccessManager successManager;

    // >>> Findings fields <<<
    // Incisions open from the onset
    [SerializeField]
    public List<GameObject> baseIncisions;

    // A surgery's story is based on questions findings,
    // Answers discovered from observations and scans from surgery.
    [System.Serializable]
    public struct FindingEntry
    {
        public string entryName;
        public string entryDescription;
        public string correctOption;
        public List<GameObject> incisions;
        public bool hasBeenFound;
    }
    [SerializeField]
    public List<FindingEntry> findings;

    // Fetches an entry with the same key.
    // Returns null, if no entry with given key exists.
    private static FindingEntry? GetFindingEntry(string finding)
    {
        foreach (FindingEntry entry in instance.findings) {
            if (entry.entryName.Equals(finding))
            {
                return entry;
            }
        }
        return null;
    }

    // Checks if any entries have not been found yet.
    private static bool AllComplete()
    {
        foreach (FindingEntry entry in instance.findings) {
            if (!entry.hasBeenFound)
            {
                return false;
            }
        }
        return true;
    }

    public enum AnswerResult
    {
        CORRECT,
        FALSE,
        NO_CORRESPONDING_FINDING
    }

    // Transitions the scene outside of the surgery.
    private static void GameEnd()
    {
        instance.failureManager.GameEnd();
        Destroy(instance);
    }

    // Run when player finds out given mystery.
    public static AnswerResult GuessAnswer(string entry, string answer)
    {
        FindingEntry? correspondingEntry = GetFindingEntry(entry);
        if (correspondingEntry == null)
        {
            return AnswerResult.NO_CORRESPONDING_FINDING;
        }
        FindingEntry baseEntry = (FindingEntry)correspondingEntry;

        // Correct found
        if (baseEntry.correctOption.Equals(answer))
        {
            baseEntry.hasBeenFound = true;
            if (AllComplete())
            {
                instance.successManager.Success();
            }
            return AnswerResult.CORRECT;
        }
        
        // Reduces amount of tries on wrong guess
        instance.triesLeft--;
        if (instance.triesLeft <= 0)
        {
            GameEnd();
        } 
        return AnswerResult.FALSE;
    }

    // Ensures integrity of finding entries
    private void OnValidate()
    {
        var entrySet = new HashSet<string>();
        foreach (FindingEntry entry in findings)
        {
            // Ensures no duplicate entries
            if (entrySet.Contains(entry.entryName))
            {
                Debug.LogWarning("Duplicate finding entry found", this);
            }
            entrySet.Add(entry.entryName);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Ensures singleton works
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        // Turns off any incisions not yet found yet
        foreach (FindingEntry entry in findings)
        {
            foreach (GameObject incision in entry.incisions)
            {
                incision.SetActive(entry.hasBeenFound);
            }
        }
    }
}
