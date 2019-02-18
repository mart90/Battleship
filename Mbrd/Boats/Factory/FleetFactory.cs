using MBRD.Boats;

namespace MBRD.Boats.Factory
{
    class FleetFactory
    {
        public Fleet GenerateFleet()
        {
            Fleet fleet = new Fleet();
            BoatFactory boatFactory = new BoatFactory();
            
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
