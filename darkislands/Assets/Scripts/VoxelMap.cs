using UnityEngine;

public class VoxelMap : MonoBehaviour {


	public float size = 2f;

	public int voxelResolution = 8;
	public int chunkResolution = 2;

	public float maxFeatureAngle = 135f, maxParallelAngle = 8f;

	public VoxelGrid voxelGridPrefab;

	public Transform[] stencilVisualizations;

	public bool snapToGrid;

	private VoxelGrid[] chunks;
	
	private float chunkSize, voxelSize, halfSize;

	private int fillTypeIndex = 1, radiusIndex=1, stencilIndex=0;

	private VoxelStencil[] stencils = {
		new VoxelStencil(),
		new VoxelStencilCircle()
	};
	
	private void Awake () {
		halfSize = size * 0.5f;
		chunkSize = size / chunkResolution;
		voxelSize = chunkSize / voxelResolution;
		
		chunks = new VoxelGrid[chunkResolution * chunkResolution];
		for (int i = 0, y = 0; y < chunkResolution; y++) {
			for (int x = 0; x < chunkResolution; x++, i++) {
				CreateChunk(i, x, y);
			}
		}
		BoxCollider box = gameObject.AddComponent<BoxCollider>();
		box.size = new Vector3(size, size,1);
	    SetInitialCircle();
	}

	private void CreateChunk (int i, int x, int y) {
		VoxelGrid chunk = Instantiate(voxelGridPrefab) as VoxelGrid;
		chunk.Initialize(
			voxelResolution, chunkSize, maxFeatureAngle, maxParallelAngle);
		chunk.transform.parent = transform;
		chunk.transform.localPosition =
			new Vector3(x * chunkSize - halfSize, y * chunkSize - halfSize, 0);
		chunks[i] = chunk;
		if (x > 0) {
			chunks[i - 1].xNeighbor = chunk;
		}
		if (y > 0) {
			chunks[i - chunkResolution].yNeighbor = chunk;
			if (x > 0) {
				chunks[i - chunkResolution - 1].xyNeighbor = chunk;
			}
		}
	}

    private void SetInitialCircle()
    {
        var circleStencil = stencils[1];
        circleStencil.Initialize(0, 100f);
        EditVoxels(new Vector2(20, 20), circleStencil);
        circleStencil.Initialize(4, 18f);
        EditVoxels(new Vector2(10, 10), circleStencil);
        circleStencil.Initialize(3, 11f);
        EditVoxels(new Vector2(10, 10), circleStencil);
    }

    private void EditVoxels (Vector2 center) {
		VoxelStencil activeStencil = stencils[stencilIndex];
		activeStencil.Initialize(
			fillTypeIndex, (radiusIndex + 0.5f) * voxelSize);
		activeStencil.SetCenter(center.x, center.y);

		EditVoxels(center, activeStencil);
	}

    private void EditVoxels(Vector2 center, VoxelStencil activeStencil)
    {
        int xStart = (int) ((activeStencil.XStart - voxelSize)/chunkSize);
        if (xStart < 0)
        {
            xStart = 0;
        }
        int xEnd = (int) ((activeStencil.XEnd + voxelSize)/chunkSize);
        if (xEnd >= chunkResolution)
        {
            xEnd = chunkResolution - 1;
        }
        int yStart = (int) ((activeStencil.YStart - voxelSize)/chunkSize);
        if (yStart < 0)
        {
            yStart = 0;
        }
        int yEnd = (int) ((activeStencil.YEnd + voxelSize)/chunkSize);
        if (yEnd >= chunkResolution)
        {
            yEnd = chunkResolution - 1;
        }

        for (int y = yEnd; y >= yStart; y--)
        {
            int i = y*chunkResolution + xEnd;
            for (int x = xEnd; x >= xStart; x--, i--)
            {
                activeStencil.SetCenter(
                    center.x - x*chunkSize, center.y - y*chunkSize);
                chunks[i].Apply(activeStencil);
            }
        }
    }
}