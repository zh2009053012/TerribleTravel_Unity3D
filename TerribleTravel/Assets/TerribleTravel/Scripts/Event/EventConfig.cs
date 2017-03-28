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
		//bathroom mirror
		EventData e8 = new EventData(8, new int[]{});
		AddData (e8);
		//bathroom window
		EventData e9 = new EventData(9, new int[]{8});
		AddData (e9);
		//bathroom bathtub
		EventData e10 = new EventData(10, new int[]{9});
		AddData (e10);
		//bathroon hand
		EventData e11 = new EventData(11, new int[]{10});
		AddData (e11);
		//daughterroom droplight down
		EventData e12 = new EventData(12, new int[]{});
		AddData (e12);
		//daughterroom heart
		EventData e13 = new EventData(13, new int[]{12});
		AddData (e13);
		//mainroom picture
		EventData e14 = new EventData(14, new int[]{});
		AddData (e14);
		//mainroom back picture
		EventData e15 = new EventData(15, new int[]{14});
		AddData (e15);
		//mainroom coin
		EventData e16 = new EventData(16, new int[]{15});
		AddData (e16);
		//balcony painter
		EventData e17 = new EventData(17, new int[]{});
		AddData (e17);
		//balcony lung
		EventData e18 = new EventData(18, new int[]{17});
		AddData (e18);
		//garage waterbottle
		EventData e19 = new EventData(19, new int[]{});
		AddData (e19);
		//garage open white car
		EventData e20 = new EventData(20, new int[]{});
		AddData (e20);
		//garage black seed
		EventData e21 = new EventData(21, new int[]{});
		AddData (e21);
		//garage clean seed
		EventData e22 = new EventData(22, new int[]{});
		AddData (e22);
		//garage get seed
		EventData e23 = new EventData(23, new int[]{22});
		AddData (e23);
		//studyroom ghost
		EventData e24 = new EventData(24, new int[]{});
		AddData (e24);
		//studyroom computer hit
		EventData e25 = new EventData(25, new int[]{24});
		AddData (e25);
		//daughterroom dresser
		EventData e26 = new EventData(26, new int[]{});
		AddData (e26);
		//bathroom mirror open broken mirror
		EventData e27 = new EventData(27, new int[]{});
		AddData (e27);
	}
}
