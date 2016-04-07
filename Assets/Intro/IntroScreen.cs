using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour {

    MovieTexture[] intros;
    MovieTexture currentIntro;
    Material myMaterial;
    int introIndex;

	// Use this for initialization
	void Start () {
        intros = Resources.LoadAll<MovieTexture>("IntroVids/");
        myMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentIntro == null || !currentIntro.isPlaying) {
            if (introIndex < intros.Length)
            {
                currentIntro = intros[introIndex];
                myMaterial.mainTexture = currentIntro;
                myMaterial.SetTexture("_EmissionMap", currentIntro);
                AudioSource src = GetComponent<AudioSource>();
                while (!currentIntro.isReadyToPlay) {
                }
                AudioClip movieAudio = currentIntro.audioClip;
                src.clip = movieAudio;

                src.Stop();
                src.Play();

                currentIntro.Stop();
                currentIntro.Play();
                introIndex++;
            }
            else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }
	}
}
