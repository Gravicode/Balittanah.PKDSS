using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class GpsDevice2
    {
        public GpsPoint CurrentLocation { get; set; }
        public GpsDevice2(string Port)
        {
            this.Port = Port;
            CurrentLocation = new GpsPoint() { Latitude=0, Longitude=0 };
        }
        private Queue<string> messages = new Queue<string>(101);
        Dictionary<string, List<NmeaParser.Nmea.Gsv>> gsvMessages = new Dictionary<string, List<NmeaParser.Nmea.Gsv>>();
        public string Port { get; set; }
        public void StartGPS()
        {
            var port = new System.IO.Ports.SerialPort(Port, 9600); //change parameters to match your serial port
            var device = new NmeaParser.SerialPortDevice(port);
            device.MessageReceived += Device_MessageReceived; 
            device.OpenAsync();
           
        }

        private void Device_MessageReceived(object sender, NmeaParser.NmeaMessageReceivedEventArgs args)
        {
            var device = sender as NmeaParser.NmeaDevice;

            messages.Enqueue(args.Message.MessageType + ": " + args.Message.ToString());
            if (messages.Count > 100) messages.Dequeue(); //Keep message queue at 100
            //output.Text = string.Join("\n", messages.ToArray());
            //output.Select(output.Text.Length - 1, 0); //scroll to bottom

            if (args.Message is NmeaParser.Nmea.Gsv gpgsv)
            {
                if (args.IsMultipart && args.MessageParts != null)
                {
                    gsvMessages[args.Message.MessageType] = args.MessageParts.OfType<NmeaParser.Nmea.Gsv>().ToList();
                    //satView.GsvMessages = gsvMessages.SelectMany(m => m.Value);
                }
            }
            if (args.Message is NmeaParser.Nmea.Gps.Gprmc)
            {
                var msg = args.Message as NmeaParser.Nmea.Gps.Gprmc;
                CurrentLocation.Latitude = msg.Latitude;
                CurrentLocation.Longitude = msg.Longitude;
                CurrentLocation.Timestamp = msg.FixTime;
                CurrentLocation.SpeedInKnots = msg.Speed;
                CurrentLocation.BearingInDegrees = msg.Course;
                Console.WriteLine("-gprmc-");
                Console.WriteLine(CurrentLocation);
               
                
            }
            else if (args.Message is NmeaParser.Nmea.Gps.Gpgga)
            {
                var msg = args.Message as NmeaParser.Nmea.Gps.Gpgga;
                CurrentLocation.Latitude = msg.Latitude;
                CurrentLocation.Longitude = msg.Longitude;
                CurrentLocation.Timestamp = DateTime.Now;
                Console.WriteLine("-Gpgga-");
                Console.WriteLine(CurrentLocation);
               
                //CurrentLocation.SpeedInKnots = 0;
                //CurrentLocation.BearingInDegrees = 0;
            }

            else if (args.Message is NmeaParser.Nmea.Gps.Gpgsa)
            {
                var msg = args.Message as NmeaParser.Nmea.Gps.Gpgsa;
                //Console.WriteLine("-Gpgsa-");
                //Console.WriteLine(msg);
               //do nothing
            }

            else if (args.Message is NmeaParser.Nmea.Gps.Gpgll)
            {
                var msg = args.Message as NmeaParser.Nmea.Gps.Gpgll;
                CurrentLocation.Latitude = msg.Latitude;
                CurrentLocation.Longitude = msg.Longitude;
                Console.WriteLine("-Gpgll-");
                Console.WriteLine(CurrentLocation);
                

            }
            else if (args.Message is NmeaParser.Nmea.Gps.Garmin.Pgrme)
            {
                var msg = args.Message as NmeaParser.Nmea.Gps.Garmin.Pgrme;
                //Console.WriteLine("-Pgrme-");
                //Console.WriteLine(msg);
            }
            else if (args.Message is NmeaParser.Nmea.UnknownMessage)
            {
                //unknown message
                var msg = args.Message as NmeaParser.Nmea.UnknownMessage;
                //Console.WriteLine("-UnknownMessage-");
                //Console.WriteLine(msg);
            }
            else
            {
                //
            }
        }


    }
    public class GpsPoint
    {
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double SpeedInKnots { get; set; }
        public double BearingInDegrees { get; set; }
        public override string ToString()
        {
            return Timestamp.ToString("dd/MM/yy HH:mm:ss")+" | lat/lon: " + Latitude + "," + Longitude +"| speed :"+SpeedInKnots+"| bearing :"+BearingInDegrees;
        }
    }

}