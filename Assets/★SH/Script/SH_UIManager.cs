using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SH_UIManager : MonoBehaviour
{
    public static SH_UIManager instance;
    private void Awake()
    {
        if (instance != null)
            instance = this;
    }

    public Dropdown ddFormation;
    public List<string> optionList = new List<string>();

    public GameObject blueFactory;
    //public GameObject redFactory;

    public Transform blueParent;
    public Transform redParent;


    // 1. ���� �����̰� �ʹ�.
    // 2. ����ٿ� �ɼǿ� �°� ���� ��ġ�ϰ� �ʹ�.
    void Start()
    {
        ddFormation.ClearOptions();

        optionList = FormationManager.instance.GetFormNames();
        ddFormation.AddOptions(optionList);

        ddFormation.onValueChanged.AddListener(OnValueChanged);

    }

    void Update()
    {
        
    }

    void DropDownFormation()
    {
        ddFormation.ClearOptions();

        optionList = FormationManager.instance.GetFormNames();
        ddFormation.AddOptions(optionList);
    }

    public void OnValueChanged(int arg)
    {
        FormationData selected = FormationManager.instance.GetForm(optionList[arg]);

        // �����ϰ�
        for (int i = 0; i < blueParent.childCount; i++)
        {
            GameObject go = blueParent.GetChild(i).gameObject;

            //go.GetComponent<SH_PieceWindow>().OnClickBtnDistDelete();
            //go.GetComponent<SH_PieceWindow>().OnClickBtnArrowDelete();
            Destroy(go);
        }

        // �����Ѵ�.
        for (int i = 0; i < selected.pos.Length; i++)
        {
            GameObject bluePiece = Instantiate(blueFactory, blueParent);
            bluePiece.name += i + 1;
            bluePiece.transform.localPosition = selected.pos[i];
        }
        ddFormation.value = arg;
    }
}
