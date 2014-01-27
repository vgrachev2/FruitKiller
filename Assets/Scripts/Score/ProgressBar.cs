using UnityEngine;
using System.Collections;

public class ProgressBar:MonoBehaviour, IProgressBar
{
	public float barDisplay; //current progress
    public Vector2 pos = new Vector2(-4.446732f, -3.61142f);
	public Vector2 size = new Vector2(350,18);

	
	public void OnGui() {
		//draw the background:
		var emptyProgressBarStyle = new GUIStyle( GUI.skin.box );
		emptyProgressBarStyle.normal.background = MakeTex( (int)size.x, (int)size.y, new Color(0,0.4f,0.2f));
		var fullProgressBarStyle = new GUIStyle( GUI.skin.box );
		fullProgressBarStyle.normal.background = MakeGradientTex( (int)size.x, (int)size.y, new Color(0.98f,1f,0.314f), new Color(1F,0.71f,0f));

        var correctScore = Camera.main.WorldToScreenPoint(pos);


        GUI.BeginGroup(new Rect(correctScore.x, Screen.height - correctScore.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), "",fullProgressBarStyle);

		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y),"",emptyProgressBarStyle);
		GUI.EndGroup();
		GUI.EndGroup();
	}

	private Texture2D MakeTex(int width, int height,Color col )
	{
		Color[] pix = new Color[width * height];
			for( int i = 0; i < pix.Length; ++i )
			{
				pix[i] = col;
			}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}

	private Texture2D MakeGradientTex( int width, int height, Color col1,Color col2 )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i <width*height/2; ++i )
		{
			pix[i] = col2;
		}
		for( int i = width*height/2; i <pix.Length; ++i )
		{
			pix[i] = col1;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}

	public void Update(float newValue) {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		if (newValue == 0)
			return;
	    barDisplay = 1-newValue;
	    //   barDisplay = MyControlScript.staticHealth;
	}
}
