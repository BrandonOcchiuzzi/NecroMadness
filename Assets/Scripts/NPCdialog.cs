using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class NPCdialog : Collidable
{
    public string message;

    public string message2;

    private float cooldown = 15.0f;
    private float lastShout = -15.0f;
    private bool dialog = true;
    protected async Task showDialog()
    {
        GameManager.instance.ShowText(message, 25, Color.white, transform.position + new Vector3(0, 0.20f, 0), Vector3.zero, 5.0f);
        await Task.Delay(5000);
        GameManager.instance.ShowText(message2, 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, 5.0f);
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (Time.time - lastShout > cooldown)
        {
            lastShout = Time.time;
            showDialog();
        }
    }
}
