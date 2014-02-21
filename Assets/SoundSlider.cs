using Assets.Plugins.Game.Common;
using Assets.Scripts.MenuButtons;
using UnityDI;
using UnityEngine;
using System.Collections;

public class SoundSlider : MonoBehaviour {

    private float _vSliderValue = 0;
    [Dependency]
    public IAudioPlayer _audioPlayer { get; set; }

    public GameObject SliderPlace;
	// Use this for initialization
	void Start (){
	   var currentVolume= _audioPlayer.GetVolume();
	    _vSliderValue = currentVolume*10;
	}
	
	// Update is called once per frame
	void Update () {
	_audioPlayer.SetVolume(_vSliderValue/10);

	}

    void OnGUI()
    {

        var sliderStyle = new GUIStyle(GUI.skin.horizontalSlider);
        var correctSliderPlace = Camera.main.WorldToScreenPoint(SliderPlace.transform.position);
        Vector3 posStart = Camera.main.WorldToScreenPoint(new Vector3(SliderPlace.renderer.bounds.min.x, SliderPlace.renderer.bounds.min.y, SliderPlace.renderer.bounds.min.z));
        Vector3 posEnd = Camera.main.WorldToScreenPoint(new Vector3(SliderPlace.renderer.bounds.max.x, SliderPlace.renderer.bounds.max.y, SliderPlace.renderer.bounds.min.z));

        int widthX = (int)(posEnd.x - posStart.x);

        int widthY = (int)(posEnd.y - posStart.y);
        sliderStyle.normal.background = MakeGradientTex((int)100, 300, new Color(0.3450980392156863f, 0.8392156862745098f, 0.803921568627451f), new Color(0F, 0.6901960784313725f, 0.6862745098039216f));
        sliderStyle.fixedHeight = widthY;//SliderPlace.renderer.bounds.size.y;
        var sliderThumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb);
        sliderThumbStyle.fixedHeight = widthY;
        _vSliderValue = GUI.HorizontalSlider(new Rect(posStart.x, Screen.height - posStart.y - widthY, widthX, widthY), _vSliderValue, 0, 10.0f, sliderStyle, sliderThumbStyle);
      
    }
    private Texture2D MakeGradientTex(int width, int height, Color col1, Color col2)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < width * height / 2; ++i)
        {
            pix[i] = col2;
        }
        for (int i = width * height / 2; i < pix.Length; ++i)
        {
            pix[i] = col1;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
