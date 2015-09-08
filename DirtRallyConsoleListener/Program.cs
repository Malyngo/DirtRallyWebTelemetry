using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using F1Speed.Core;
using Nancy.Owin;

namespace DirtRallyConsoleListener
{
    class Program
    {
        private const int listenPort = 20777;
        static Mutex syncMutex = new Mutex();

        private static void StartListener()
        {
            bool done = false;

            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            UdpClient listener = new UdpClient();
            // let another application also listen on this port (this might not be the only telemetry application / device)
            listener.ExclusiveAddressUse = false;
            listener.Client.SetSocketOption(
                SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            listener.Client.Bind(groupEP);

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<DiRtHub>();

            try
            {
                Console.WriteLine("Waiting for broadcast");
                while (!done)
                {
                    byte[] bytes = listener.Receive(ref groupEP);
                    // Lock access to the shared struct
                    //syncMutex.WaitOne();

                    // Convert the bytes received to the shared struct
                    var latestData = ConvertToPacket(bytes);
                    System.Console.WriteLine(string.Concat("Engine revs: ", latestData.EngineRevs));
                    System.Console.WriteLine(string.Concat("km/h: ", latestData.SpeedInKmPerHour));
                    System.Console.WriteLine(string.Concat("Gear: ", latestData.Gear));

                    hubContext.Clients.All.data(latestData);
                    //hubContext.Clients.All.engineRevs(latestData.EngineRevs);

                    // Release the lock again
                    //syncMutex.ReleaseMutex();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

        static int Main(string[] args)
        {
            string url = "http://+:8080/";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server running on {0}", url);

                // open browser window
                //System.Diagnostics.Process.Start(url);

                StartListener();
            }

            return 0;
        }

        public static TelemetryPacket ConvertToPacket(byte[] bytes)
        {
            // Marshal the byte array into the telemetryPacket structure
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var stuff = (TelemetryPacket)Marshal.PtrToStructure(
                handle.AddrOfPinnedObject(), typeof(TelemetryPacket));
            handle.Free();
            return stuff;
        }

        public static byte[] ConvertPacketToByteArray(TelemetryPacket packet)
        {
            int size = Marshal.SizeOf(packet);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(packet, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

    }
    
    public class DiRtHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}
