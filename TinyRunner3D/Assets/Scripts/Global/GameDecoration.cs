using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDecoration : MonoBehaviour
{
    public enum LaneBuildMethod
    {
        repeatList,
        randomizeList
    };

    public Material[] materials;
    public Mesh[] meshes;

    public Segment[] segments;

    [System.Serializable]
    public struct Segment
    {
        public int mesh;
        public int material;
    };

    [System.Serializable]
    public struct LaneConfiguration
    {
        public int offsetX;
        public int offsetY;
        public Quaternion rotation;
        public LaneBuildMethod buildMethod;
        public int[] segmentList;
    };

    [System.Serializable]
    struct Lane
    {
        public int[] segments;
        public int repeatListLastIndex;

    };

    public LaneConfiguration[] laneConfigurations;

    public int laneLength = 100;

    public const int cellSize = 1;

    public float speed = 100.0f;
    public int segmentsAhead = 3;
    public int segmentsBehind = 3;


    Lane[] lanes;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = 0;

        // Init lanes

        lanes = new Lane[laneConfigurations.Length];

        for (int i = 0; i < lanes.Length; i++)
        {
            lanes[i].segments = new int[segmentsAhead + segmentsBehind + 1];

            if (laneConfigurations[i].buildMethod == LaneBuildMethod.randomizeList)
            {
                for (int j = 0; j < (segmentsAhead + segmentsBehind + 1); j++)
                {
                    int listIndex = UnityEngine.Random.Range(0, laneConfigurations[i].segmentList.Length);
                    lanes[i].segments[j] = laneConfigurations[i].segmentList[listIndex];
                }

            }
            else
            {
                int listLength = laneConfigurations[i].segmentList.Length;

                for (int j = 0; j < (segmentsAhead + segmentsBehind + 1); j++)
                {
                    int s = laneConfigurations[i].segmentList[j % listLength];
                    lanes[i].segments[j] = s;

                }

                lanes[i].repeatListLastIndex = (segmentsAhead + segmentsBehind) % listLength;

            }


        }

    }

    // Update is called once per frame
    void Update()
    {
        bool shift = false;

        offset += speed * Time.deltaTime;

        if (offset > laneLength * cellSize) { offset -= laneLength * cellSize; shift = true; }


        if (shift)
        {
            // Shift lanes ahead

            for (int i = 0; i < lanes.Length; i++)
            {
                for (int j = 0; j < lanes[i].segments.Length - 1; j++) { lanes[i].segments[j] = lanes[i].segments[j + 1]; }

                if (laneConfigurations[i].buildMethod == LaneBuildMethod.randomizeList)
                {
                    int listIndex = UnityEngine.Random.Range(0, laneConfigurations[i].segmentList.Length);
                    lanes[i].segments[lanes[i].segments.Length - 1] = laneConfigurations[i].segmentList[listIndex];

                }
                else // laneConfigurations[i].buildMethod == LaneBuildMethod.repeatList
                {
                    int listLength = laneConfigurations[i].segmentList.Length;
                    int nextIndex = (lanes[i].repeatListLastIndex + 1) % listLength;
                    lanes[i].segments[lanes[i].segments.Length - 1] = laneConfigurations[i].segmentList[nextIndex];
                    lanes[i].repeatListLastIndex = nextIndex;
                }

            }

        }

        RenderLanes();
    }

    void RenderLanes()
    {


        for (int i = 0; i < lanes.Length; i++)
        {
            Vector3 basePosition = new Vector3(laneConfigurations[i].offsetX, laneConfigurations[i].offsetY, -segmentsBehind * laneLength) * cellSize + Vector3.forward * -offset;

            for (int j = 0; j < lanes[i].segments.Length; j++)
            {
                Vector3 segmentPosition = basePosition + j * Vector3.forward * laneLength * cellSize;

                Segment segment = segments[lanes[i].segments[j]];
                Material segmentMaterial = materials[segment.material];
                Mesh segmentMesh = meshes[segment.mesh];

                //if(segmentMaterial.SetPass(0))
                //{
                Graphics.DrawMesh(segmentMesh, segmentPosition, laneConfigurations[i].rotation.normalized, segmentMaterial, gameObject.layer);
                //}

            }


        }

    }
}
