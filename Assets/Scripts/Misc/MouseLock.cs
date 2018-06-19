using UnityEngine;
using System.Collections;


public class MouseLock : MonoBehaviour {
    CursorLockMode wantedMode;
    private bool m_cursorIsLocked = true;
    public bool lockCursor = true;


    void Start() {
		//Cursor.lockState = wantedMode;
		//wantedMode = CursorLockMode.Locked;
        SetCursorLock(lockCursor);
        m_cursorIsLocked = true;
        Cursor.visible = false;
	}
    
    
    
    void Update() {
        if (Input.GetKeyDown (KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Debug.Log ("Free");
		}
        UpdateCursorLock();
        
        
    }
    
    public void SetCursorLock(bool value)
        {
            lockCursor = value;
            if(!lockCursor)
            {//we force unlock the cursor if the user disable the cursor locking helper
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

    public void UpdateCursorLock()
    {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (lockCursor)
                InternalLockUpdate();
    }
    
    
    private void InternalLockUpdate()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked = false;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                m_cursorIsLocked = true;
            }

            if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
}