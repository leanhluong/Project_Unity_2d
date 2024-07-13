using UnityEngine;

public class PlayerWeaponSwitch : MonoBehaviour
{
    // GameObjects chứa các vũ khí
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject weapon5;

    // Biến theo dõi vũ khí hiện tại
    private int currentWeapon = 0;

    void Start()
    {
        // Ban đầu không kích hoạt vũ khí nào
        weapon1.SetActive(true);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
        weapon4.SetActive(false);
        weapon5.SetActive(false);
    }

    void Update()
    {
        // Kiểm tra nếu người chơi nhấn các phím '1' đến '5'
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwitchWeapon(5);
        }
    }

    void SwitchWeapon(int weaponNumber)
    {
        // Nếu người chơi đang cầm vũ khí và nhấn lại cùng số, thì bỏ vũ khí
        if (currentWeapon == weaponNumber)
        {
            currentWeapon = 0; // Không cầm vũ khí nào
        }
        else
        {
            currentWeapon = weaponNumber; // Cầm vũ khí mới
        }

        // Vô hiệu hóa tất cả các vũ khí trước
        weapon1.SetActive(false);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
        weapon4.SetActive(false);
        weapon5.SetActive(false);

        // Kích hoạt vũ khí dựa trên số vũ khí
        switch (currentWeapon)
        {
            case 1:
                weapon1.SetActive(true);
                break;
            case 2:
                weapon2.SetActive(true);
                break;
            case 3:
                weapon3.SetActive(true);
                break;
            case 4:
                weapon4.SetActive(true);
                break;
            case 5:
                weapon5.SetActive(true);
                break;
        }
    }
}
