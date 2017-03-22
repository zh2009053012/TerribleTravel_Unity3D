using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventData{
	public int m_id;
	public List<int> m_openRequiredList = new List<int>();
	public EventData(){}
	public EventData(int id, int[] triggers){
		m_id = id;
		m_openRequiredList.AddRange(triggers);
	}
	public EventData Copy(){
		EventData data = new EventData(this.m_id, this.m_openRequiredList.ToArray());
		return data;
	}
}

public class EventConfig {

	private static List<EventData> m_dataList = new List<EventData>();
	private static bool m_isConfig = false;
	private static bool AddData(EventData data){
		if(null == GetEventData(data.m_id)){
			m_dataList.Add(data);
			return true;
		}else{
			Debug.LogError("EventConfig::AddData:event "+data.m_id+" is already exist.");
			return false;
		}
	}

	public static EventData GetEventDataCopy(int id){
		if(!m_isConfig)
			Config();
		for(int i=0; i<m_dataList.Count; i++){
			if(m_dataList[i].m_id == id){
				return m_dataList[i].Copy();
			}
		}
		return null;
	}
	public static EventData GetEventData(int id){
		for(int i=0; i<m_dataList.Count; i++){
			if(m_dataList[i].m_id == id){
				return m_dataList[i];
			}
		}
		return null;
	}

	public static void Config(){
		m_isConfig = true;
		EventData e1 = new EventData(1, new int[]{});
		AddData(e1);
		//dining room->picture
		EventData e2 = new EventData(2, new int[]{});
		AddData(e2);
		//dining table->eye
		EventData e3 = new EventData(3, new int[]{2});
		AddData (e3);
		//clothing room->head1
		EventData e4 = new EventData(4, new int[]{5,6,7});
		AddData (e4);
		//clothing room->head2
		EventData e5 = new EventData(5, new int[]{});
		AddData (e5);
		//clothing room->head3
		EventData e6 = new EventData(6, new int[]{});
		AddData (e6);
		//clothing room->head4
		EventData e7 = new EventData(7, new int[]{});
		AddData (e7);
	}
}
