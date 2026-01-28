using UnityEngine;

public class VoteManager : MonoBehaviour
{
    public static VoteManager Instance;

    [Header("Vote Settings")]
    [SerializeField] private int minStep = -5;
    [SerializeField] private int maxStep = 5;

    [Header("Save Settings")]
    [SerializeField] private string voteKeyPrefix = "Vote";

    [Header("Debug")]
    [SerializeField] private int[] allVotes;

    public int CurrentVotes { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitArray();
        LoadVotes();
    }

    private void InitArray()
    {
        int size = maxStep - minStep + 1;
        if (size <= 0)
        {
            size = 1;
        }

        allVotes = new int[size];
    }

    public void AddVote(int step)
    {
        int clampedStep = Mathf.Clamp(step, minStep, maxStep);
        int index = StepToIndex(clampedStep);

        allVotes[index]++;
        CurrentVotes = allVotes[index];

        SaveVotes();

       
    }

    public void SetGraphStep(int step)
    {
        int clampedStep = Mathf.Clamp(step, minStep, maxStep);
        int index = StepToIndex(clampedStep);

        CurrentVotes = allVotes[index];
    }

 
    public int[] GetAllVotes()
    {
        return allVotes;
    }

    private int StepToIndex(int step)
    {
        return step - minStep;
    }

    private void SaveVotes()
    {
        for (int i = 0; i < allVotes.Length; i++)
        {
            string key = $"{voteKeyPrefix}{i}";
            PlayerPrefs.SetInt(key, allVotes[i]);
        }

        PlayerPrefs.Save();
    }

    private void LoadVotes()
    {
        for (int i = 0; i < allVotes.Length; i++)
        {
            string key = $"{voteKeyPrefix}{i}";
            allVotes[i] = PlayerPrefs.GetInt(key, 0);
        }
    }
}