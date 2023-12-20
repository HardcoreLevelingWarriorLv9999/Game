using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        // Kiểm tra nếu có cảm ứng
        if (Input.touchCount > 0)
        {
            // Lấy thông tin cảm ứng đầu tiên
            Touch touch = Input.GetTouch(0);

            // Xác định vị trí cảm ứng trên màn hình
            Vector2 touchPosition = touch.position;
            float halfScreen = Screen.width / 2;

            // Di chuyển nhân vật sang phải nếu cảm ứng ở nửa bên phải màn hình
            if (touchPosition.x > halfScreen)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            // Di chuyển nhân vật sang trái nếu cảm ứng ở nửa bên trái màn hình
            else if (touchPosition.x < halfScreen)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
    }
}
