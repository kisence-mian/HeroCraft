using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceCreateStatus : IApplicationStatus
{
    public int m_weight = 6;
    public int m_length = 12;

    public float m_cellSpace = 9;

    public string m_CellName = "Cell";
    public string m_BoundaryName = "boundary";

    public string m_parentName = "sence";

    public GameObject m_scenceParent = null;

    public override void OnEnterStatus()
    {
        FindParent();

        CreateCell();
        CreateBoundary();
    }

    void FindParent()
    {
        if (m_scenceParent == null)
        {
            m_scenceParent = GameObject.Find(m_parentName);

            if (m_scenceParent == null)
            {
                m_scenceParent = new GameObject(m_parentName);
            }
        }
    }

    void CreateCell()
    {


        for (int i = 0; i < m_length; i++)
        {
            for (int j = 0; j < m_weight; j++)
            {

                int random = RandomService.GetRand(1, 13);
                GameObject go = GameObjectManager.CreatGameObject(m_CellName + "_" + random);
                go.transform.SetParent(m_scenceParent.transform);

                go.transform.position = new Vector3(i * m_cellSpace, 0, j * m_cellSpace);
            }
        }
    }

    void CreateBoundary()
    {
        for (int i =  -1; i < m_length + 1; i++)
        {
            for (int j = -1; j < m_weight + 1; j++)
            {
                Debug.Log((i < 0 || i >= m_length || j < 0 || j >= m_weight) +" I:" + i + " J:" + j);

                if( i < 0 || i >= m_length || j < 0 || j>= m_weight)
                {
                    int random = RandomService.GetRand(1, 6);
                    GameObject go = GameObjectManager.CreatGameObject(m_BoundaryName + "_" + random);
                    go.transform.SetParent(m_scenceParent.transform);

                    go.transform.position = new Vector3(i * m_cellSpace, 0, j * m_cellSpace);
                }

            }
        }
    }
}
