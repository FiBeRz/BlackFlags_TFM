using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private AudioSource useCardSoundEffect;
    [SerializeField] private AudioSource dragCardSoundEffect;

    private GameObject BattleSystem;

    public Transform parentToReturn;
    public Transform placeHolderParent;
    public GameObject placeHolder;

    void Awake()
    {
        BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (BattleSystem.GetComponent<BattleSystem>().isDraggable == false)
            return;

        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement layout = placeHolder.AddComponent<LayoutElement>();

        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturn = this.transform.parent;
        placeHolderParent = parentToReturn;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        dragCardSoundEffect.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (BattleSystem.GetComponent<BattleSystem>().isDraggable == false)
            return;

        this.transform.position = eventData.position;

        if (placeHolder.transform.parent != placeHolderParent) {
            placeHolder.transform.SetParent(placeHolderParent);
        }

        int newSiblingIndex = placeHolderParent.childCount;

        for (int i = 0; i < placeHolderParent.childCount; i++) {
            if (this.transform.position.x < placeHolderParent.GetChild(i).position.x) {
                newSiblingIndex = i;

                if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex) {
                    newSiblingIndex--;
                }

                break;
            }
        }

        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (BattleSystem.GetComponent<BattleSystem>().isDraggable == false)
            return;

        this.transform.SetParent(parentToReturn);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (parentToReturn.name == "DropArea")
        {
            BattleSystem.GetComponent<BattleSystem>().cardAction(this.GetComponent<CardDisplay>().id);
            StartCoroutine(destroyCard());
        }

        Destroy(placeHolder);
    }

    IEnumerator destroyCard()
    {
        useCardSoundEffect.Play();
        yield return new WaitForSeconds(0.05f);
        Destroy(this.gameObject);
    }
}
