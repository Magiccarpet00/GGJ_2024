using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Image loading;
    [SerializeField] private float loadingDuration;
    [SerializeField] private float speed;
    [SerializeField] private GameObject OptionScreen;

    private float elapsedTime;

	private void OnEnable()
	{
        loading.GetComponent<Image>().fillAmount = 0;
	}

	// Start is called before the first frame update
	void Start()
    {
        play.onClick.AddListener(OnPlay);
    }

	private void OnPlay()
	{
        StartCoroutine(CloseAnimation(true));
	}

    IEnumerator CloseAnimation(bool wasPlayPressed)
	{
        while(loading.fillAmount < 1)
		{
            elapsedTime += Time.deltaTime * speed;
            loading.fillAmount = Mathf.Lerp(0, 1, elapsedTime / loadingDuration);
            yield return null;
        }

        if (wasPlayPressed) SceneManager.LoadScene("MainScene");
        else
        {
            OptionScreen.SetActive(true);
            gameObject.SetActive(false);
        }
        yield return null;

	}

}
