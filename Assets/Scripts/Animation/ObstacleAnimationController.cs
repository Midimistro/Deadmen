using UnityEngine;
using System.Collections;
using System.Linq;

public class ObstacleAnimationController : MonoBehaviour {

    private string ObstacleMaterial = "Game_Assets/materials/Wall_DEV_Grey-Bottom";
    private int LoadedMaterialSemaphore = 0;
    private const int MaterialReloadBuffer = 50;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        if (LoadedMaterialSemaphore == 0)
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material = Resources.Load(ObstacleMaterial) as Material;
                LoadedMaterialSemaphore = -1;
            }
            else
            {
                LoadedMaterialSemaphore = MaterialReloadBuffer;
            }
        } else
        {
            if (LoadedMaterialSemaphore > 0)
            {
                LoadedMaterialSemaphore--;
            }
        }
	}

    public void ChangeMaterial(string NewMaterial)
    {
        ObstacleMaterial = NewMaterial;
        LoadedMaterialSemaphore = 0;
    }
}
