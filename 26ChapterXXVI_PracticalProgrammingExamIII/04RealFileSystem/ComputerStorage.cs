using System;
using System.Collections.Generic;

namespace _04RealFileSystem
{
    public class ComputerStorage
    {
        private SortedSet<Device> devices;

        public ComputerStorage()
        {
            this.devices = new SortedSet<Device>();
        }

        public ComputerStorage(IEnumerable<Device> devices)
        {
            this.devices = new SortedSet<Device>(devices);
        }

        public SortedSet<Device> Devices => this.devices;

        public bool AddDevice(Device device)
        {
            return this.devices.Add(device);
        }

        public bool RemoveDevice(Device device)
        {
            return this.devices.Remove(device);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.Devices);
        }
    }
}