using UnityEngine;
using System.Collections;

public class Breath : MonoBehaviour {

	// Use this for initialization
	public void Start ()
	{
		WalkRate = 4.0;
		WalkSpeed = 1.5;
		RunRate = 2.0;
		RunSpeed = 3.5;
		NextBreath = 0;
		Interval = 0;

	}

	public AudioClip BreathSound;
	private double WalkRate { get; set; }
	private double WalkSpeed { get; set; }
	private double RunRate { get; set; }
	private double RunSpeed { get; set; }
	private Vector3 LastPos { get; set; }
	private double NextBreath { get; set; }
	private double Interval { get; set; }
	// Update is called once per frame
	public void Update () {

		if (GetComponent<AudioSource>().isPlaying)
			return;

		var dt = Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<AudioSource> ().Stop();
			GetComponent<AudioSource>().PlayOneShot(BreathSound); // play the sound...
		}
		if (dt > 0)
		{ // only breathe when game not paused!
			// calculate the distance since last frame:
			var dist = Vector3.Distance(LastPos, transform.position);
			// update lastPos:
			LastPos = transform.position;
			// calculate the current speed:
			var speed = dist / dt;
			if (speed > RunSpeed)
			{ // is running?
				Interval = RunRate;
			}
			else
				if (speed > WalkSpeed)
				{ // else is walking?
					Interval = WalkRate;
				}
				else { // else stop breath sound
					Interval = 0;
				}
			// if breath enabled and it's time to breath...
			if (Interval > 0 && Time.time > NextBreath)
			{
				GetComponent<AudioSource>().Stop();
				GetComponent<AudioSource>().PlayOneShot(BreathSound); // play the sound...
				NextBreath = Time.time + Interval; // and set next time to breath
			}
		}
	}
}
