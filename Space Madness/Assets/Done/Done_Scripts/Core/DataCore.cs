using System;
using UnityEngine;
using System.Text;

namespace AssemblyCSharp
{
	public class DataCore
	{
        public string CurrentUsername
        {
            get 
            {
                return PlayerPrefs.GetString("CurrentUsername"); 
            }
            set
            {
                PlayerPrefs.SetString("CurrentUsername",value);
                PlayerPrefs.Save();
            }
        }
	}
}
