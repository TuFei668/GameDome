using UnityEngine;
using System.Collections;

public enum PlayerStatus {
	NONE = 0,
	DOWN = 1,
	LEFT = 2,
	RIGHT = 3,
	JUMP = 4,
	BOMB = 5,
	DEAD = 6,
	SHOOT = 7,
	IDLE = 8,
	UP = 9
}

public class playerMove : MonoBehaviour {


	//角色
	private GameObject player;
	private Soldier soldier;
	private Transform playAnim;

	private bool btnRightPressed = false;
	private bool btnLeftPressed = false;
	private bool btnJumpPressed = false;
	private bool btnDownPressed = false;
	private bool btnUpPressed = false;
 
	private bool isRightDir = true;
	private bool isDown = true;

	private bool isGround = true;
	public float JumpSpeed = 5;
	private int groundLayMask;

	private PlayerStatus playerStatus = PlayerStatus.NONE;

	private bool direction = true;
	private bool currenDire;
	Vector3 player_v3 ;
	Rigidbody rigidbody ;
	public int speed = 1;
	void Awake()
	{
		rigidbody = transform.GetComponent <Rigidbody>();

	}
	void Start()
	{
		player = this.gameObject;
		soldier = transform.GetComponent<Soldier>();
		player_v3 = rigidbody.velocity;
		//groundLayMask = LayerMask.GetMask("Ground");
		playAnim = transform.FindChild ("enemy(Clone)"); 
	}

	void Update()
	{
//		if(!isDown)
//		{∂
//			isDown = true;
//		}
//		UpdateState();

		if(Input.GetKey(KeyCode.D))
		{
			ToRight();	
		}
		if(Input.GetKey(KeyCode.A))
		{
			ToLeft();
		}
	}
	 
	void UpdateState()
	{
		switch(playerStatus)
		{
		case PlayerStatus.NONE:
			ToIdle();
			break;
		case PlayerStatus.BOMB:
			ToBomb();
			break;
		case PlayerStatus.DEAD:
			ToDead();
			break;
		case PlayerStatus.DOWN:
			ToDown();
			break;
		case PlayerStatus.IDLE:
			ToIdle();
			break;
		case PlayerStatus.JUMP:
			ToJump();
			break;
		case PlayerStatus.UP:
			ToJump();
			break;
		case PlayerStatus.LEFT:
			ToLeft();
			break;
		case PlayerStatus.RIGHT:
			ToRight();
			break;
		case PlayerStatus.SHOOT:
			ToShoot();
			break;
		}

	}

	void ToDown()
	{
		
	}

	public void ToJump()
	{
		RaycastHit hit;
		isGround = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 0.2f, groundLayMask);
//		//跳跃判定
//		if (isGround)
//		{
			Vector3 v0 = rigidbody.velocity;
			rigidbody.velocity = new Vector3(v0.x, JumpSpeed, v0.z);
			soldier.ToJump();
//		}
	}

	public void ToLeft()
	{
		RaycastHit hitleft;
		if(!Physics.Raycast(transform.position, Vector3.left, out hitleft, 0.1f, groundLayMask))
		{
			transform.Translate(Vector3.left * 2f * TimeHelper.deltaTime);
		}
		playAnim.localScale = new Vector3(1,1,1);
		soldier.ToWalk();
	}

	public void ToRight()
	{
		
		RaycastHit hitRight;
		if (!Physics.Raycast(transform.position, Vector3.right, out hitRight, 0.1f, groundLayMask))
		{
			transform.Translate(Vector3.right * 2f * TimeHelper.deltaTime);
		}
		playAnim.localScale = new Vector3(-1, 1, 1);
		soldier.ToWalk();
	}

	public void ToShoot()
	{
		soldier.ToShoot();
	}
	void ToBomb()
	{
		 
	}

	public void ToDead()
	{
		soldier.ToDead();
	}
	 
	public void ToIdle()
	{
		soldier.ToIdle();
	}

	public void JosMove(float joyPositionX,float joyPositionY,bool isFinish)
	{
		
		Vector3 v = new Vector3(joyPositionX,joyPositionY,0.0f); 
		v.Normalize();
		Trace.trace("Normalize  " + v.x + " " + v.y +  " " + isFinish ,Trace.CHANNEL.UI);
		joyPositionX = v.x;
		joyPositionY = v.y;
		isDown = isFinish;

		if (joyPositionY != 0.0f || joyPositionX != 0.0f)
		{
			if (Mathf.Abs(joyPositionY) < 0.4f)
			{
				playerStatus = PlayerStatus.NONE;
				if (joyPositionX > 0.2f)
				{
					playerStatus = PlayerStatus.RIGHT;
				}
				else
				{
					playerStatus = PlayerStatus.RIGHT;
				}
			}
			else
			{
				if (joyPositionY > 0.4f)
				{
					playerStatus = PlayerStatus.UP;
					if (joyPositionX > 0.2f)
					{
						playerStatus = PlayerStatus.RIGHT;
					}
					else
						if (joyPositionX < -0.2f)
						{
							playerStatus = PlayerStatus.LEFT;
						}
						else
						{
							playerStatus = PlayerStatus.NONE;
						}
				}
				else
				{
					if (joyPositionY < -0.4f)
					{
						playerStatus = PlayerStatus.DOWN;
						if (joyPositionX > 0.2f)
						{
							playerStatus = PlayerStatus.RIGHT;
						}
						else
							if (joyPositionX < -0.2f)
							{
								playerStatus = PlayerStatus.LEFT;
							}
							else
							{
								playerStatus = PlayerStatus.NONE;
							}
					}
				}
			}
		}

//		if (joyPositionY != 0.0f || joyPositionX != 0.0f)
//		{
//			if (Mathf.Abs(joyPositionY) < 0.4)
//			{
//				this.btnDownPressed = false;
//				this.btnUpPressed = false;
//				if (joyPositionX > 0)
//				{
//					this.btnLeftPressed = false;
//					this.btnRightPressed = true;
//					this.isRightDir = true;
//				}
//				else
//				{
//					this.btnRightPressed = false;
//					this.btnLeftPressed = true;
//					this.isRightDir = false;
//				}
//			}
//			else
//			{
//				if (joyPositionY > 0.4)
//				{
//					this.btnDownPressed = false;
//					this.btnUpPressed = true;
//					if (joyPositionX > 0.2)
//					{
//						this.btnLeftPressed = false;
//						this.btnRightPressed = true;
//						this.isRightDir = true;
//					}
//					else
//						if (joyPositionX < -0.2)
//						{
//							this.btnRightPressed = false;
//							this.btnLeftPressed = true;
//							this.isRightDir = false;
//						}
//						else
//						{
//							this.btnRightPressed = false;
//							this.btnLeftPressed = false;
//						}
//				}
//				else
//				{
//					if (joyPositionY < -0.4)
//					{
//						this.btnUpPressed = false;
//						this.btnDownPressed = true;
//						if (joyPositionX > 0.2)
//						{
//							this.btnLeftPressed = false;
//							this.btnRightPressed = true;
//							this.isRightDir = true;
//						}
//						else
//							if (joyPositionX < -0.2)
//							{
//								this.btnRightPressed = false;
//								this.btnLeftPressed = true;
//								this.isRightDir = false;
//							}
//							else
//							{
//								this.btnRightPressed = false;
//								this.btnLeftPressed = false;
//							}
//					}
//				}
//			}
//		}
	}

	private void InputMove()
	{
		
	}
}

