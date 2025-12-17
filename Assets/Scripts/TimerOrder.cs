using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TimerOrder : MonoBehaviour
{
    public float duration;
    public GameObject SliderObjt;
    private Canvas CanvasPos;
    public Transform PosSlider;
    [HideInInspector]public Slider sliderOrder;
    private SpriteRenderer sr;
    public float Width;
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        CanvasPos = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        SliderOrderSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        SliderValue(duration);
        if(duration <= 0)
        {
            Debug.Log("Orderan gagal");
            Destroy(sliderOrder.gameObject);
            Destroy(gameObject);
        }
    }

    public void SliderOrderSpawn()
    {
        GameObject orderTimer = Instantiate(SliderObjt, PosSlider.position, SliderObjt.transform.rotation, CanvasPos.transform);
        sliderOrder = orderTimer.GetComponent<Slider>();
        sliderOrder.maxValue = duration;
        RectTransform rectTransform = orderTimer.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Width, rectTransform.sizeDelta.y);
    }

    public void SliderValue(float timer)
    {
        sliderOrder.value = timer;
    }
}
