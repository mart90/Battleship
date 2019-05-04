using MBRD.Boats;

namespace MBRD.Boats.Factory
{
   

    public class FleetFactory
    {
        BoatFactory boatFactory = new BoatFactory();

        public static Fleet GenerateFleet()
        {
            Fleet fleet = new Fleet();

            fleet.Add(BoatFactory.GenerateDefaultAircraftCarrier());

            fleet.Add(BoatFactory.GenerateDefaultBattleship());
            fleet.Add(BoatFactory.GenerateDefaultBattleship());

            fleet.Add(BoatFactory.GenerateDefaultSubmarine());
            fleet.Add(BoatFactory.GenerateDefaultSubmarine());
            fleet.Add(BoatFactory.GenerateDefaultSubmarine());

            fleet.Add(BoatFactory.GenerateDefaultScout());
            fleet.Add(BoatFactory.GenerateDefaultScout());
            fleet.Add(BoatFactory.GenerateDefaultScout());
            fleet.Add(BoatFactory.GenerateDefaultScout());
            
            return fleet;
        }
    }
}
