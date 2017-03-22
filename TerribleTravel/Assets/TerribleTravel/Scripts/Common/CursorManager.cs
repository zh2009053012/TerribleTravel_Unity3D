using UnityEngine;
using System.Collections;

public class CursorManager {
	public enum CursorState{
		DEFAULT,
		SELECT,
		OPEN,
		BACK,
	}
	private static Texture2D m_selCursor;
	public static Texture2D SelCursor{
		get{
			if(m_selCursor == null){
				m_selCursor = Resources.Load<Texture2D>("Cursor/SelectCursor");
			}
			return m_selCursor;
		}
	}
	private static Texture2D m_openCursor;
	public static Texture2D OpenCursor{
		get{
			if(m_openCursor == null){
				m_openCursor = Resources.Load<Texture2D>("Cursor/OpenCursor");
			}
			return m_openCursor;
		}
	}
	private static Texture2D m_backCursor;
	public static Texture2D BackCursor{
		get{
			if(m_backCursor == null){
				m_backCursor = Resources.Load<Texture2D>("Cursor/BackCursor");
			}
			return m_backCursor;
		}
	}
	private static Texture2D m_defaultCursor;
	public static Texture2D DefaultCursor{
		get{
			if(m_defaultCursor == null){
				m_defaultCursor = Resources.Load<Texture2D>("Cursor/DefaultCursor");
			}
			return m_defaultCursor;
		}
	}

	public static void SetCursor(CursorState cs){
		Vector2 center = Vector2.zero;
		switch(cs){
		case CursorState.DEFAULT:
			//center = new Vector2(DefaultCursor.width, DefaultCursor.height)*0.5f;
			Cursor.SetCursor(DefaultCursor, center, CursorMode.ForceSoftware);
			break;
		case CursorState.SELECT:
			//center = new Vector2(SelCursor.width, SelCursor.height)*0.5f;
			Cursor.SetCursor(SelCursor, center, CursorMode.ForceSoftware);
			break;
		case CursorState.BACK:
			//center = new Vector2(BackCursor.width, BackCursor.height)*0.5f;
			Cursor.SetCursor(BackCursor, center, CursorMode.ForceSoftware);
			break;
		case CursorState.OPEN:
			//center = new Vector2(OpenCursor.width, OpenCursor.height)*0.5f;
			Cursor.SetCursor(OpenCursor, center, CursorMode.ForceSoftware);
			break;
		}
	}
}
