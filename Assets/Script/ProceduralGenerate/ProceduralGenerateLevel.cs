using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerateLevel : MonoBehaviour
{
    public List<GameObject> easyTracks;
    public List<GameObject> mediumTracks;
    public List<GameObject> hardTracks;

    private float startTime;
    private float elapsedTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        elapsedTime = Time.time - startTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerLevel"))
        {
            GameObject selectedTrack = GetRandomTrack();
            if (selectedTrack != null)
            {
                Instantiate(selectedTrack, new Vector3(0, -1.35f, 222.7f), selectedTrack.transform.rotation);
            }
        }
    }

    private GameObject GetRandomTrack()
    {
        List<GameObject> trackList = new List<GameObject>();

        if (elapsedTime < 120)
        {
            trackList = easyTracks;

        }
        else if (elapsedTime < 300)
        {
            trackList = mediumTracks;

        }
        else if (elapsedTime < 600)
        {
            trackList = hardTracks;
        }
        else
        {
            trackList = hardTracks;
        }

        if (trackList.Count > 0)
        {
            return trackList[Random.Range(0, trackList.Count)];
        }

        Debug.LogWarning("Tidak ada lintasan yang tersedia untuk kesulitan saat ini!");
        return null;
    }
}
