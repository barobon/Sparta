using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler    //드래그 구현
{
	//조이스틱 안에서 이동하는 knob에 추가해야 하는 스크립트

	[Header("Camera")]  //인스펙터 창에서 타이틀을 단다. 
	public Camera TargetCamera;

	[Header("Axis")]
	public float MaxRange = 1f;

	[Header("Binding")]
	public UnityEvent<Vector2> JoystickValue;

	//
	protected Vector2 _neutralPosition;
	protected Vector2 _joystickValue;
	protected Vector2 _newTargetPosition;
	protected Vector3 _newJoystickPosition;

	protected virtual void Start()
	{
		Initialize();
	}

	protected virtual void OnEnable()
	{
		Initialize();
	}

	public virtual void Initialize()
	{
		_neutralPosition = GetComponent<RectTransform>().transform.position;
	}

	protected virtual void Update()
	{
		//inputManager에 조이스틱의 위치변환을 전달한다.
		if (JoystickValue == null)
		{
			return;
		}

		// 입력값 가공
		_joystickValue.x = EvaluateInputValue(_newTargetPosition.x);
		_joystickValue.y = EvaluateInputValue(_newTargetPosition.y);

		JoystickValue.Invoke(_joystickValue);
	}

	public virtual void OnDrag(PointerEventData eventData)
	{
		// 조이스틱 위치 조정
		// IDragHandler 사용시 반드시 써야하는 함수
		// 드래그 도중 계속 실행됨
		_newTargetPosition = TargetCamera.ScreenToWorldPoint(eventData.position);
		_newTargetPosition = Vector2.ClampMagnitude(_newTargetPosition - _neutralPosition, MaxRange);
		_newJoystickPosition = _neutralPosition + _newTargetPosition;

		// 조이스틱 위치 수정
		transform.position = _newJoystickPosition;
		var localPos = transform.localPosition;
		transform.localPosition = new Vector3(localPos.x, localPos.y, 0f);
	}

	public virtual void OnEndDrag(PointerEventData eventData)
	{
		// 초기값으로 설정
		// 드래그가 끝날 때 실행
		_newJoystickPosition = _neutralPosition;
		transform.position = _newJoystickPosition;
		var localPos = transform.localPosition;
		transform.localPosition = new Vector3(localPos.x, localPos.y, 0f);

		_newTargetPosition = Vector2.zero;
		_joystickValue.x = 0f;
		_joystickValue.y = 0f;
	}

	protected virtual float EvaluateInputValue(float vectorPosition)
	{
		return Mathf.InverseLerp(0, MaxRange, Mathf.Abs(vectorPosition)) * Mathf.Sign(vectorPosition);
	}
}