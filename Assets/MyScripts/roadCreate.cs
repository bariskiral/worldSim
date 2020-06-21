using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadCreate : MonoBehaviour
{
    public GameObject prefapRoad;

    Vector3 roadStart;

    private void Start()
    {
        enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickLocation(out roadStart);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 roadEnd;
            if (ClickLocation(out roadEnd))
            {
                CreateRoad(roadStart, roadEnd);
            }
        }
    }

    bool ClickLocation(out Vector3 point)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo = new RaycastHit();

        if (GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            point = hitInfo.point;
            return true;
        }
        point = Vector3.zero;
        return false;
    }


    void CreateRoad(Vector3 roadStart, Vector3 roadEnd)
    {

        GameObject road = Instantiate(prefapRoad);
        road.transform.position = roadStart + new Vector3(0, 0.01f, 0);

        float angle = Vector3.Angle(Vector3.right, roadEnd - roadStart);
        road.transform.rotation = Quaternion.FromToRotation(Vector3.right, roadEnd - roadStart);

        float width = 5;
        float length = Vector3.Distance(roadStart, roadEnd);

        Vector3[] vertices =
        {
            new Vector3(0,       0,  -width/2),
            new Vector3(length,  0,  -width/2),
            new Vector3(length,  0,   width/2),
            new Vector3(0,       0,   width/2)
        };

        int[] triangles =
        {
            1, 0, 2,
            2, 0, 3
        };

        Vector2[] uv =
        {
            new Vector2(0,0),
            new Vector2(length,0),
            new Vector2(length,1),
            new Vector2(0,1)
        };

        Vector3[] normals =
        {
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up
        };

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.normals = normals;

        MeshFilter mesh_filter = road.GetComponent<MeshFilter>();
        mesh_filter.mesh = mesh;
    }
}
