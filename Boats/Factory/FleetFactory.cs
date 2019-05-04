using MBRD.Boats;

namespace MBRD.Boats.Factory
{
   

    public class FleetFactory
    {
        BoatFactory boatFactory = new BoatFactory();

        public Fleet GenerateFleet()
        {
            Fleet fleet = new Fleet();

            fleet.Add(boatFactory.GenerateDefaultAircraftCarrier());

            fleet.Add(boatFactory.GenerateDefaultBattleship());
            fleet.Add(boatFactory.GenerateDefaultBattleship());

            fleet.Add(boatFactory.GenerateDefaultSubmarine());
            fleet.Add(boatFactory.GenerateDefaultSubmarine());
            fleet.Add(boatFactory.GenerateDefaultSubmarine());

            fleet.Add(boatFactory.GenerateDefaultScout());
            fleet.Add(boatFactory.GenerateDefaultScout());
            fleet.Add(boatFactory.GenerateDefaultScout());
            fleet.Add(boatFactory.GenerateDefaultScout());
            
            return fleet;
        }
    }
}
