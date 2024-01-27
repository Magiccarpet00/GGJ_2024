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

    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(OnPlay);
    }

	private void OnPlay()
	{
        StartCoroutine(CloseAnimation());
	}

    IEnumerator CloseAnimation()
	{
        while(loading.fillAmount < 1)
		{
            elapsedTime += Time.deltaTime * speed;
            loading.fillAmount = Mathf.Lerp(0, 1, elapsedTime / loadingDuration);
            yield return null;
        }

        SceneManager.LoadScene("MainScene");
        yield return null;

	}

}
