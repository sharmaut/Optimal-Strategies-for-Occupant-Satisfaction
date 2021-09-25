using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class ScenarioSimulation 
{

    public enum Weather
    {
        Day,
        Night,
        Rain,
        Evening      
    };

    public Weather weather;

    public int[] storedEnergyInSolarPanel;

    public bool isBatteryDrained;

    public float batterycapacity, batteryEnergyConsumption;

    public bool isSupplyBuilding;

    public bool isSolarSupply = true;

    public bool isCloudy = false, isCsvReader;

    public CSVReader cSVReader;

    private Timer timer1;

        void main(){
        
        if (weather == Weather.Night)
        {
            batteryEnergyConsumption = batterycapacity;
            isSupplyBuilding = true;
        }
        else if (weather == Weather.Rain)
        {
            isCloudy = true;
        }
        if (!isCsvReader)
        {
            timer1 = new Timer(); //new Timer(1000);
            timer1.Elapsed += (sender, e) =>
            {
                BatteryCharge();
            };
            timer1.Interval = 1000;//miliseconds
            timer1.Start();
            // StartCoroutine(BatteryCharge());
        }
    }

    void BatteryCharge()
    {

        // yield return new WaitForSeconds(1);
        Debug.Log("Call in 1 second");
        
        if (weather == Weather.Day)
        {

            if(isSolarSupply){
            if (batterycapacity > batteryEnergyConsumption)
            {
                Debug.Log("Battery Charge!");
                batteryEnergyConsumption++;  
                //Supply To building
            }
            else if (batterycapacity == batteryEnergyConsumption)
            {
                //SolarEnergy cut no battery charge
                Debug.Log("Battery is not charging due to its full charge capacity!");
                isSupplyBuilding= true;
              
            }}

            if (isSupplyBuilding == true)
            {
                isSolarSupply = false;
                batteryEnergyConsumption--;
                if(batteryEnergyConsumption == 0)
                {
                    isSolarSupply = true;
                    isSupplyBuilding= false;
                }
            }
           
        }
        else if (weather == Weather.Night)
        {
            if (isSupplyBuilding == true)
            {
                if (batteryEnergyConsumption > 0)
                {
                    batteryEnergyConsumption--;
                }
                else
                {
                    Debug.Log("No Supply Due to battery drained!");
                }
            }
        }else if(weather == Weather.Rain)
        {
            if(isCloudy)
            {
                 if(isSolarSupply){
                Debug.Log("20 percent energy given to battery");//batteryEnergyConsumption 100percent 
                //100 //60
                if (batterycapacity > batteryEnergyConsumption)
                {
                    Debug.Log("Battery Charge!");
                    batteryEnergyConsumption =batteryEnergyConsumption- 0.8f;  
                    batteryEnergyConsumption++;
                    //Supply To building

                }
                else if (batterycapacity <= batteryEnergyConsumption)
                {
                    //SolarEnergy cut no battery charge
                    Debug.Log("Battery is not charging due to its full charge capacity!");
                    isSupplyBuilding = true;
                }
            
            }

                if (isSupplyBuilding == true)
                {
                    batteryEnergyConsumption--;
                    if(batteryEnergyConsumption <=0.2f ){
                        isSupplyBuilding = false;
                        isSolarSupply = true;
                    }
                }

            }
            else
            {
                 if (isSupplyBuilding == true)
                {
                    if (batteryEnergyConsumption > 0)
                    {
                        batteryEnergyConsumption--;
                    }
                    else
                    {
                        Debug.Log("No Supply Due to battery drained!");
                    }
                }
            }
        }
        else if(weather == Weather.Evening)
        {
              if (batterycapacity > batteryEnergyConsumption)
                {
                    Debug.Log("Battery Charge!");
                    batteryEnergyConsumption =batteryEnergyConsumption- 0.4f;  
                    batteryEnergyConsumption++;
                    //Supply To building

                }
                else if (batterycapacity <= batteryEnergyConsumption)
                {
                    //SolarEnergy cut no battery charge
                    Debug.Log("Battery is not charging due to its full charge capacity!");
                    isSupplyBuilding = true;
                }

                if (isSupplyBuilding == true)
                {
                    batteryEnergyConsumption--;
                    if(batteryEnergyConsumption <=0.4f )
                    {
                        isSupplyBuilding = false;
                        isSolarSupply = true;
                    }
                }
            }
    }

}