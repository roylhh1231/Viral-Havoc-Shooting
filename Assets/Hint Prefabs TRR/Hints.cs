using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public static Hints instance;

    public GameObject message;
    public GameObject laptop;
    public GameObject tab;
    public GameObject board;
    public GameObject letter;
    public GameObject note1;
    public GameObject note2;
    public GameObject report1;
    public GameObject report2;
    public GameObject report3;
    public GameObject report4;
    public GameObject report5;
    public GameObject report6;
    public GameObject report7;
    public GameObject report8;
    public GameObject report9;
    public GameObject report10;
    public GameObject report11;
    public GameObject diary1;
    public GameObject diary2;
    public GameObject diary3;
    public GameObject diary4;
    public GameObject diary5;
    public GameObject diary6;
    public GameObject diary7;
    public GameObject diary8;
    public GameObject diary9;
    public GameObject diary10;
    public GameObject card;

    public DoorWithDIary DoorWithDIary;

    AudioSource readhint;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        laptop.SetActive(false);
        tab.SetActive(false);
        board.SetActive(false);
        letter.SetActive(false);
        note1.SetActive(false);
        note2.SetActive(false);
        report1.SetActive(false);
        report2.SetActive(false);
        report3.SetActive(false);
        report4.SetActive(false);
        report5.SetActive(false);
        report6.SetActive(false);
        report7.SetActive(false);
        report8.SetActive(false);
        report9.SetActive(false);
        report10.SetActive(false);
        report11.SetActive(false);
        diary1.SetActive(false);
        diary2.SetActive(false);
        diary3.SetActive(false);
        diary4.SetActive(false);
        diary5.SetActive(false);
        diary6.SetActive(false);
        diary7.SetActive(false);
        diary8.SetActive(false);
        diary9.SetActive(false);
        diary10.SetActive(false);
        card.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(DoorWithDIary == null)
        {
            DoorWithDIary = GetComponent<DoorWithDIary>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenLaptop()
    {
        laptop.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseLaptop()
    {
        laptop.SetActive(false);
        tab.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenTab()
    {
        tab.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OpenBoard()
    {
        board.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseBoard()
    {
        board.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenLetter()
    {
        letter.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseLetter()
    {
        letter.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenNote1()
    {
        note1.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseNote1()
    {
        note1.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenNote2()
    {
        note2.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseNote2()
    {
        note2.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenCard()
    {
        card.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseCard()
    {
        card.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenReport1()
    {
        report1.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport2()
    {
        report2.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport3()
    {
        report3.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport4()
    {
        report4.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport5()
    {
        report5.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport6()
    {
        report6.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport7()
    {
        report7.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport8()
    {
        report8.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport9()
    {
        report9.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport10()
    {
        report10.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OpenReport11()
    {
        report11.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseReport1()
    {
        report1.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport2()
    {
        report2.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport3()
    {
        report3.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport4()
    {
        report4.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport5()
    {
        report5.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport6()
    {
        report6.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport7()
    {
        report7.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport8()
    {
        report8.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport9()
    {
        report9.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport10()
    {
        report10.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseReport11()
    {
        report11.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenDiary1()
    {
        diary1.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Goto2()
    {
        diary1.SetActive(false);
        diary2.SetActive(true);
    }
    public void Goto3()
    {
        diary2.SetActive(false);
        diary3.SetActive(true);
    }
    public void Goto4()
    {
        diary3.SetActive(false);
        diary4.SetActive(true);
    }
    public void Goto5()
    {
        diary4.SetActive(false);
        diary5.SetActive(true);
    }
    public void Goto6()
    {
        diary5.SetActive(false);
        diary6.SetActive(true);
    }
    public void Goto7()
    {
        diary6.SetActive(false);
        diary7.SetActive(true);
    }
    public void Goto8()
    {
        diary7.SetActive(false);
        diary8.SetActive(true);
    }
    public void Goto9()
    {
        diary8.SetActive(false);
        diary9.SetActive(true);
    }
    public void Goto10()
    {
        diary9.SetActive(false);
        diary10.SetActive(true);
    }

    public void GoBack1()
    {
        diary2.SetActive(false);
        diary1.SetActive(true);
    }
    public void GoBack2()
    {
        diary3.SetActive(false);
        diary2.SetActive(true);
    }
    public void GoBack3()
    {
        diary4.SetActive(false);
        diary3.SetActive(true);
    }
    public void GoBack4()
    {
        diary5.SetActive(false);
        diary4.SetActive(true);
    }
    public void CloseDiary()
    {
        diary5.SetActive(false);
        DoorWithDIary.diary = !DoorWithDIary.diary;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
