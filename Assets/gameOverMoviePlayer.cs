using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverMoviePlayer : MonoBehaviour
{

    public MovieTexture movie;
    RawImage rawImageComp;

    // Use this for initialization
    void Start()
    {
        rawImageComp = GetComponent<RawImage>();
        playGameOver();

    }

    void playGameOver()
    {
        rawImageComp.texture = movie;
        movie.Play();
    }
}
