using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroClip : MonoBehaviour {


    public MovieTexture[] textures;
    int movieIndex = 0;
    MovieTexture texture;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (texture == null || !texture.isPlaying) {
            Debug.Log(textures.Length + " " + movieIndex);
            if (movieIndex < textures.Length)
            {
                texture = textures[movieIndex];
                this.GetComponent<Renderer>().material.mainTexture = texture;
                texture.Stop();
                texture.Play();
                movieIndex++;
            }
            else {
                SceneManager.LoadScene("Menu");
            }
        }
	}
}
