using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    private List<string> TextToDisplay;

    private float RotatingSpeed;
    private float TimeToNextText;
    private int CurrentText;

    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;
        RotatingSpeed = 5.0f;
        TextToDisplay = new List<string>();
        TextToDisplay.Add("Congratulations");
        TextToDisplay.Add("All Errors Fixed");
        Text.text = TextToDisplay[0];
        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;
        if (TimeToNextText > 1.5f)
        {
            Text.text = TextToDisplay[CurrentText];
            CurrentText++;
            if (CurrentText == TextToDisplay.Count)
            {
                CurrentText = 0;
            }
            TimeToNextText = 0;
        }
        Text.transform.Rotate(Vector3.up * Time.deltaTime * RotatingSpeed);
    }
}
