using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    ItemSpawner _itemSpawner;
    Score _score;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _itemSpawner = FindObjectOfType<ItemSpawner>();
        _score = FindObjectOfType<Score>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            _audioSource.Play();
            _itemSpawner.DestroyItem(other.gameObject);
            _score.ScoreNum += 1;
            _score.MyScoreText.text = "Score: " + _score.ScoreNum;
        }
    }
}
