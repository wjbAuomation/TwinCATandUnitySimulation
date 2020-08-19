using Assets.Classes;
using Assets.Classes.TwinCATHandler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim_Conveyor : SimulationObject
{
    [SerializeField]
    public float conveyorSpeed = 0.5f;
    public bool direction;
    public float fbkOffset;
    public float fbkPosition;

    private float offset = 0;
    private Renderer rend;
    private bool motorEnabled;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        motorEnabled = TwinCatHandler.ReadBool(pouName, varName);
        if (motorEnabled)
        {
            AnimateTexture();
        }
    }

    void AnimateTexture()
    {
        offset += Time.deltaTime * conveyorSpeed *1.01f;
        fbkOffset = offset;
        Vector2 currentOffset = rend.material.mainTextureOffset;
        rend.material.mainTextureOffset = new Vector2(offset, currentOffset.y);
    }

    private void OnCollisionStay(Collision collidingObject)
    {
        float modifier = direction ? 1 : -1;

        Vector3 beltVelocity = transform.forward * modifier * conveyorSpeed * Time.deltaTime;        

        iTote collidingTote = collidingObject.gameObject.GetComponent<Sim_Tote>();

        if (motorEnabled)
        {
            if (collidingTote != null)
            {
                collidingTote.updatePosition(beltVelocity, this.transform.parent.gameObject);
            }

        }

    }
}
