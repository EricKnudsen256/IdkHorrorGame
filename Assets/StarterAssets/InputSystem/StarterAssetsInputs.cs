using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
        public bool interact;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        private PlayerInput playerInputs;

        private void Awake()
        {
            playerInputs = this.GetComponent<PlayerInput>();
        }


#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
        {

			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

        public void OnInteract(InputValue value)
        {
            InteractInput(value.isPressed);

            InputAction interactAction = playerInputs.actions["Interact"];
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

        public void InteractInput(bool newInteractState)
        {
            interact = newInteractState;
        }

        public string GetInputKeyByName(string inputName)
        {
            InputAction action = playerInputs.currentActionMap.FindAction(inputName);

            if (action == null)
            {
                Debug.Log("Input action: " + inputName + " called in GetInputKeyByName not found");
                return "";
            }

            var bindingIndex = action.GetBindingIndex(InputBinding.MaskByGroup(playerInputs.currentControlScheme));

            return action.GetBindingDisplayString(bindingIndex);
        }


        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}