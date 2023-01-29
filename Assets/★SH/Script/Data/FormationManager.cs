using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FormationData
{
    public Vector3[] pos = new Vector3[6];
}

public class FormationManager : MonoBehaviour
{
    public static FormationManager instance;
    private void Awake()
    {
        instance = this;

        SetFormationList();
    }

    private Dictionary<string, FormationData> formData = new Dictionary<string, FormationData>();

    FormationData form0 = new FormationData();
    FormationData form1 = new FormationData();
    //FormationData form2 = new FormationData();
    //FormationData form3 = new FormationData();

    public void SetFormationList()
    {
        #region 2-1-2
        form0.pos[0] = new Vector3(0, -770, 0);
        form0.pos[1] = new Vector3(-200, -360, 0);
        form0.pos[2] = new Vector3(200, -360, 0);
        form0.pos[3] = new Vector3(0, 0, 0);
        form0.pos[4] = new Vector3(-300, 360, 0);
        form0.pos[5] = new Vector3(300, 360, 0);
        #endregion

        #region 2-2-1
        form1.pos[0] = new Vector3(0, -770, 0);
        form1.pos[1] = new Vector3(-200, -360, 0);
        form1.pos[2] = new Vector3(200, -360, 0);
        form1.pos[3] = new Vector3(0, 360, 0);
        form1.pos[4] = new Vector3(-300, 0, 0);
        form1.pos[5] = new Vector3(300, 0, 0);
        #endregion

        formData.Add("2 - 1 - 2", form0);
        formData.Add("2 - 2 - 1", form1);
    }

    public List<string> GetFormNames()
    {
        List<string> names = new List<string>();

        foreach (string key in formData.Keys)
        {
            names.Add(key);
        }

        return names;
    }

    public FormationData GetForm(string key)
    {
        return formData[key];
    }
}
