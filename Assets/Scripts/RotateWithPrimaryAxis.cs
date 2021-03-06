using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithPrimaryAxis : MonoBehaviour
{
    private Transform m_Transform;

    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float degrees = GetDegreeRotation();
        if (degrees > 0)
            m_Transform.rotation = Quaternion.Euler(0f, degrees, 0f);
    }

    float GetDegreeRotation()
    {
        float degrees = 0f;
        float X = InputAbstraction.GetAxis(InputAbstraction.AxisAlias.X, InputAbstraction.PreferedHand());
        float Y = InputAbstraction.GetAxis(InputAbstraction.AxisAlias.Y, InputAbstraction.PreferedHand());

        bool XIsNegative = X < 0 ? true : false;
        bool YIsNegative = Y < 0 ? true : false;

        X = Mathf.Abs(X);
        Y = Mathf.Abs(Y);

        degrees = (YIsNegative ^ XIsNegative) ? Mathf.Atan(Y / X) * (180 / Mathf.PI) : Mathf.Atan(X / Y) * (180 / Mathf.PI);

        if (YIsNegative && !XIsNegative)
            degrees += 90;
        else if (YIsNegative && XIsNegative)
            degrees += 180;
        else if (!YIsNegative && XIsNegative)
            degrees += 270;

        return degrees;
    }
}
