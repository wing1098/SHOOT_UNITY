using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;

    private Transform container;
    private Transform keyTemplate;

    private void Awake()
    {
        container   = transform.Find("container");
        keyTemplate = container.Find("keyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        //Clean up old key
        foreach(Transform child in container) {
            if (child == keyTemplate) continue;
            Destroy(child.gameObject);
            Debug.Log("destory");
        }

        //Instantiate current key list 
        List<KeySystem.KeyType> keyList = keyHolder.GetKeyList();

        for(int i = 0; i < keyList.Count; i++)
        {
            KeySystem.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTransform.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);

            Image keyImage = keyTransform.Find("image").GetComponent<Image>();

            switch(keyType)
            {
                //change key color to what key player have
                default:
                case KeySystem.KeyType.Red:     keyImage.color = Color.red;     break;
                case KeySystem.KeyType.Green:   keyImage.color = Color.green;   break;
            }
        }
    }
}
