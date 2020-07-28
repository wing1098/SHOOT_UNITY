using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 扇型攻击检测，并绘制检测区域
/// </summary>
public class SectorDetect : MonoBehaviour
{
    public Transform attacked;  //受攻击着
    GameObject go;
    MeshFilter mf;
    MeshRenderer mr;
    Shader shader;

    void Start()
    {

    }

    void Update()
    {

            ToDrawSectorSolid(transform, transform.localPosition, 60, 3);
            if (UmbrellaAttact(transform, attacked.transform, 60, 4))
            {
                Debug.Log("受攻击了");
            }
        

        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    if (go != null)
        //    {
        //        Destroy(go);
        //    }
        //}
    }

    /// <summary>
    /// 扇形攻击范围
    /// </summary>
    /// <param name="attacker">攻击者</param>
    /// <param name="attacked">被攻击方</param>
    /// <param name="angle">扇形角度</param>
    /// <param name="radius">扇形半径</param>
    /// <returns></returns>
    public bool UmbrellaAttact(Transform attacker, Transform attacked, float angle, float radius)
    {
        Vector3 deltaA = attacked.position - attacker.position;

        //Mathf.Rad2Deg : 弧度值到度转换常度
        //Mathf.Acos(f) : 返回参数f的反余弦值
        float tmpAngle = Mathf.Acos(Vector3.Dot(deltaA.normalized, attacker.forward)) * Mathf.Rad2Deg;
        if (tmpAngle < angle * 0.5f && deltaA.magnitude < radius)
        {
            return true;
        }
        return false;
    }

    public void ToDrawSectorSolid(Transform t, Vector3 center, float angle, float radius)
    {
        int pointAmmount = 100;
        float eachAngle = angle / pointAmmount;

        Vector3 forward = t.forward;
        List<Vector3> vertices = new List<Vector3>();

        vertices.Add(center);
        for (int i = 0; i < pointAmmount; i++)
        {
            Vector3 pos = Quaternion.Euler(0f, -angle / 2 + eachAngle * (i - 1), 0f) * forward * radius + center;
            vertices.Add(pos);
        }
        CreateMesh(vertices);
    }

    private GameObject CreateMesh(List<Vector3> vertices)
    {
        int[] triangles;
        Mesh mesh = new Mesh();

        int triangleAmount = vertices.Count - 2;
        triangles = new int[3 * triangleAmount];

        //根据三角形的个数，来计算绘制三角形的顶点顺序
        for (int i = 0; i < triangleAmount; i++)
        {
            triangles[3 * i] = 0;
            triangles[3 * i + 1] = i + 1;
            triangles[3 * i + 2] = i + 2;
        }

        if (go == null)
        {
            go = new GameObject("mesh");
            go.transform.position = new Vector3(0f, 0.1f, 0.5f);

            mf = go.AddComponent<MeshFilter>();
            mr = go.AddComponent<MeshRenderer>();

            shader = Shader.Find("Unlit/Color");
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles;

        mf.mesh = mesh;
        mr.material.shader = shader;
        mr.material.color = Color.red;

        return go;
    }
}