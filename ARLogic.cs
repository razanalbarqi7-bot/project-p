using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARLogic : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public Image emotionImage;

    // Sprites for each state
    public Sprite doctorSprite;
    public Sprite sleepSprite;
    public Sprite companySprite;
    public Sprite noiseSprite;
    public Sprite quietSprite;
    public Sprite outingSprite;
    public Sprite happySprite;
    public Sprite loudSprite;
    public Sprite angrySprite;

    // 📊 STATS
    public int totalAttempts = 0;
    public float sessionTime = 0f;
    public bool isSessionRunning = false;

    public TextMeshProUGUI attemptsText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI engagementText;

    void Update()
    {
        if (isSessionRunning)
        {
            sessionTime += Time.deltaTime;
        }
    }

    // ▶️ Start session (call when Start pressed)
    public void StartSession()
    {
        totalAttempts = 0;
        sessionTime = 0f;
        isSessionRunning = true;
    }

    // ⛔ Stop session (call when Back pressed)
    public void StopSession()
    {
        isSessionRunning = false;
    }

    // 📊 Show results
    public void ShowResults()
    {
        attemptsText.text = "Attempts: " + totalAttempts;

        float minutes = Mathf.FloorToInt(sessionTime / 60);
        float seconds = Mathf.FloorToInt(sessionTime % 60);

        timeText.text = "Time: " + minutes + "m " + seconds + "s";

        // 🔥 Engagement %
        float engagement = 0f;

        if (sessionTime > 0)
            engagement = (totalAttempts / sessionTime) * 100f;

        engagementText.text = "Engagement: " + engagement.ToString("F1") + "%";
    }

    // 👇 When target is detected
    public void OnTargetFound(string imageName)
    {
        totalAttempts++; // 📊 count interactions

        resultText.text = "";
        emotionImage.sprite = null;

        if (imageName == "Target_Fear_Doctor")
        {
            resultText.text = "Anxiety in medical environments, needs reassurance and comfort.";
            emotionImage.sprite = doctorSprite;
        }
        else if (imageName == "Target_Need_Sleep")
        {
            resultText.text = "Low energy state, the child needs rest or sleep.";
            emotionImage.sprite = sleepSprite;
        }
        else if (imageName == "Target_Need_Company")
        {
            resultText.text = "Desire for social interaction and group play.";
            emotionImage.sprite = companySprite;
        }
        else if (imageName == "Target_Fear_Noise")
        {
            resultText.text = "Sensitive to noise, trying to protect sensory system.";
            emotionImage.sprite = noiseSprite;
        }
        else if (imageName == "Target_Need_Quiet")
        {
            resultText.text = "Needs a quiet environment to reduce stress.";
            emotionImage.sprite = quietSprite;
        }
        else if (imageName == "Target_Family_Outing")
        {
            resultText.text = "Needs a change of environment or family outdoor activity.";
            emotionImage.sprite = outingSprite;
        }
        else if (imageName == "Target_Feeling_Happy")
        {
            resultText.text = "Positive mood, ready for interaction and engagement.";
            emotionImage.sprite = happySprite;
        }
        else if (imageName == "Target_Dislike_Loud")
        {
            resultText.text = "Distressed by loud sounds, needs reduced noise.";
            emotionImage.sprite = loudSprite;
        }
        else if (imageName == "Target_Feeling_Angry")
        {
            resultText.text = "High anger state, needs space to calm down.";
            emotionImage.sprite = angrySprite;
        }
    }
}