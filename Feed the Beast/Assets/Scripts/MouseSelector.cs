using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelector : Selector
{
    public Transform top;
    public Transform bottom;
    public Transform left;
    public Transform right;
    public LayerMask selectableMask;

    public AudioClip startBoxSound;
    public AudioClip endBoxSound;

    Rect selectionRect;
    bool isSelecting;
    AudioController controller;

    void Awake() {
        controller = Camera.main.GetComponent<AudioController>();
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(!isSelecting) {
            if(Input.GetButtonDown("Select")) {
                SetSelecting(true);
                selectionRect.position = mousePos;
                ClearSelections();
                controller.PlayClip(startBoxSound);
            }

            Collider2D[] hits = Physics2D.OverlapPointAll(mousePos, selectableMask);
            UpdateHover(hits);
        }

        if(isSelecting) {
            selectionRect.size = new Vector2(mousePos.x - selectionRect.position.x, mousePos.y - selectionRect.position.y);
            Collider2D[] hits = Physics2D.OverlapBoxAll(selectionRect.center, new Vector2(Mathf.Abs(selectionRect.width), Mathf.Abs(selectionRect.height)), 0f, selectableMask);
            UpdateHover(hits);

            if(Input.GetButtonUp("Select")) {
                SetSelecting(false);

                foreach(Collider2D hit in hits) {
                    Select(hit.transform);
                }

                controller.PlayClip(endBoxSound);
            }
        }

        DrawBox();
    }

    void SetSelecting(bool isSelect) {
        top.GetComponent<SpriteRenderer>().enabled = isSelect;
        bottom.GetComponent<SpriteRenderer>().enabled = isSelect;
        left.GetComponent<SpriteRenderer>().enabled = isSelect;
        right.GetComponent<SpriteRenderer>().enabled = isSelect;
        isSelecting = isSelect;
    }

    void DrawBox(){
        if(isSelecting) {
            top.position = new Vector2(selectionRect.center.x, selectionRect.yMin);
            bottom.position = new Vector2(selectionRect.center.x, selectionRect.yMax);
            left.position = new Vector2(selectionRect.xMin, selectionRect.center.y);
            right.position = new Vector2(selectionRect.xMax, selectionRect.center.y);

            top.transform.localScale = new Vector2(selectionRect.width, 1f);
            bottom.transform.localScale = new Vector2(selectionRect.width, 1f);
            left.transform.localScale = new Vector2(1f, selectionRect.height);
            right.transform.localScale = new Vector2(1f, selectionRect.height);
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(selectionRect.center, selectionRect.size);
    }
}
