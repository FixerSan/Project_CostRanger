using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIPopup_WorldText : UIBase
{
    public float fadeTime;
    public void Init(string _description , Vector2 _position, Define.TextType _type)
    {
        Managers.UI.SetCanvas(gameObject, _isToast: true);
        BindText(typeof(Texts));
        GetText((int)Texts.Text_Damage).text = _description;
        GetText((int)Texts.Text_Damage).rectTransform.position = _position;



        switch (_type)
        {
            case Define.TextType.Damage:
                    GetText((int)Texts.Text_Damage).color = Color.red;
                break;

            case Define.TextType.Heal:
                GetText((int)Texts.Text_Damage).color = Color.green;
                break;

            case Define.TextType.Normal:
                GetText((int)Texts.Text_Damage).color = Color.white;
                break;
        }
        StartCoroutine(FadeOut());
    }

    public void FixedUpdate()
    {
        GetText((int)Texts.Text_Damage).transform.position += Vector3.up * Time.deltaTime;
    }

    IEnumerator FadeOut()
    {
        Vector3 dir = new Vector3(Random.Range(-1f, 1f), 1, 1).normalized;
        while (GetText((int)Texts.Text_Damage).color.a > 0)
        {
            GetText((int)Texts.Text_Damage).rectTransform.position += dir * (Time.deltaTime / fadeTime);
            GetText((int)Texts.Text_Damage).color = new Color(GetText((int)Texts.Text_Damage).color.r, GetText((int)Texts.Text_Damage).color.g, GetText((int)Texts.Text_Damage).color.b, GetText((int)Texts.Text_Damage).color.a - Time.deltaTime / fadeTime);
            yield return null;
        }

        Managers.Resource.Destroy(this.gameObject);
    }

    public enum Texts
    {
        Text_Damage
    }
   
}
