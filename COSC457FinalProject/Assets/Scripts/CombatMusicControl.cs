using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CombatMusicControl : MonoBehaviour
{

    [SerializeField]
    private float range = 10.0f;

    private float distance; 
    private Transform t;
    private Transform enemy;

    public AudioMixerSnapshot outOfCombat;
    public AudioMixerSnapshot inCombat;
    public AudioClip[] stings;
    public AudioSource stingSource;
    public float bpm = 128;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;
    

    // Start is called before the first frame update
    void Start()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(enemy.position, transform.position);

        if (distance < range)
        {
            inCombat.TransitionTo(m_TransitionIn);
        }
        else if (distance > range)
        {
            outOfCombat.TransitionTo(m_TransitionOut);
        }
    }
}
