﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Components
{
    public partial class SolutionSummaryView : UserControl
    {
        private DbInstance Instance { get; set; }
        public CustomSqlContext Context { get; set; }

        public SolutionSummaryView(){
            InitializeComponent();
        }

        public void setInstance(DbInstance instance){
            Instance = instance;
            FillData();
        }

        public void FillData(){

            if (Instance != null){
                var flights = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id).ToList();
                var airplanes = flights.Select(x => x.Airplanes).Distinct();
                

                var totalDistance = 0;
                var flightTime = new TimeSpan(0);
                var totalLateness = new TimeSpan(0);
                var lateArrivals = 0;
                 var takenOnOrigin = 0;
                var leftOnDestination = 0;
                var emptyFlights = 0;
                var emptyKilometers = 0;
                var numStops = 0;
                
                var stretches = Context.Stretches.Where(x => x.InstanceId == Instance.Id).GroupBy(x=>x.Origin).ToDictionary(x=>x.Key, x=>x.ToList());
                this.chartAirplaneKilometers.Series["Km"].Points.Clear();

                Dictionary<string, double> AirplaneDistance = new Dictionary<string, double>();
                Dictionary<DbRequests, List<DbFlightsReport>> FlightsPerRequest = new Dictionary<DbRequests, List<DbFlightsReport>>();

                FlightsPerRequest = Context.PassagersOnFlight.Where(x=>x.Flight.Instance.Id == Instance.Id).ToList()
                                                             .GroupBy(x => x.Passenger).ToDictionary(x => x.Key, x => x.Select(y => y.Flight).ToList());


                foreach (var flight in flights){

                    var isEmptyFlight = !Context.PassagersOnFlight.Any(x => x.Flight.Id == flight.Id);
                    if (stretches.ContainsKey(flight.Origin.AirportName))
                        if(stretches[flight.Origin.AirportName].Any(x => x.Destination.Equals(flight.Destination.AirportName))) { 
                            var distance =  stretches[flight.Origin.AirportName].First(x => x.Destination.Equals(flight.Destination.AirportName)).Distance;
                            totalDistance += distance;

                            if (isEmptyFlight)
                                emptyKilometers += distance;

                            if (!AirplaneDistance.ContainsKey(flight.Airplanes.Prefix))
                                AirplaneDistance[flight.Airplanes.Prefix] = 0;

                            AirplaneDistance[flight.Airplanes.Prefix] += distance;
                            
                        }
                    flightTime += flight.ArrivalTime - flight.DepartureTime;

                    takenOnOrigin += Context.PassagersOnFlight.Count(x => x.Passenger.Origin.Id == flight.Origin.Id && x.Flight.Id == flight.Id);
                    leftOnDestination += Context.PassagersOnFlight.Count(x => x.Passenger.Destination.Id == flight.Destination.Id && x.Flight.Id == flight.Id);

                    if (isEmptyFlight)
                        emptyFlights++;
                }


                foreach (var pair in FlightsPerRequest){
                    numStops += pair.Value.Any() ? pair.Value.Count()-1:0;
                    var lastArrival = pair.Value.Max(x => x.ArrivalTime);
                    totalLateness += lastArrival > pair.Key.ArrivalTimeWindowEnd? lastArrival - pair.Key.ArrivalTimeWindowEnd - new TimeSpan(0) : new TimeSpan(0);
                    lateArrivals += (lastArrival > pair.Key.ArrivalTimeWindowEnd)?1:0;
                }

                var totalTime = new TimeSpan(0);
                
                foreach (var airplane in airplanes){
                    var minDeparture = flights.Where(x=>x.Airplanes.Id == airplane.Id).Min(x=>x.DepartureTime);
                    var maxArrivalTime = flights.Where(x => x.Airplanes.Id == airplane.Id).Max(x => x.ArrivalTime);
                    totalTime += maxArrivalTime - minDeparture;

                    chartAirplaneKilometers.Series["Km"].Points.AddXY(airplane.Prefix, AirplaneDistance[airplane.Prefix]);

                }

                labelFlights.Text = flights.Count().ToString();
                labelKmFlight.Text = totalDistance.ToString();
                labelEmptyFlights.Text = emptyFlights.ToString();
                labelEmptyKilometers.Text = emptyKilometers.ToString();
                labelPassengersTaken.Text = takenOnOrigin.ToString();
                labelPassengersDeliverd.Text = leftOnDestination.ToString();
                labelHourFlight.Text =  Math.Round((flightTime - new TimeSpan(0)).TotalHours,2).ToString();
                labelStoppedHours.Text = Math.Round((totalTime - flightTime - new TimeSpan(0)).TotalHours,2).ToString();
                labelLateArrivalsHours.Text = Math.Round((totalLateness - new TimeSpan(0)).TotalHours,2).ToString();
                labelLateArrivals.Text = lateArrivals.ToString();
                labelTotalPassengers.Text = Context.PassagersOnFlight.Count(x=>x.Flight.Instance.Id == Instance.Id).ToString();

            }
        }

        private void SolutionSummaryView_Load(object sender, EventArgs e){
            FillData();
        }
    }
}
