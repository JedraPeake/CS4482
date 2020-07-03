using UnityEngine;

public class GradientScript : MonoBehaviour
{
	public bool applyShader;
	public Material material;

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!applyShader)
		{
			Graphics.Blit(source, destination);
			return;
		}
		else if (applyShader)
		{
			Graphics.Blit(source, destination, material);
		}
	}
}
