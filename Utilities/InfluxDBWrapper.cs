using System;
using System.Collections.Generic;
using System.Text;
using OpenHardwareMonitor.GUI;
using System.Net;
using OpenHardwareMonitor.Hardware;
using System.Globalization;
using System.Linq;
using System.IO;

namespace OpenHardwareMonitor.Utilities
{
    public class InfluxDBWrapper
    {
        private string host;
        private int port;
        private string database;

        private string currentState;

        private readonly IComputer computer;

        private string[] identifiers;
        private ISensor[] sensors;

        WebRequest request;

        public InfluxDBWrapper(Computer computer, string host, int port)
        {
            this.host = host;
            this.port = port;
            this.database = "ohm";

            this.computer = computer;
            this.computer.HardwareAdded += HardwareAdded;
            this.computer.HardwareRemoved += HardwareRemoved;

            IList<ISensor> list = new List<ISensor>();
            SensorVisitor visitor = new SensorVisitor(sensor => {
                list.Add(sensor);
            });
            visitor.VisitComputer(computer);
            sensors = list.ToArray();
            identifiers = sensors.Select(s => s.Identifier.ToString()).ToArray();
        }

        private void HardwareRemoved(IHardware hardware)
        {
            hardware.SensorAdded -= SensorAdded;
            hardware.SensorRemoved -= SensorRemoved;
            foreach (ISensor sensor in hardware.Sensors)
                SensorRemoved(sensor);
            foreach (IHardware subHardware in hardware.SubHardware)
                HardwareRemoved(subHardware);
        }

        private void HardwareAdded(IHardware hardware)
        {
            foreach (ISensor sensor in hardware.Sensors)
                SensorAdded(sensor);
            hardware.SensorAdded += SensorAdded;
            hardware.SensorRemoved += SensorRemoved;
            foreach (IHardware subHardware in hardware.SubHardware)
                HardwareAdded(subHardware);
        }

        private void SensorAdded(ISensor sensor)
        {
            if (sensors == null)
                return;

            for (int i = 0; i < sensors.Length; i++)
            {
                if (sensor.Identifier.ToString() == identifiers[i])
                    sensors[i] = sensor;
            }
        }

        private void SensorRemoved(ISensor sensor)
        {
            if (sensors == null)
                return;

            for (int i = 0; i < sensors.Length; i++)
            {
                if (sensor == sensors[i])
                    sensors[i] = null;
            }
        }



        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public byte[] CurrentState
        {
            get
            {
                return Encoding.ASCII.GetBytes(currentState);
            }
            set
            {
                currentState = Encoding.ASCII.GetString(value);
            }
        }

        internal void StartInfluxDBReporting()
        {
            Console.WriteLine("InfluxDB - Start");
        }

        private string InfluxURL()
        {
            return "http://" + host + ":" + port + "/write?db=" + database;
        }

        internal void StopInfluxDBReporting()
        {
            Console.WriteLine("InfluxDB - Stop");
        }

        internal void Quit()
        {
            Console.WriteLine("InfluxDB - Quit");
        }

        public byte[] GetCurrentState()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < sensors.Length; i++)
            {
                if (sensors[i] != null)
                {
                    float? value = sensors[i].Value;
                    if (value.HasValue)
                        builder.Append(SensorToLineProtocol(sensors[i]) + "\n");
                }
            }
            return Encoding.ASCII.GetBytes(builder.ToString().TrimEnd('\n'));
        }

        private string SensorToLineProtocol(ISensor sensor)
        {
            float? value = sensor.Value;
            return "sensor,identification=\"" + sensor.Identifier.ToString() + "\" " +
                "name=\"" + sensor.Name + "\"" +
                ",value=" + value.Value.ToString("R", CultureInfo.InvariantCulture);
        }

        public void Update()
        {
            try
            {
                request.Abort();
            }
            catch { }

            try
            {
                request = WebRequest.Create(InfluxURL());
                request.Method = "POST";

                CurrentState = GetCurrentState();
                request.ContentLength = CurrentState.Length;
                request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
            }
            catch(Exception)
            {}
        }

        private void GetRequestStreamCallback(IAsyncResult result)
        {
            try
            {
                WebRequest request = (WebRequest)result.AsyncState;
                Stream stream = request.EndGetRequestStream(result);

                stream.Write(CurrentState, 0, CurrentState.Length);
                stream.Close();
                request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
            }
            catch (Exception)
            {}
        }

        private static void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            try
            {
                WebResponse response = (WebResponse)request.EndGetResponse(asynchronousResult);
                response.Close();
            }
            catch (WebException) { }
        }
    }
}
