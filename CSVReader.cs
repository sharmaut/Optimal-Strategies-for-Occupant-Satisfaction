using System.Collections;
using System.Collections.Generic;

public class SolarPowerEnergy
{
    public string Weather;

}

public class CSVReader : MonoBehaviour
{
    //this is our public list for all other gameObject to use
    public List<SolarPowerEnergy> spE = new List<SolarPowerEnergy>();

    public List<string> weatherCondtion = new List<string>();

    void Awake()
    {
        Debug.Log("Read the CSV file");
        TextAsset DataCSV = Resources.Load<TextAsset>("Weather");
        string[] line = DataCSV.text.Split(new char[] { '\n' });

        for (int i = 0; i < line.Length; i++)
        {
            string[] part = line[i].Split(new char[] { ';' });

            SolarPowerEnergy solarPowerEnergy = new SolarPowerEnergy();

            solarPowerEnergy.Weather = part[0];

            spE.Add(solarPowerEnergy);

        }

        for (int i = 0; i < spE.Count; i++)
        {

            string[] part1 = spE[i].Weather.Split(new char[] { ',' });

            weatherCondtion.Add(part1[1]);

            //Debug.Log("WeatherCondtion: " + weatherCondtion[i]);

        }
    }
}