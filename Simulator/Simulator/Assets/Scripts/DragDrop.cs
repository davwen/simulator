using System.Linq;
using UnityEngine;

//This script is used to handle the Drag n' Drop system (for GameObjects).

public class DragDrop : MonoBehaviour
{
    public static DragDrop Instance { get; private set; }

    public bool isDragging = false;

    public float speed;

    public InputMaster controls;

    private bool isMouseDown;
    private bool isMouseDownCheck;

    private bool isFreeReleaseDown;

    public Vector3[] offsets;
    public Rigidbody2D[] bodies;

    public RigidbodyConstraints2D[] constraintsBeforeDrag;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Editor.drag.performed += _ => isMouseDown = true;
        controls.Editor.drag.canceled += _ => isMouseDown = false;

        controls.Editor.freeRelease.performed += _ => isFreeReleaseDown = true;
        controls.Editor.freeRelease.canceled += _ => isFreeReleaseDown = false;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else { Destroy(gameObject); }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isMouseDownCheck == false && isMouseDown == true) //Mouse pressed inside object
        {
            foreach (Object selectedObj in SelectionManager.Instance.currentlySelected)
            {
                if (IsMouseInsideObject(selectedObj, mousePosition))
                {
                    offsets = new Vector3[0];

                    bodies = new Rigidbody2D[0];

                    constraintsBeforeDrag = new RigidbodyConstraints2D[0];

                    foreach (Object obj in SelectionManager.Instance.currentlySelected)
                    {
                        offsets = AddToArray(offsets, obj.transform.position - mousePosition);

                        bodies = AddToArray(bodies, obj.GetComponent<Rigidbody2D>());

                        constraintsBeforeDrag = AddToArray(constraintsBeforeDrag, obj.GetComponent<Rigidbody2D>().constraints);

                        isDragging = true;
                    }
                }
            }
        }
        
        if(isMouseDownCheck == true && isMouseDown == false) //Mouse released
        {
            isDragging = false;

            int i = 0;
            foreach (Object selectedObj in SelectionManager.Instance.currentlySelected)
            {
                Rigidbody2D body = selectedObj.GetComponent<Rigidbody2D>();

                if (!FindObjectOfType<ObjectManager>().isRunning)
                {
                    body.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                else{
                    if(!isFreeReleaseDown){
                        body.velocity = Vector3.zero;
                    }
                    
                    body.constraints = constraintsBeforeDrag[i];
                }

                body.isKinematic = false;
                i++;
            }

            isMouseDownCheck = isMouseDown;
           
        }

        if (isDragging)
        {
            for (int i = 0; offsets.Length > i && bodies.Length > i; i++)
            {
                Vector3 targetVelocity = SelectionManager.Instance.currentlySelected[i].transform.position - (mousePosition + offsets[i]);

                Rigidbody2D body = bodies[i];

                body.constraints = RigidbodyConstraints2D.None;

                body.isKinematic = true;

                body.velocity = targetVelocity * -speed;
            }
        }

        isMouseDownCheck = isMouseDown;
    }

    private void StopRigidbody(Rigidbody2D body)
    {
        body.isKinematic = true;
        body.velocity = Vector2.zero;
    }

    private bool IsMouseInsideObject(Object obj, Vector3 mousePosition) //Is the mouse inside the object?
    {
        bool result = false;

        if(obj != null)
        {
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

            result = mousePosition.x > sr.bounds.min.x && mousePosition.x < sr.bounds.max.x
                && mousePosition.y > sr.bounds.min.y && mousePosition.y < sr.bounds.max.y;
        }

        return result;
      
    }

    private T[] AddToArray<T>(T[] input, T valueToAdd)
    {
        return input.Concat(new T[] { valueToAdd }).ToArray();
    }
}