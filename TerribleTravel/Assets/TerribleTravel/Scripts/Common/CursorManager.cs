using UnityEngine;
using System.Collections;

public class CursorManager {
	public enum CursorState{
		DEFAULT,
		SELECT,
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
			center = new Vector2(DefaultCursor.width, DefaultCursor.height)*0.5f;
			Cursor.SetCursor(DefaultCursor, center, CursorMode.ForceSoftware);
			break;
		case CursorState.SELECT:
			center = new Vector2(SelCursor.width, SelCursor.height)*0.5f;
			Cursor.SetCursor(SelCursor, center, CursorMode.ForceSoftware);
			break;
		}
	}
}
